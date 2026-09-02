using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// Tracks which lessons have been marked as read, and which module and lesson the reader is
/// currently on. State lives for the browser session only, in step with
/// <see cref="ExamSession"/>, which also keeps an attempt in memory.
/// </summary>
public sealed class TrainingProgress
{
    private readonly HashSet<string> _read = [];

    public event Action? Changed;

    /// <summary>The course whose modules are being read. Set when a course is opened.</summary>
    public Course Course { get; private set; } = CourseCatalog.Default;

    public IReadOnlyList<TrainingModule> Modules => Course.Modules;

    /// <summary>Switches course, clearing any position held in the previous one.</summary>
    public void UseCourse(Course course)
    {
        if (Course == course)
        {
            return;
        }

        Course = course;
        CurrentModule = null;
        CurrentLesson = null;
        Changed?.Invoke();
    }

    public TrainingModule? CurrentModule { get; private set; }

    public Lesson? CurrentLesson { get; private set; }

    public bool IsRead(Lesson lesson) => _read.Contains(lesson.Id);

    public int ReadCount => _read.Count;

    public int TotalLessons => Modules.Sum(m => m.LessonCount);

    public double PercentRead => TotalLessons == 0
        ? 0
        : (double)ReadCount / TotalLessons * 100;

    public int ReadCountIn(TrainingModule module) =>
        module.Lessons.Count(l => _read.Contains(l.Id));

    public bool IsComplete(TrainingModule module) =>
        module.Lessons.Count > 0 && module.Lessons.All(l => _read.Contains(l.Id));

    public void Open(TrainingModule module, Lesson? lesson = null)
    {
        CurrentModule = module;
        CurrentLesson = lesson ?? module.Lessons.FirstOrDefault();
        Changed?.Invoke();
    }

    public void Open(Lesson lesson)
    {
        CurrentModule = TrainingCatalog.ModuleOf(lesson);
        CurrentLesson = lesson;
        Changed?.Invoke();
    }

    public void CloseLesson()
    {
        CurrentLesson = null;
        Changed?.Invoke();
    }

    public void BackToModules()
    {
        CurrentModule = null;
        CurrentLesson = null;
        Changed?.Invoke();
    }

    public void SetRead(Lesson lesson, bool read)
    {
        if (read)
        {
            _read.Add(lesson.Id);
        }
        else
        {
            _read.Remove(lesson.Id);
        }
        Changed?.Invoke();
    }

    public void ToggleRead(Lesson lesson) => SetRead(lesson, !IsRead(lesson));

    /// <summary>Moves to the next lesson in the module, or returns false at the end.</summary>
    public bool Advance()
    {
        if (CurrentModule is null || CurrentLesson is null)
        {
            return false;
        }

        var i = CurrentModule.Lessons.ToList().IndexOf(CurrentLesson);
        if (i < 0 || i >= CurrentModule.Lessons.Count - 1)
        {
            return false;
        }

        CurrentLesson = CurrentModule.Lessons[i + 1];
        Changed?.Invoke();
        return true;
    }

    public bool Retreat()
    {
        if (CurrentModule is null || CurrentLesson is null)
        {
            return false;
        }

        var i = CurrentModule.Lessons.ToList().IndexOf(CurrentLesson);
        if (i <= 0)
        {
            return false;
        }

        CurrentLesson = CurrentModule.Lessons[i - 1];
        Changed?.Invoke();
        return true;
    }

    public void Reset()
    {
        _read.Clear();
        CurrentModule = null;
        CurrentLesson = null;
        Changed?.Invoke();
    }
}
