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
        string stem, string[] choices, string answer, string explanation,
        string hint = "") => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            Choices = [.. choices.Select((t, i) => new Choice(Keys[i].ToString(), t))],
            Answer = [.. answer.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)],
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>Ordered build list. <paramref name="answer"/> lists source indexes (1-based) in order.</summary>
    private static BuildListItem Build(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string sourceLabel, string[] source, int[] answer, string explanation,
        string hint = "") => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            SourceLabel = sourceLabel,
            Source = [.. source.Select((t, i) => new Choice($"s{i + 1}", t))],
            Answer = [.. answer.Select(i => $"s{i}")],
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>
    /// Drag and drop. <paramref name="pairs"/> maps a target label to the 1-based index
    /// of the correct entry in <paramref name="source"/>.
    /// </summary>
    private static DragDropItem Drag(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string sourceLabel, string[] source,
        (string Target, int SourceIndex)[] pairs, string explanation,
        string hint = "") => new()
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
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>
    /// Drop-down "complete each statement" item. Each row supplies its options and
    /// the 1-based index of the correct option.
    /// </summary>
    private static ActiveScreenItem Dropdowns(
        string id, ExamDomain domain, string objective, string reference,
        string stem, (string Label, string[] Options, int Correct)[] rows, string explanation,
        string hint = "") => new()
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
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>Yes/No statement grid. <paramref name="statements"/> pairs text with the keyed answer.</summary>
    private static MultisourceItem YesNo(
        string id, ExamDomain domain, string objective, string reference,
        string stem, (string Text, bool Yes)[] statements, string explanation,
        string hint = "") => new()
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
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>
    /// Hot area drawn over a diagram, the way the live exam presents one. Each region is a
    /// transparent rectangle given as percentages of the image box, so the graphic supplies
    /// the labels and the candidate has to read it rather than pick from a list.
    /// <paramref name="answer"/> is the 1-based index of the correct region.
    /// </summary>
    private static HotAreaItem HotImage(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string screenTitle, string image, string imageAlt,
        (string Label, double X, double Y, double W, double H)[] regions,
        int answer, string explanation, string hint = "") => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            ScreenTitle = screenTitle,
            ImageSrc = image,
            ImageAlt = imageAlt,
            Spots = [.. regions.Select((r, i) =>
                new HotSpot($"h{i + 1}", r.Label, r.X, r.Y, r.W, r.H))],
            Answer = $"h{answer}",
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>
    /// Hot area whose spots are concentric rectangles, listed outermost first. Each level is
    /// inset from the one containing it and keeps a band clear at the top for its own label,
    /// so the nesting is readable and every ring stays clickable.
    /// <paramref name="answer"/> is the 1-based index of the correct ring.
    /// </summary>
    private static HotAreaItem HotNested(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string screenTitle, string[] spots, int answer, string explanation,
        string hint = "")
    {
        var levels = Math.Max(spots.Length - 1, 1);
        var dx = 14.0 / levels;       // horizontal inset per level, each side
        var dTop = 46.0 / levels;     // top inset, which doubles as the label band
        var dBottom = 18.0 / levels;

        return new HotAreaItem
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem),
            ScreenTitle = screenTitle,
            ImageAlt = screenTitle,
            Nested = true,
            Spots = [.. spots.Select((s, i) => new HotSpot(
                $"h{i + 1}", s,
                Math.Round(3 + i * dx, 2),
                Math.Round(8 + i * dTop, 2),
                Math.Round(94 - 2 * i * dx, 2),
                Math.Round(84 - i * (dTop + dBottom), 2)))],
            Answer = $"h{answer}",
            Explanation = Para(explanation),
            Hint = hint
        };
    }

}
