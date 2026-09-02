using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// One subject the platform can deliver: its scored areas, its question bank, its training
/// modules, and the shape of an exam form. Everything the delivery engine used to assume about
/// AZ-900 now comes from here.
/// </summary>
public sealed class Course
{
    public required string Id { get; init; }

    /// <summary>Short name, shown on the course picker.</summary>
    public required string Name { get; init; }

    /// <summary>The certification or book this course prepares you for.</summary>
    public required string Subtitle { get; init; }

    /// <summary>One line on what the course covers.</summary>
    public string Blurb { get; init; } = "";

    /// <summary>BCP-47 language of the questions and lessons, for example "en" or "ro".</summary>
    public string Language { get; init; } = "en";

    /// <summary>The scored areas a form is stratified across.</summary>
    public required IReadOnlyList<ExamDomain> Domains { get; init; }

    public required IReadOnlyList<Item> Questions { get; init; }

    public required IReadOnlyList<TrainingModule> Modules { get; init; }

    public required IReadOnlyList<ExamForm> Forms { get; init; }

    /// <summary>Questions in one assembled form. Should equal the sum of the domain quotas.</summary>
    public int QuestionsPerForm { get; init; } = 50;

    /// <summary>Countdown for a timed attempt, in minutes.</summary>
    public int DurationMinutes { get; init; } = 45;

    /// <summary>Scaled score needed to pass, on a 1-1000 scale.</summary>
    public int PassMark { get; init; } = 700;

    /// <summary>Forms a candidate may sit in the given mode.</summary>
    public IReadOnlyList<ExamForm> FormsFor(ExamMode mode) =>
        [.. Forms.Where(f => f.OnlyMode is null || f.OnlyMode == mode)];

    public IReadOnlyList<Item> QuestionsIn(ExamDomain domain) =>
        [.. Questions.Where(q => q.Domain == domain)];
}

/// <summary>Every course the platform ships.</summary>
public static class CourseCatalog
{
    public static readonly Course Az900 = new()
    {
        Id = "az900",
        Name = "AZ-900",
        Subtitle = "Microsoft Azure Fundamentals",
        Blurb = "Cloud concepts, Azure architecture and services, management and governance.",
        Language = "en",
        Domains = AzureDomains.All,
        Questions = QuestionBank.All,
        Modules = TrainingCatalog.Modules,
        Forms = ExamCatalog.Az900Forms,
        QuestionsPerForm = 50,
        DurationMinutes = 45,
        PassMark = 700
    };

    public static readonly Course Java = new()
    {
        Id = "java",
        Name = "Java",
        Subtitle = "Introducere in programarea Java",
        Blurb = "Sintaxa, programare orientata pe obiecte, colectii si concepte avansate.",
        Language = "ro",
        Domains = JavaDomains.All,
        Questions = JavaBank.All,
        Modules = JavaTraining.Modules,
        Forms = ExamCatalog.JavaForms,
        QuestionsPerForm = 20,
        DurationMinutes = 30,
        PassMark = 700
    };

    public static IReadOnlyList<Course> All { get; } = [Az900, Java];

    public static Course ById(string id) =>
        All.FirstOrDefault(c => c.Id == id) ?? Az900;

    public static Course Default => Az900;
}
