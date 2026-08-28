namespace MockExam.Fluent.Models;

/// <summary>
/// One study topic inside a <see cref="TrainingModule"/>.
///
/// Lessons are original wording written against the factual content of the study guide.
/// No passage is reproduced from the book; <see cref="Pages"/> records where the
/// underlying material sits so a claim can be checked against the source.
/// </summary>
public sealed class Lesson
{
    public required string Id { get; init; }

    public required string Title { get; init; }

    /// <summary>
    /// The skills-outline bullet this lesson teaches. Matches <see cref="Item.Objective"/>,
    /// which is how a lesson finds its practice questions.
    /// </summary>
    public required string Objective { get; init; }

    /// <summary>Pages in the study guide covering this topic, for example "p60-64".</summary>
    public string Pages { get; init; } = "";

    /// <summary>Opening prose. Already HTML, one or more paragraphs.</summary>
    public string Intro { get; init; } = "";

    /// <summary>The facts to learn, one idea per entry.</summary>
    public IReadOnlyList<string> Points { get; init; } = [];

    /// <summary>
    /// Distinctions the exam turns on, phrased as the trap and the resolution.
    /// </summary>
    public IReadOnlyList<string> Essentials { get; init; } = [];

    /// <summary>Optional two-column comparison rendered as a table.</summary>
    public LessonTable? Table { get; init; }
}

/// <summary>A small comparison table inside a lesson.</summary>
public sealed record LessonTable(
    string Caption,
    IReadOnlyList<string> Headers,
    IReadOnlyList<IReadOnlyList<string>> Rows);

/// <summary>
/// One chapter of the study guide, presented as a sequence of lessons. Each module maps to
/// exactly one <see cref="Item.Reference"/> value, which is how it finds its questions.
/// </summary>
public sealed class TrainingModule
{
    public required string Id { get; init; }

    public required string Title { get; init; }

    /// <summary>Scored area of the skills outline this chapter belongs to.</summary>
    public required ExamDomain Domain { get; init; }

    /// <summary>Chapter label, matching the <c>Reference</c> carried by its questions.</summary>
    public required string Reference { get; init; }

    /// <summary>Pages the chapter spans in the study guide.</summary>
    public string Pages { get; init; } = "";

    /// <summary>One sentence on what the chapter is for.</summary>
    public string Blurb { get; init; } = "";

    public IReadOnlyList<Lesson> Lessons { get; init; } = [];

    public int LessonCount => Lessons.Count;
}
