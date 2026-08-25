using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

public enum ExamScreen
{
    /// <summary>Choose which of the ten practice forms to sit.</summary>
    Pick,
    Agreement,
    Summary,
    Ready,
    Item,
    Review,
    Score,
    /// <summary>Post-exam answer review with explanations.</summary>
    Report
}

public enum StepState
{
    Done,
    Current,
    Pending
}

/// <summary>One node in the vertical Exam Progress stepper.</summary>
public sealed record ProgressStep(string Label, StepState State);

/// <summary>Progress bucket shown in the exam header.</summary>
public sealed record ProgressGroup(string Label, int Answered, int Total, bool Stub);

/// <summary>Scored outcome for one of the three skills-outline areas.</summary>
public sealed record DomainResult(ExamDomain Domain, int Correct, int Total)
{
    public double Percent => Total == 0 ? 0 : (double)Correct / Total * 100;
}

/// <summary>
/// Delivery engine: flattens the selected form into pages, tracks responses and
/// marking, runs the countdown clock, and grades the attempt when it ends.
/// </summary>
public sealed class ExamSession
{
    public const int DurationMinutes = 45;

    /// <summary>Scaled score required to pass, on the Microsoft 1-1000 scale.</summary>
    public const int PassMark = 700;

    private readonly Dictionary<string, ItemState> _states = [];
    private DateTimeOffset _startedAt = DateTimeOffset.UtcNow;
    private DateTimeOffset? _endedAt;

    public event Action? Changed;

    public List<Page> Pages { get; } = [];
    public int Index { get; private set; }
    public ExamScreen Screen { get; private set; } = ExamScreen.Pick;
    public bool Ended { get; private set; }
    public bool Started { get; private set; }
    public ExamForm Form { get; private set; } = ExamCatalog.Forms[0];

    /// <summary>Loads a form and returns the session to its pre-exam state.</summary>
    public void SelectForm(ExamForm form)
    {
        Form = form;
        _states.Clear();
        Pages.Clear();
        Index = 0;
        Ended = false;
        Started = false;
        _endedAt = null;

        var seq = 0;
        foreach (var item in ExamCatalog.Build(form))
        {
            seq++;
            Pages.Add(new Page
            {
                Key = item.Id,
                Item = item,
                Seq = seq,
                Section = "Questions"
            });
        }

        Screen = ExamScreen.Agreement;
        Changed?.Invoke();
    }

    public void Restart()
    {
        Screen = ExamScreen.Pick;
        Changed?.Invoke();
    }

    public Page Current => Pages[Index];

    public ItemState State(string key)
    {
        if (!_states.TryGetValue(key, out var s))
        {
            s = new ItemState();
            _states[key] = s;
        }
        return s;
    }

    public ItemState CurrentState => State(Current.Key);

    public IEnumerable<Page> ScoredPages => Pages.Where(p => p.Seq is not null);

    public int TotalQuestions => ScoredPages.Count();

    public int AnsweredCount => ScoredPages.Count(IsComplete);

    public int MarkedCount => ScoredPages.Count(p => State(p.Key).Marked);

    public bool IsComplete(Page page)
    {
        var r = State(page.Key).Response;
        return page.Item switch
        {
            MultipleChoiceItem mc => r.Selected.Count == mc.SelectCount,
            BuildListItem bl => r.Ordered.Count == bl.AnswerSlots,
            DragDropItem dd => dd.Targets.All(t => r.Map.ContainsKey(t.Key)),
            ActiveScreenItem asc => asc.Rows.All(x => r.Map.ContainsKey(x.Key))
                                    && asc.Fields.All(x => r.Map.ContainsKey(x.Key)),
            HotAreaItem => r.Selected.Count > 0,
            MultisourceItem ms => ms.Statements.All(x => r.Map.ContainsKey(x.Key)),
            _ => true
        };
    }

    public void SetResponse(string key, Response response)
    {
        State(key).Response = response;
        Changed?.Invoke();
    }

    public void ResetResponse(string key)
    {
        State(key).Response = new Response();
        Changed?.Invoke();
    }

    public void ToggleMark(string key)
    {
        var s = State(key);
        s.Marked = !s.Marked;
        Changed?.Invoke();
    }

    public void ToggleFeedback(string key)
    {
        var s = State(key);
        s.Feedback = !s.Feedback;
        Changed?.Invoke();
    }

    public bool CanGoPrevious => Screen == ExamScreen.Item && Index > 0;

    public void GoTo(int index)
    {
        Index = Math.Clamp(index, 0, Pages.Count - 1);
        Screen = ExamScreen.Item;
        Changed?.Invoke();
    }

    public void Next()
    {
        switch (Screen)
        {
            case ExamScreen.Agreement:
                Screen = ExamScreen.Summary;
                break;

            case ExamScreen.Summary:
                Screen = ExamScreen.Ready;
                break;

            case ExamScreen.Ready:
                Screen = ExamScreen.Item;
                Started = true;
                _startedAt = DateTimeOffset.UtcNow;
                break;

            case ExamScreen.Review:
                EndExam();
                return;

            case ExamScreen.Score:
                Screen = ExamScreen.Report;
                break;

            default:
                if (Index >= Pages.Count - 1)
                {
                    Screen = ExamScreen.Review;
                }
                else
                {
                    Index++;
                }
                break;
        }

        Changed?.Invoke();
    }

    public void Previous()
    {
        if (!CanGoPrevious)
        {
            return;
        }
        Index--;
        Changed?.Invoke();
    }

    public void ShowReview()
    {
        Screen = ExamScreen.Review;
        Changed?.Invoke();
    }

    public void ShowReport()
    {
        Screen = ExamScreen.Report;
        Changed?.Invoke();
    }

    public void ShowScore()
    {
        Screen = ExamScreen.Score;
        Changed?.Invoke();
    }

    public void EndExam()
    {
        if (!Ended)
        {
            Ended = true;
            _endedAt = DateTimeOffset.UtcNow;
        }
        Screen = ExamScreen.Score;
        Changed?.Invoke();
    }

    public TimeSpan Remaining
    {
        get
        {
            var left = TimeSpan.FromMinutes(DurationMinutes) - Elapsed;
            return left < TimeSpan.Zero ? TimeSpan.Zero : left;
        }
    }

    public TimeSpan Elapsed => (_endedAt ?? DateTimeOffset.UtcNow) - _startedAt;

    public void Tick()
    {
        if (Started && !Ended && Remaining == TimeSpan.Zero)
        {
            EndExam();
            return;
        }
        Changed?.Invoke();
    }

    // ---------------------------------------------------------------- grading

    /// <summary>Per-question outcome, used by the score report and answer review.</summary>
    public IReadOnlyList<ItemResult> Results() =>
    [
        .. ScoredPages.Select(p =>
        {
            var state = State(p.Key);
            var answered = IsComplete(p);
            return new ItemResult(
                p.Seq!.Value,
                p.Item,
                answered && p.Item.IsCorrect(state.Response),
                answered,
                state.Marked,
                p.Item.ResponseLines(state.Response),
                p.Item.CorrectAnswerLines);
        })
    ];

    public int CorrectCount => Results().Count(r => r.Correct);

    public double PercentCorrect =>
        TotalQuestions == 0 ? 0 : (double)CorrectCount / TotalQuestions * 100;

    /// <summary>
    /// Approximates the Microsoft 1-1000 scale so that the 700 pass mark lines up with
    /// 70 percent correct. The real exam uses statistical scaling that is not published.
    /// </summary>
    public int ScaledScore => (int)Math.Round(PercentCorrect * 10);

    public bool Passed => ScaledScore >= PassMark;

    public IReadOnlyList<DomainResult> DomainResults()
    {
        var results = Results();
        return
        [
            .. ExamDomainInfo.All.Select(d =>
            {
                var subset = results.Where(r => r.Item.Domain == d).ToList();
                return new DomainResult(d, subset.Count(r => r.Correct), subset.Count);
            })
        ];
    }

    // ---------------------------------------------------------------- chrome

    /// <summary>Segmented progress display shown across the top of the exam.</summary>
    public IReadOnlyList<ProgressGroup> Progress() =>
    [
        new("Questions", AnsweredCount, TotalQuestions, false),
        new("Review", 0, 0, true),
        new("Score", 0, 0, true)
    ];

    /// <summary>Vertical Exam Progress stepper shown in the toolbar.</summary>
    public IReadOnlyList<ProgressStep> Steps()
    {
        var inExam = Screen is ExamScreen.Item or ExamScreen.Review
            or ExamScreen.Score or ExamScreen.Report;
        var scored = Screen is ExamScreen.Score or ExamScreen.Report;

        return
        [
            new("Select Exam", Screen == ExamScreen.Pick ? StepState.Current : StepState.Done),

            new("Welcome", Screen == ExamScreen.Agreement ? StepState.Current
                : Screen == ExamScreen.Pick ? StepState.Pending : StepState.Done),

            new("Exam Overview", Screen is ExamScreen.Summary or ExamScreen.Ready ? StepState.Current
                : inExam ? StepState.Done : StepState.Pending),

            new($"Questions ({TotalQuestions})", Screen == ExamScreen.Item ? StepState.Current
                : scored || Screen == ExamScreen.Review ? StepState.Done : StepState.Pending),

            new("End Questions", Screen == ExamScreen.Review ? StepState.Current
                : scored ? StepState.Done : StepState.Pending),

            new("Your Score", Screen == ExamScreen.Score ? StepState.Current
                : Screen == ExamScreen.Report ? StepState.Done : StepState.Pending),

            new("Answer Review", Screen == ExamScreen.Report ? StepState.Current : StepState.Pending)
        ];
    }
}
