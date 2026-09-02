using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// Banca de intrebari pentru cursul de Java, in limba romana.
///
/// Toate intrebarile sunt formulate original, pe baza continutului factual din
/// <i>Introduction to Java Programming</i> (Danciu Gabriel Mihail, 2023), capitolele 2-8.
/// Nicio intrebare, varianta de raspuns sau explicatie nu reproduce text din carte; cartea este
/// folosita doar ca sursa a faptelor despre Java, iar fiecare intrebare poarta capitolul si
/// paginile unde materialul poate fi verificat.
///
/// Formate folosite: alegere simpla, alegere multipla, potrivire prin tragere si liste derulante.
/// Nu se folosesc intrebari de tip zona activa.
/// </summary>
public static partial class JavaBank
{
    private const string Keys = "ABCDEFGH";

    public static IReadOnlyList<Item> All { get; } =
    [
        .. Chapter2(),
        .. Chapter3(),
        .. Chapter4(),
        .. Chapter5(),
        .. Chapter6(),
        .. Chapter7(),
        .. Chapter8()
    ];

    public static IReadOnlyList<Item> ByDomain(ExamDomain d) =>
        [.. All.Where(i => i.Domain == d)];

    // ------------------------------------------------------------ ajutoare de redactare

    /// <summary>Imparte un bloc separat prin linii goale in paragrafe.</summary>
    private static string Para(string text) =>
        string.Concat(text
            .Replace("\r\n", "\n")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(p => $"<p>{p.Trim()}</p>"));

    /// <summary>Formateaza un fragment de cod ca bloc monospatiat.</summary>
    private static string Code(string code) =>
        "<pre class=\"code\"><code>" +
        code.Replace("\r\n", "\n").Trim('\n')
            .Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") +
        "</code></pre>";

    /// <summary>
    /// Alegere simpla sau multipla. <paramref name="answer"/> arata ca "B" sau "B,D".
    /// </summary>
    private static MultipleChoiceItem Mc(
        string id, ExamDomain domain, string objective, string reference,
        string stem, string[] choices, string answer, string explanation,
        string hint = "", string code = "") => new()
        {
            Id = id,
            Domain = domain,
            Objective = objective,
            Reference = reference,
            Stem = Para(stem) + (string.IsNullOrWhiteSpace(code) ? "" : Code(code)),
            Choices = [.. choices.Select((t, i) => new Choice(Keys[i].ToString(), t))],
            Answer = [.. answer.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)],
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>
    /// Potrivire prin tragere. <paramref name="pairs"/> leaga eticheta tintei de indexul
    /// (de la 1) al variantei corecte din <paramref name="source"/>.
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
            TargetLabel = "Zona de raspuns",
            Source = [.. source.Select((t, i) => new Choice($"v{i + 1}", t))],
            Targets = [.. pairs.Select((p, i) => new DropTarget($"t{i + 1}", p.Target))],
            Answer = pairs
                .Select((p, i) => (Key: $"t{i + 1}", Val: $"v{p.SourceIndex}"))
                .ToDictionary(x => x.Key, x => x.Val),
            Explanation = Para(explanation),
            Hint = hint
        };

    /// <summary>
    /// Liste derulante: completeaza fiecare afirmatie. Fiecare rand isi da variantele si
    /// indexul (de la 1) al variantei corecte.
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
}
