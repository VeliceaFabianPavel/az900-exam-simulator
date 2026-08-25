using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// Local question bank for the AZ-900 practice forms.
///
/// Every item is original wording authored against the factual content of
/// <i>Microsoft Certified Azure Fundamentals Study Guide: Exam AZ-900, 2nd Edition</i>
/// (Jim Boyce, Sybex). No question, answer, or explanation is reproduced from the
/// book; the book is used only as the source of the underlying Azure facts, and
/// each item carries a chapter reference so an answer can be verified.
///
/// Scope: chapter 4 (core networking) and all performance-based lab content are
/// deliberately excluded, as are case studies.
/// </summary>
public static partial class QuestionBank
{
    private const string Keys = "ABCDEFGH";

    public static IReadOnlyList<Item> All { get; } =
    [
        .. CloudConcepts(),
        .. ArchitectureAndServices(),
        .. ManagementAndGovernance()
    ];

    public static IReadOnlyList<Item> ByDomain(ExamDomain d) =>
        [.. All.Where(i => i.Domain == d)];

    // ------------------------------------------------------------ authoring helpers

    /// <summary>Splits a blank-line separated block into paragraphs.</summary>
    private static string Para(string text) =>
        string.Concat(text
            .Replace("\r\n", "\n")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(p => $"<p>{p.Trim()}</p>"));

    /// <summary>Single-answer or multi-answer multiple choice. <paramref name="answer"/> is like "B" or "B,D".</summary>
    private static MultipleChoiceItem Mc(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string[] choices, string answer, string explanation) => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            Choices = [.. choices.Select((t, i) => new Choice(Keys[i].ToString(), t))],
            Answer = [.. answer.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)],
            Explanation = Para(explanation)
        };

    /// <summary>Ordered build list. <paramref name="answer"/> lists source indexes (1-based) in order.</summary>
    private static BuildListItem Build(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string sourceLabel, string[] source, int[] answer, string explanation) => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            SourceLabel = sourceLabel,
            Source = [.. source.Select((t, i) => new Choice($"s{i + 1}", t))],
            Answer = [.. answer.Select(i => $"s{i}")],
            Explanation = Para(explanation)
        };

    /// <summary>
    /// Drag and drop. <paramref name="pairs"/> maps a target label to the 1-based index
    /// of the correct entry in <paramref name="source"/>.
    /// </summary>
    private static DragDropItem Drag(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string sourceLabel, string[] source,
        (string Target, int SourceIndex)[] pairs, string explanation) => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            SourceLabel = sourceLabel,
            Source = [.. source.Select((t, i) => new Choice($"v{i + 1}", t))],
            Targets = [.. pairs.Select((p, i) => new DropTarget($"t{i + 1}", p.Target))],
            Answer = pairs
                .Select((p, i) => (Key: $"t{i + 1}", Val: $"v{p.SourceIndex}"))
                .ToDictionary(x => x.Key, x => x.Val),
            Explanation = Para(explanation)
        };

    /// <summary>
    /// Drop-down "complete each statement" item. Each row supplies its options and
    /// the 1-based index of the correct option.
    /// </summary>
    private static ActiveScreenItem Dropdowns(
        string id, ExamDomain domain, string objective, string reference,
        string stem, (string Label, string[] Options, int Correct)[] rows, string explanation) => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            Rows = [.. rows.Select((r, i) => new DropdownRow($"r{i + 1}", r.Label, r.Options))],
            Answer = rows
                .Select((r, i) => (Key: $"r{i + 1}", Val: r.Options[r.Correct - 1]))
                .ToDictionary(x => x.Key, x => x.Val),
            Explanation = Para(explanation)
        };

    /// <summary>Yes/No statement grid. <paramref name="statements"/> pairs text with the keyed answer.</summary>
    private static MultisourceItem YesNo(
        string id, ExamDomain domain, string objective, string reference,
        string stem, (string Text, bool Yes)[] statements, string explanation) => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            Statements = [.. statements.Select((s, i) => new Statement($"s{i + 1}", s.Text))],
            Answer = statements
                .Select((s, i) => (Key: $"s{i + 1}", s.Yes))
                .ToDictionary(x => x.Key, x => x.Yes),
            Explanation = Para(explanation)
        };

    /// <summary>
    /// Hot area item. Spots are laid out automatically as a single row of equal
    /// panels; <paramref name="answer"/> is the 1-based index of the correct panel.
    /// </summary>
    private static HotAreaItem Hot(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string screenTitle, string[] spots, int answer, string explanation)
    {
        var n = spots.Length;
        var gap = 3.0;
        var w = (100.0 - gap * (n + 1)) / n;

        return new HotAreaItem
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            ScreenTitle = screenTitle,
            ImageAlt = screenTitle,
            Spots = [.. spots.Select((s, i) =>
                new HotSpot($"h{i + 1}", s, gap + i * (w + gap), 14, w, 68))],
            Answer = $"h{answer}",
            Explanation = Para(explanation)
        };
    }
}
