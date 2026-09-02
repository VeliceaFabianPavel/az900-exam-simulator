using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// Modulele de instruire pentru cursul de Java, in limba romana.
///
/// Continutul este scris exclusiv pe baza cartii <i>Introduction to Java Programming</i>
/// (Danciu Gabriel Mihail, 2023), capitolele 2-8. Formularea este originala: cartea este sursa
/// faptelor, nu a textului, iar fiecare lectie poarta paginile pe care a fost scrisa, astfel
/// incat orice afirmatie sa poata fi verificata in sursa.
/// </summary>
public static partial class JavaTraining
{
    public static IReadOnlyList<TrainingModule> Modules { get; } =
    [
        Modul2(), Modul3(), Modul4(), Modul5(), Modul6(), Modul7(), Modul8()
    ];

    public static IReadOnlyList<Lesson> AllLessons { get; } =
        [.. Modules.SelectMany(m => m.Lessons)];

    /// <summary>Imparte un bloc separat prin linii goale in paragrafe.</summary>
    private static string P(string text) =>
        string.Concat(text
            .Replace("\r\n", "\n")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(p => $"<p>{p.Trim()}</p>"));
}
