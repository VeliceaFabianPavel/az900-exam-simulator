namespace MockExam.Fluent.Services;

/// <summary>
/// The course the candidate is currently working in. Shared by the exam page and the study
/// page so the choice survives navigation between them.
/// </summary>
public sealed class CourseState
{
    public event Action? Changed;

    public Course Current { get; private set; } = CourseCatalog.Default;

    /// <summary>True until a course has been picked, which is what shows the course chooser.</summary>
    public bool Chosen { get; private set; }

    public Ui T => Ui.For(Current.Language);

    public void Select(Course course)
    {
        Current = course;
        Chosen = true;
        Changed?.Invoke();
    }

    public void Clear()
    {
        Chosen = false;
        Changed?.Invoke();
    }
}
