using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>One of the ten practice forms. The seed fixes which bank items the form draws.</summary>
public sealed record ExamForm(int Number, string Title, string Focus, int Seed);

/// <summary>
/// Builds the ten practice forms from <see cref="QuestionBank"/>. Item selection is
/// deterministic per form, so exam 3 always contains the same 50 questions, while the
/// presentation order and the order of answer options are reshuffled on every attempt.
/// </summary>
public static class ExamCatalog
{
    public const int QuestionCount = 50;

    public static IReadOnlyList<ExamForm> Forms { get; } =
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

    public static ExamForm ById(int number) =>
        Forms.FirstOrDefault(f => f.Number == number) ?? Forms[0];

    /// <summary>
    /// Selects the form's questions, stratified across the three domains using the
    /// published blueprint weighting, then randomises presentation for this attempt.
    /// </summary>
    public static IReadOnlyList<Item> Build(ExamForm form)
    {
        var picker = new Random(form.Seed);
        List<Item> selected = [];

        foreach (var domain in ExamDomainInfo.All)
        {
            var pool = QuestionBank.ByDomain(domain);
            selected.AddRange(Sample(pool, domain.ItemsPerForm(), picker));
        }

        // Top up in the unlikely event a domain pool is short of its quota.
        if (selected.Count < QuestionCount)
        {
            var chosen = selected.Select(i => i.Id).ToHashSet();
            var rest = QuestionBank.All.Where(i => !chosen.Contains(i.Id)).ToList();
            selected.AddRange(Sample(rest, QuestionCount - selected.Count, picker));
        }

        // A fresh seed per attempt, so the same form feels different each time.
        var shuffler = new Random();
        return [.. Shuffle(selected, shuffler).Select(i => Randomise(i, shuffler))];
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
            Reference = mc.Reference,
            Choices = [.. order.Select((c, i) => new Choice(keys[i].ToString(), c.Text))],
            Answer = [.. mc.Answer.Select(k => remap[k]).Order()],
            Rationales = mc.Rationales.ToDictionary(kv => remap[kv.Key], kv => kv.Value)
        };
    }
}
