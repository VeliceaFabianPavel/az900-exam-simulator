using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// The training modules, one per in-scope chapter of the study guide.
///
/// Chapter 4 (core networking) and the performance-based lab content are excluded, matching
/// the scope already used by <see cref="QuestionBank"/>, so the modules and the question bank
/// cover exactly the same ground.
///
/// All lesson wording is original. The study guide supplies the underlying Azure facts and
/// each lesson carries the pages it was written against; nothing is reproduced from the book.
/// </summary>
public static partial class TrainingCatalog
{
    public static IReadOnlyList<TrainingModule> Modules { get; } =
    [
        CloudConceptsModule(),
        CoreServicesModule(),
        StorageModule(),
        IdentityModule(),
        GovernanceModule(),
        PricingModule(),
        ToolsModule()
    ];

    public static IReadOnlyList<Lesson> AllLessons { get; } =
        [.. Modules.SelectMany(m => m.Lessons)];

    public static TrainingModule? ById(string id) =>
        Modules.FirstOrDefault(m => m.Id == id);

    public static TrainingModule? ModuleOf(Lesson lesson) =>
        Modules.FirstOrDefault(m => m.Lessons.Contains(lesson));

    /// <summary>
    /// Bank questions that practise a lesson, matched on the skills-outline bullet both sides
    /// already carry.
    /// </summary>
    public static IReadOnlyList<Item> QuestionsFor(Lesson lesson) =>
        [.. QuestionBank.All.Where(i => i.Objective == lesson.Objective)];

    /// <summary>Bank questions drawn from the same chapter as a module.</summary>
    public static IReadOnlyList<Item> QuestionsFor(TrainingModule module) =>
        [.. QuestionBank.All.Where(i => i.Reference == module.Reference)];

    /// <summary>
    /// Lessons that teach the material a question tests, matched on the skills-outline bullet
    /// both sides carry.
    /// </summary>
    /// <remarks>
    /// Several lessons can share one objective, so they are ordered by how strongly they match
    /// the question. The most relevant lesson comes first.
    /// </remarks>
    public static IReadOnlyList<Lesson> LessonsFor(Item item) =>
    [
        .. AllLessons
            .Where(l => l.Objective == item.Objective)
            .Select(l => (Lesson: l, Score: Relevance(item, l)))
            .OrderByDescending(x => x.Score)
            .Select(x => x.Lesson)
    ];

    /// <summary>The strongest point match between a question and a lesson.</summary>
    private static int Relevance(Item item, Lesson lesson)
    {
        var wanted = QuestionTerms(item);
        return lesson.Points.Count == 0
            ? 0
            : lesson.Points.Max(p => Terms(p).Count(wanted.Contains));
    }

    private static HashSet<string> QuestionTerms(Item item) =>
        [.. Terms(Strip(item.Stem))
            .Concat(Terms(Strip(item.Explanation)))
            .Concat(item.CorrectAnswerLines.SelectMany(Terms))];

    /// <summary>
    /// Indexes of the lesson points most relevant to a question, so a reader sent here from a
    /// question lands on the right sentences rather than the top of the page.
    ///
    /// Scored on shared distinctive terms. Nothing is authored per question, so a weak match
    /// simply highlights less rather than highlighting the wrong thing.
    /// </summary>
    public static IReadOnlyList<int> HighlightsFor(Item item, Lesson lesson)
    {
        var wanted = QuestionTerms(item);

        if (wanted.Count == 0)
        {
            return [];
        }

        var scored = lesson.Points
            .Select((text, index) =>
            {
                var terms = Terms(text).ToHashSet();
                var shared = terms.Count == 0 ? 0 : terms.Count(wanted.Contains);
                return (Index: index, Score: shared);
            })
            .Where(x => x.Score >= 3)
            .OrderByDescending(x => x.Score)
            .Take(3)
            .Select(x => x.Index)
            .Order()
            .ToList();

        return scored;
    }

    /// <summary>Removes the paragraph markup the bank stores its prose in.</summary>
    private static string Strip(string html) =>
        html.Replace("</p><p>", " ")
            .Replace("<p>", "")
            .Replace("</p>", "")
            .Replace("<br />", " ");

    private static readonly HashSet<string> Noise =
    [
        "that", "this", "with", "from", "which", "when", "what", "have", "does", "than",
        "then", "them", "they", "there", "their", "would", "could", "should", "because",
        "into", "onto", "over", "under", "each", "every", "some", "only", "also", "more",
        "most", "less", "least", "much", "many", "same", "other", "another", "such",
        "being", "been", "your", "yours", "will", "shall", "must", "make", "makes",
        "made", "take", "takes", "used", "uses", "using", "user", "users", "answer",
        "question", "correct", "option", "options", "select", "choose", "following",
        "statement", "statements", "describe", "describes", "example", "examples",
        "azure", "microsoft", "service", "services", "resource", "resources"
    ];

    /// <summary>Distinctive lowercase word stems from a fragment of prose.</summary>
    private static IEnumerable<string> Terms(string text)
    {
        var buffer = new System.Text.StringBuilder();
        List<string> words = [];

        foreach (var ch in text)
        {
            if (char.IsLetter(ch))
            {
                buffer.Append(char.ToLowerInvariant(ch));
            }
            else if (buffer.Length > 0)
            {
                words.Add(buffer.ToString());
                buffer.Clear();
            }
        }
        if (buffer.Length > 0)
        {
            words.Add(buffer.ToString());
        }

        return words
            .Where(w => w.Length >= 5 && !Noise.Contains(w))
            .Select(w => w.EndsWith('s') && w.Length > 5 ? w[..^1] : w)
            .Distinct();
    }

    // ---------------------------------------------------------------- authoring helpers

    /// <summary>Splits a blank-line separated block into paragraphs.</summary>
    private static string Para(string text) =>
        string.Concat(text
            .Replace("\r\n", "\n")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(p => $"<p>{p.Trim()}</p>"));
}
