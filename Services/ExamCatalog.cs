using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>One of the ten practice forms. The seed fixes which bank items the form draws.</summary>
/// <param name="OnlyMode">
/// Restricts the form to one delivery mode. Null means it can be sat either way, which is how
/// the AZ-900 forms work; a course can instead publish separate practice and exam forms.
/// </param>
public sealed record ExamForm(
    int Number, string Title, string Focus, int Seed, ExamMode? OnlyMode = null)
{
    /// <summary>
    /// Set on a custom test: the skills-outline objectives its questions are drawn from. Empty
    /// on a published form, which is stratified across the course's domains instead.
    /// </summary>
    public IReadOnlyList<SkillsSection> Sections { get; init; } = [];

    /// <summary>Questions a custom test draws. Published forms use the course's form size.</summary>
    public int Size { get; init; }

    /// <summary>Countdown in minutes when it differs from the course's, as a custom test's does.</summary>
    public int Minutes { get; init; }

    public bool IsCustom => Sections.Count > 0;
}

/// <summary>What the picker screen hands back: a form plus the mode to deliver it in.</summary>
public sealed record ExamStart(ExamForm Form, ExamMode Mode);

/// <summary>
/// Builds the ten practice forms from <see cref="QuestionBank"/>. Item selection is
/// deterministic per form, so exam 3 always contains the same 50 questions, while the
/// presentation order and the order of answer options are reshuffled on every attempt.
/// </summary>
public static class ExamCatalog
{
    /// <summary>Kept for the AZ-900 screens that still quote a fixed figure.</summary>
    public const int QuestionCount = 50;

    public static IReadOnlyList<ExamForm> Az900Forms { get; } =
    [
        new(1, "Practice Exam 1", "Full blueprint coverage", 11_001),
        new(2, "Practice Exam 2", "Full blueprint coverage", 11_002),
        new(3, "Practice Exam 3", "Full blueprint coverage", 11_003),
        new(4, "Practice Exam 4", "Full blueprint coverage", 11_004),
        new(5, "Practice Exam 5", "Full blueprint coverage", 11_005),
        new(6, "Practice Exam 6", "Full blueprint coverage", 11_006),
        new(7, "Practice Exam 7", "Full blueprint coverage", 11_007),
        new(8, "Practice Exam 8", "Full blueprint coverage", 11_008),
        new(9, "Practice Exam 9", "Full blueprint coverage", 11_009),
        new(10, "Practice Exam 10", "Full blueprint coverage", 11_010)
    ];

    /// <summary>
    /// Formularele cursului de Java: opt teste de exersare si opt examene, fiecare de 20 de
    /// intrebari. Fiecare formular isi are propriul seed, deci contine mereu aceleasi intrebari,
    /// prezentate insa in alta ordine la fiecare incercare.
    /// </summary>
    public static IReadOnlyList<ExamForm> JavaForms { get; } =
    [
        .. Enumerable.Range(1, 8).Select(n => new ExamForm(
            n, $"Test de exersare {n}", "Capitolele 2-8", 22_000 + n, ExamMode.Practice)),
        .. Enumerable.Range(1, 8).Select(n => new ExamForm(
            n + 8, $"Examen {n}", "Capitolele 2-8", 23_000 + n, ExamMode.Exam))
    ];

    public static ExamForm ById(int number) =>
        Az900Forms.FirstOrDefault(f => f.Number == number) ?? Az900Forms[0];

    /// <summary>
    /// A form made from the skills-outline objectives a candidate picked. It has no fixed seed,
    /// so every attempt draws a fresh set of questions.
    /// </summary>
    public static ExamForm Custom(Course course, IEnumerable<SkillsSection> sections, int size)
    {
        List<SkillsSection> picked = [.. sections];
        var available = picked.Sum(s => course.QuestionsIn(s).Count);
        size = Math.Clamp(size, 1, Math.Max(available, 1));

        return new ExamForm(0, "Custom practice test", string.Join(", ", picked.Select(s => s.Key)), 0)
        {
            Sections = picked,
            Size = size,
            Minutes = MinutesFor(course, size)
        };
    }

    /// <summary>
    /// Countdown for a form of the given length, at the same pace per question as the course's
    /// published forms: 45 minutes for 50 questions makes 9 minutes for 10.
    /// </summary>
    public static int MinutesFor(Course course, int questions) =>
        Math.Max(1, (questions * course.DurationMinutes + course.QuestionsPerForm - 1)
                    / course.QuestionsPerForm);

    /// <summary>
    /// Selects the form's questions, then randomises presentation for this attempt. A published
    /// form is stratified across the domains using the blueprint weighting; a custom test draws
    /// from the objectives that were picked.
    /// </summary>
    public static IReadOnlyList<Item> Build(Course course, ExamForm form)
    {
        var selected = form.IsCustom ? DrawCustom(course, form) : DrawPublished(course, form);

        // A fresh seed per attempt, so the same form feels different each time.
        var shuffler = new Random();
        return [.. Shuffle(selected, shuffler).Select(i => Randomise(i, shuffler))];
    }

    private static List<Item> DrawPublished(Course course, ExamForm form)
    {
        var picker = new Random(form.Seed);
        List<Item> selected = [];

        foreach (var domain in course.Domains)
        {
            var pool = course.QuestionsIn(domain);
            selected.AddRange(Sample(pool, domain.ItemsPerForm(), picker));
        }

        // Top up in the unlikely event a domain pool is short of its quota.
        if (selected.Count < course.QuestionsPerForm)
        {
            var chosen = selected.Select(i => i.Id).ToHashSet();
            var rest = course.Questions.Where(i => !chosen.Contains(i.Id)).ToList();
            selected.AddRange(Sample(rest, course.QuestionsPerForm - selected.Count, picker));
        }

        return selected;
    }

    /// <summary>
    /// Shares a custom test's questions across the picked objectives in proportion to how many
    /// each holds, so the mix follows the selection rather than the luck of the draw.
    /// </summary>
    private static List<Item> DrawCustom(Course course, ExamForm form)
    {
        var picker = new Random();
        var pools = form.Sections.Select(course.QuestionsIn).Where(p => p.Count > 0).ToList();
        var quotas = Apportion([.. pools.Select(p => p.Count)], form.Size);
        return [.. pools.SelectMany((pool, i) => Sample(pool, quotas[i], picker))];
    }

    /// <summary>
    /// Splits <paramref name="total"/> across groups in proportion to their sizes, by largest
    /// remainder. The shares always add up to the total, and none exceeds its group.
    /// </summary>
    private static int[] Apportion(IReadOnlyList<int> sizes, int total)
    {
        var available = sizes.Sum();
        if (available == 0)
        {
            return new int[sizes.Count];
        }

        total = Math.Clamp(total, 0, available);
        var shares = sizes.Select(s => s * total / available).ToArray();
        var leftover = total - shares.Sum();

        foreach (var i in Enumerable.Range(0, sizes.Count)
                     .OrderByDescending(i => sizes[i] * total % available)
                     .Take(leftover))
        {
            shares[i]++;
        }
        return shares;
    }

    private static List<T> Sample<T>(IReadOnlyList<T> pool, int count, Random rng) =>
        [.. Shuffle(pool, rng).Take(Math.Min(count, pool.Count))];

    private static List<T> Shuffle<T>(IEnumerable<T> source, Random rng)
    {
        var list = source.ToList();
        for (var i = list.Count - 1; i > 0; i--)
        {
            var j = rng.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
        return list;
    }

    /// <summary>Reorders the answer options of an item without changing which of them is keyed.</summary>
    private static Item Randomise(Item item, Random rng) => item switch
    {
        MultipleChoiceItem mc => RandomiseChoices(mc, rng),
        BuildListItem bl => new BuildListItem
        {
            Id = bl.Id,
            Stem = bl.Stem,
            Exhibits = bl.Exhibits,
            Domain = bl.Domain,
            Objective = bl.Objective,
            Explanation = bl.Explanation,
            Hint = bl.Hint,
            Reference = bl.Reference,
            SourceLabel = bl.SourceLabel,
            AnswerLabel = bl.AnswerLabel,
            Source = Shuffle(bl.Source, rng),
            Answer = bl.Answer
        },
        DragDropItem dd => new DragDropItem
        {
            Id = dd.Id,
            Stem = dd.Stem,
            Exhibits = dd.Exhibits,
            Domain = dd.Domain,
            Objective = dd.Objective,
            Explanation = dd.Explanation,
            Hint = dd.Hint,
            Reference = dd.Reference,
            SourceLabel = dd.SourceLabel,
            TargetLabel = dd.TargetLabel,
            Source = Shuffle(dd.Source, rng),
            Targets = dd.Targets,
            Answer = dd.Answer
        },
        _ => item
    };

    private static MultipleChoiceItem RandomiseChoices(MultipleChoiceItem mc, Random rng)
    {
        const string keys = "ABCDEFGH";
        var order = Shuffle(mc.Choices, rng);

        // Old key -> new key, assigned by the choice's new position.
        var remap = order
            .Select((c, i) => (c.Key, NewKey: keys[i].ToString()))
            .ToDictionary(x => x.Key, x => x.NewKey);

        return new MultipleChoiceItem
        {
            Id = mc.Id,
            Stem = mc.Stem,
            Exhibits = mc.Exhibits,
            Domain = mc.Domain,
            Objective = mc.Objective,
            Explanation = mc.Explanation,
            Hint = mc.Hint,
            Reference = mc.Reference,
            Choices = [.. order.Select((c, i) => new Choice(keys[i].ToString(), c.Text))],
            Answer = [.. mc.Answer.Select(k => remap[k]).Order()],
            Rationales = mc.Rationales.ToDictionary(kv => remap[kv.Key], kv => kv.Value)
        };
    }
}
