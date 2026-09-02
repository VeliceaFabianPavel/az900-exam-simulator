using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// Ariile punctate ale cursului de Java. Fiecare arie corespunde unui capitol din carte, iar
/// cotele adunate dau cele 20 de intrebari ale unui test.
/// </summary>
public static class JavaDomains
{
    public static readonly ExamDomain Ch2 = new(
        "java-2", "Prezentare generala a limbajului Java", "Prezentare generala", 3, "15%");

    public static readonly ExamDomain Ch3 = new(
        "java-3", "Sintaxa si structura de baza", "Sintaxa de baza", 3, "15%");

    public static readonly ExamDomain Ch4 = new(
        "java-4", "Programare orientata pe obiecte", "POO", 3, "15%");

    public static readonly ExamDomain Ch5 = new(
        "java-5", "Programare orientata pe obiecte avansata", "POO avansata", 2, "10%");

    public static readonly ExamDomain Ch6 = new(
        "java-6", "Colectii in Java", "Colectii", 3, "15%");

    public static readonly ExamDomain Ch7 = new(
        "java-7", "Concepte avansate de programare Java", "Concepte avansate", 4, "20%");

    public static readonly ExamDomain Ch8 = new(
        "java-8", "Colectii Java in detaliu", "Colectii avansate", 2, "10%");

    public static readonly ExamDomain[] All = [Ch2, Ch3, Ch4, Ch5, Ch6, Ch7, Ch8];
}
