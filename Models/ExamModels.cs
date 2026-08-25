namespace MockExam.Fluent.Models;

public enum ItemType
{
    Display,
    MultipleChoice,
    BuildList,
    DragDrop,
    ActiveScreen,
    HotArea,
    Multisource
}

/// <summary>
/// The three scored areas of the AZ-900 skills outline. Weightings follow the
/// published exam blueprint and drive how each practice form is assembled.
/// </summary>
public enum ExamDomain
{
    /// <summary>Describe cloud concepts (25-30%).</summary>
    CloudConcepts,
    /// <summary>Describe Azure architecture and services (35-40%).</summary>
    ArchitectureAndServices,
    /// <summary>Describe Azure management and governance (30-35%).</summary>
    ManagementAndGovernance
}

public static class ExamDomainInfo
{
    public static string Name(this ExamDomain d) => d switch
    {
        ExamDomain.CloudConcepts => "Describe cloud concepts",
        ExamDomain.ArchitectureAndServices => "Describe Azure architecture and services",
        _ => "Describe Azure management and governance"
    };

    public static string ShortName(this ExamDomain d) => d switch
    {
        ExamDomain.CloudConcepts => "Cloud concepts",
        ExamDomain.ArchitectureAndServices => "Architecture and services",
        _ => "Management and governance"
    };

    /// <summary>Share of a 50-item form, matching the published blueprint weighting.</summary>
    public static int ItemsPerForm(this ExamDomain d) => d switch
    {
        ExamDomain.CloudConcepts => 14,
        ExamDomain.ArchitectureAndServices => 19,
        _ => 17
    };

    public static string Weighting(this ExamDomain d) => d switch
    {
        ExamDomain.CloudConcepts => "25-30%",
        ExamDomain.ArchitectureAndServices => "35-40%",
        _ => "30-35%"
    };

    public static readonly ExamDomain[] All =
        [ExamDomain.CloudConcepts, ExamDomain.ArchitectureAndServices, ExamDomain.ManagementAndGovernance];
}

/// <summary>An exhibit tab rendered above or beside the question stem.</summary>
public sealed record Exhibit(string Title, string Html);

public abstract class Item
{
    public required string Id { get; init; }
    public abstract ItemType Type { get; }
    public string Stem { get; init; } = "";
    public IReadOnlyList<Exhibit> Exhibits { get; init; } = [];

    /// <summary>Items that carry no response (intro screens).</summary>
    public virtual bool Scored => true;

    public ExamDomain Domain { get; init; }

    /// <summary>The skills-outline bullet this item maps to, shown on the score report.</summary>
    public string Objective { get; init; } = "";

    /// <summary>Why the keyed answer is right, shown after the exam ends.</summary>
    public string Explanation { get; init; } = "";

    /// <summary>Where the supporting material lives in the study guide.</summary>
    public string Reference { get; init; } = "";

    /// <summary>True when the candidate response matches the answer key exactly.</summary>
    public virtual bool IsCorrect(Response r) => false;

    /// <summary>Human readable answer key for the review panel.</summary>
    public virtual IReadOnlyList<string> CorrectAnswerLines => [];

    /// <summary>Human readable rendering of what the candidate chose.</summary>
    public virtual IReadOnlyList<string> ResponseLines(Response r) => [];
}

public sealed class DisplayItem : Item
{
    public override ItemType Type => ItemType.Display;
    public override bool Scored => false;
    public string Title { get; init; } = "";
    public IReadOnlyList<(string Label, string Value)> Facts { get; init; } = [];
}

public sealed record Choice(string Key, string Text);

public sealed class MultipleChoiceItem : Item
{
    public override ItemType Type => ItemType.MultipleChoice;
    public IReadOnlyList<Choice> Choices { get; init; } = [];

    /// <summary>Keys of the correct choices. Drives <see cref="SelectCount"/>.</summary>
    public IReadOnlyList<string> Answer { get; init; } = [];

    /// <summary>Optional per-choice feedback keyed by choice key.</summary>
    public IReadOnlyDictionary<string, string> Rationales { get; init; } =
        new Dictionary<string, string>();

    public int SelectCount => Answer.Count == 0 ? 1 : Answer.Count;

    public override bool IsCorrect(Response r) => r.Selected.SetEquals(Answer);

    public override IReadOnlyList<string> CorrectAnswerLines =>
        [.. Answer.Select(Text)];

    public override IReadOnlyList<string> ResponseLines(Response r) =>
        [.. Choices.Where(c => r.Selected.Contains(c.Key)).Select(c => Text(c.Key))];

    private string Text(string key) =>
        Choices.FirstOrDefault(c => c.Key == key) is { } c ? $"{c.Key}. {c.Text}" : key;
}

public sealed class BuildListItem : Item
{
    public override ItemType Type => ItemType.BuildList;
    public string SourceLabel { get; init; } = "Actions";
    public string AnswerLabel { get; init; } = "Answer Area";
    public IReadOnlyList<Choice> Source { get; init; } = [];

    /// <summary>Source keys in the required order. Drives <see cref="AnswerSlots"/>.</summary>
    public IReadOnlyList<string> Answer { get; init; } = [];

    public int AnswerSlots => Answer.Count;

    public override bool IsCorrect(Response r) => r.Ordered.SequenceEqual(Answer);

    public override IReadOnlyList<string> CorrectAnswerLines =>
        [.. Answer.Select((k, i) => $"{i + 1}. {Text(k)}")];

    public override IReadOnlyList<string> ResponseLines(Response r) =>
        [.. r.Ordered.Select((k, i) => $"{i + 1}. {Text(k)}")];

    private string Text(string key) =>
        Source.FirstOrDefault(c => c.Key == key)?.Text ?? key;
}

public sealed record DropTarget(string Key, string Label);

public sealed class DragDropItem : Item
{
    public override ItemType Type => ItemType.DragDrop;
    public string SourceLabel { get; init; } = "Values";
    public string TargetLabel { get; init; } = "Answer Area";
    public IReadOnlyList<Choice> Source { get; init; } = [];
    public IReadOnlyList<DropTarget> Targets { get; init; } = [];

    /// <summary>Target key to source key.</summary>
    public IReadOnlyDictionary<string, string> Answer { get; init; } =
        new Dictionary<string, string>();

    public override bool IsCorrect(Response r) =>
        Targets.All(t => r.Map.TryGetValue(t.Key, out var v)
                         && Answer.TryGetValue(t.Key, out var k) && v == k);

    public override IReadOnlyList<string> CorrectAnswerLines =>
        [.. Targets.Select(t => $"{t.Label} \u2192 {Text(Answer.GetValueOrDefault(t.Key))}")];

    public override IReadOnlyList<string> ResponseLines(Response r) =>
        [.. Targets.Select(t => $"{t.Label} \u2192 {Text(r.Map.GetValueOrDefault(t.Key))}")];

    private string Text(string? key) => key is null
        ? "(not answered)"
        : Source.FirstOrDefault(c => c.Key == key)?.Text ?? key;
}

public sealed record DropdownRow(string Key, string Label, IReadOnlyList<string> Options);

/// <summary>
/// Active screen: a simulated dialog image with dropdowns positioned over it.
/// X / Y / W are percentages of the image box.
/// </summary>
public sealed record ScreenField(string Key, string Label, IReadOnlyList<string> Options,
    double X, double Y, double W);

public sealed class ActiveScreenItem : Item
{
    public override ItemType Type => ItemType.ActiveScreen;
    public IReadOnlyList<DropdownRow> Rows { get; init; } = [];
    public string ScreenTitle { get; init; } = "";
    public IReadOnlyList<ScreenField> Fields { get; init; } = [];

    /// <summary>Row or field key to the exact option text that is correct.</summary>
    public IReadOnlyDictionary<string, string> Answer { get; init; } =
        new Dictionary<string, string>();

    private IEnumerable<(string Key, string Label)> Slots =>
        Rows.Select(r => (r.Key, r.Label)).Concat(Fields.Select(f => (f.Key, f.Label)));

    public override bool IsCorrect(Response r) =>
        Slots.All(s => r.Map.TryGetValue(s.Key, out var v)
                       && Answer.TryGetValue(s.Key, out var k) && v == k);

    public override IReadOnlyList<string> CorrectAnswerLines =>
        [.. Slots.Select(s => $"{s.Label} \u2192 {Answer.GetValueOrDefault(s.Key, "?")}")];

    public override IReadOnlyList<string> ResponseLines(Response r) =>
        [.. Slots.Select(s => $"{s.Label} \u2192 {r.Map.GetValueOrDefault(s.Key) ?? "(not answered)"}")];
}

public sealed record HotSpot(string Key, string Label, double X, double Y, double W, double H);

public sealed class HotAreaItem : Item
{
    public override ItemType Type => ItemType.HotArea;
    public string ImageAlt { get; init; } = "";
    public string ScreenTitle { get; init; } = "Work area";
    public IReadOnlyList<HotSpot> Spots { get; init; } = [];

    /// <summary>Key of the single correct hotspot.</summary>
    public string Answer { get; init; } = "";

    public override bool IsCorrect(Response r) =>
        r.Selected.Count == 1 && r.Selected.Contains(Answer);

    public override IReadOnlyList<string> CorrectAnswerLines => [Label(Answer)];

    public override IReadOnlyList<string> ResponseLines(Response r) =>
        [.. r.Selected.Select(Label)];

    private string Label(string key) =>
        Spots.FirstOrDefault(s => s.Key == key)?.Label ?? key;
}

public sealed record Statement(string Key, string Text);

public sealed class MultisourceItem : Item
{
    /// <summary>Tokens written into the response map by the Yes / No renderer.</summary>
    public const string YesToken = "yes";
    public const string NoToken = "no";

    public override ItemType Type => ItemType.Multisource;
    public string YesLabel { get; init; } = "Yes";
    public string NoLabel { get; init; } = "No";
    public IReadOnlyList<Statement> Statements { get; init; } = [];

    /// <summary>Statement key to true when the answer is Yes.</summary>
    public IReadOnlyDictionary<string, bool> Answer { get; init; } =
        new Dictionary<string, bool>();

    public override bool IsCorrect(Response r) =>
        Statements.All(s => r.Map.TryGetValue(s.Key, out var v)
                            && Answer.TryGetValue(s.Key, out var k)
                            && v == (k ? YesToken : NoToken));

    public override IReadOnlyList<string> CorrectAnswerLines =>
        [.. Statements.Select(s =>
            $"{s.Text} \u2192 {(Answer.GetValueOrDefault(s.Key) ? YesLabel : NoLabel)}")];

    public override IReadOnlyList<string> ResponseLines(Response r) =>
        [.. Statements.Select(s => $"{s.Text} \u2192 {Label(r.Map.GetValueOrDefault(s.Key))}")];

    private string Label(string? token) => token switch
    {
        YesToken => YesLabel,
        NoToken => NoLabel,
        _ => "(not answered)"
    };
}

/// <summary>A candidate response. Only the field matching the item type is used.</summary>
public sealed class Response
{
    public HashSet<string> Selected { get; init; } = [];
    public List<string> Ordered { get; init; } = [];
    public Dictionary<string, string> Map { get; init; } = [];

    public bool IsEmpty => Selected.Count == 0 && Ordered.Count == 0 && Map.Count == 0;

    public Response Clone() => new()
    {
        Selected = [.. Selected],
        Ordered = [.. Ordered],
        Map = new Dictionary<string, string>(Map)
    };
}

/// <summary>Per-page candidate state tracked by the delivery engine.</summary>
public sealed class ItemState
{
    public Response Response { get; set; } = new();
    public bool Marked { get; set; }
    public bool Feedback { get; set; }
}

/// <summary>One navigable screen in the assembled form.</summary>
public sealed class Page
{
    public required string Key { get; init; }
    public required Item Item { get; init; }
    public int? Seq { get; init; }
    public string Section { get; init; } = "Questions";
}

/// <summary>Scored outcome for a single item, used by the score report and review panel.</summary>
public sealed record ItemResult(
    int Number,
    Item Item,
    bool Correct,
    bool Answered,
    bool Marked,
    IReadOnlyList<string> Given,
    IReadOnlyList<string> Expected);
