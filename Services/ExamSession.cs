using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>How a form is delivered. Chosen on the picker screen, fixed for the attempt.</summary>
public enum ExamMode
{
    /// <summary>Timed 45-minute delivery with no assistance. Mirrors the live exam.</summary>
    Exam,

    /// <summary>Untimed study delivery with a per-question hint and answer reveal.</summary>
    Practice
}

public static class ExamModeInfo
{
    public static string Name(this ExamMode m) =>
        m == ExamMode.Practice ? "Practice" : "Exam";

    public static string Tagline(this ExamMode m) => m == ExamMode.Practice
        ? "Untimed, with hints and answers"
        : "Timed, exactly like the real thing";

    private static readonly string[] PracticePoints =
    [
        "No time limit — the clock counts up so you can watch your pace",
        "A hint on any question that narrows the field without naming the answer",
        "Reveal the keyed answer and the full explanation whenever you want",
        "Still fully scored, and the report shows where you leaned on help"
    ];

    private static readonly string[] ExamPoints =
    [
        $"{ExamSession.DurationMinutes} minutes on the clock, counting down",
        "The exam ends by itself when the time runs out",
        "No hints and no answers until you end the exam",
        $"Scored against the {ExamSession.PassMark} of 1000 pass mark"
    ];

    public static string[] Points(this ExamMode m) =>
        m == ExamMode.Practice ? PracticePoints : ExamPoints;

    public static readonly ExamMode[] All = [ExamMode.Practice, ExamMode.Exam];
}

public enum ExamScreen
{
    /// <summary>Choose which of the ten practice forms to sit.</summary>
    Pick,
    Agreement,
    Summary,
    Ready,
    Item,
    /// <summary>Practice mode: the marked result of the question just answered.</summary>
    Feedback,
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

    /// <summary>
    /// Items the candidate returned to after reading the marked result. Changing an answer
    /// from that position is assistance, and the score report says it tracks exactly that.
    /// </summary>
    private readonly HashSet<string> _revisedAfterResult = [];
    private DateTimeOffset _startedAt = DateTimeOffset.UtcNow;
    private DateTimeOffset? _endedAt;

    public event Action? Changed;

    public List<Page> Pages { get; } = [];
    public int Index { get; private set; }
    public ExamScreen Screen { get; private set; } = ExamScreen.Pick;
    public bool Ended { get; private set; }
    public bool Started { get; private set; }

    /// <summary>
    /// True once the review panel has been opened. Jumping to a question from there strands
    /// the candidate, so the shortcut back only appears after they have been.
    /// </summary>
    public bool HasSeenReview { get; private set; }
    public ExamForm Form { get; private set; } = ExamCatalog.Forms[0];

    /// <summary>Delivery mode for the current attempt. Set by <see cref="SelectForm"/>.</summary>
    public ExamMode Mode { get; private set; } = ExamMode.Exam;

    /// <summary>True when hints, answer reveals and the count-up clock are available.</summary>
    public bool IsPractice => Mode == ExamMode.Practice;

    /// <summary>True when the attempt runs against a countdown that can expire.</summary>
    public bool IsTimed => Mode == ExamMode.Exam;

    /// <summary>
    /// Practice mode: show the marked result after each question before moving on. The
    /// candidate can turn this off, since fifty interstitials is a lot when revising fast.
    /// </summary>
    public bool CheckAfterEach { get; private set; } = true;

    public void SetCheckAfterEach(bool on)
    {
        CheckAfterEach = on;
        if (!on && Screen == ExamScreen.Feedback)
        {
            Screen = ExamScreen.Item;
        }
        Changed?.Invoke();
    }

    /// <summary>True when Next on the current question should show the result first.</summary>
    public bool ShouldCheck =>
        IsPractice && CheckAfterEach && Screen == ExamScreen.Item && Current.Item.Scored;

    /// <summary>Loads a form in the given mode and returns the session to its pre-exam state.</summary>
    public void SelectForm(ExamForm form, ExamMode mode = ExamMode.Exam)
    {
        Form = form;
        Mode = mode;
        _states.Clear();
        _revisedAfterResult.Clear();
        Pages.Clear();
        Index = 0;
        Ended = false;
        Started = false;
        HasSeenReview = false;
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
        var state = State(key);

        // Reworking an answer having just been shown whether it was right counts as help.
        if (_revisedAfterResult.Contains(key) && !state.Response.SameAs(response))
        {
            state.UsedHelp = true;
        }

        state.Response = response;
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

    /// <summary>Practice mode: show or hide the hint for an item, remembering that it was used.</summary>
    public void ToggleHint(string key)
    {
        if (!IsPractice)
        {
            return;
        }

        var s = State(key);
        s.HintOpen = !s.HintOpen;
        s.UsedHint |= s.HintOpen;
        Changed?.Invoke();
    }

    /// <summary>Practice mode: reveal or hide the answer key and explanation for an item.</summary>
    public void ToggleHelp(string key)
    {
        if (!IsPractice)
        {
            return;
        }

        var s = State(key);
        s.HelpOpen = !s.HelpOpen;
        s.UsedHelp |= s.HelpOpen;
        Changed?.Invoke();
    }

    /// <summary>Questions whose answer was revealed during a practice attempt.</summary>
    public int HelpedCount => ScoredPages.Count(p => State(p.Key).UsedHelp);

    /// <summary>Questions whose hint was opened during a practice attempt.</summary>
    public int HintedCount => ScoredPages.Count(p => State(p.Key).UsedHint);

    public bool CanGoPrevious =>
        (Screen == ExamScreen.Item && Index > 0) || Screen == ExamScreen.Feedback;

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

            case ExamScreen.Feedback:
                // The result has been read; now actually move on.
                if (Index >= Pages.Count - 1)
                {
                    Screen = ExamScreen.Review;
                    HasSeenReview = true;
                }
                else
                {
                    Index++;
                    Screen = ExamScreen.Item;
                }
                break;

            default:
                if (ShouldCheck)
                {
                    Screen = ExamScreen.Feedback;
                    break;
                }

                if (Index >= Pages.Count - 1)
                {
                    Screen = ExamScreen.Review;
                    HasSeenReview = true;
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

        // From the result screen, back means back to the question, so the answer can change.
        if (Screen == ExamScreen.Feedback)
        {
            Screen = ExamScreen.Item;
            _revisedAfterResult.Add(Current.Key);
        }
        else
        {
            Index--;
        }

        Changed?.Invoke();
    }

    public void ShowReview()
    {
        Screen = ExamScreen.Review;
        HasSeenReview = true;
        Changed?.Invoke();
    }

    /// <summary>True when the candidate is on a question and can jump back to the review panel.</summary>
    public bool CanReturnToReview =>
        HasSeenReview && Screen is ExamScreen.Item or ExamScreen.Feedback;

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

    /// <summary>Time on task. Zero until the first question is shown.</summary>
    public TimeSpan Elapsed => Started
        ? (_endedAt ?? DateTimeOffset.UtcNow) - _startedAt
        : TimeSpan.Zero;

    /// <summary>
    /// What the clock shows: time left in Exam mode, time spent in Practice mode.
    /// </summary>
    public TimeSpan Clock => IsPractice ? Elapsed : Remaining;

    /// <summary>Caption above the clock, matching whichever direction it runs.</summary>
    public string ClockLegend => IsPractice ? "Time elapsed" : "Time remaining";

    /// <summary>True when an Exam-mode countdown is close enough to warrant a warning.</summary>
    public bool ClockIsLow => IsTimed && Started && !Ended && Remaining < TimeSpan.FromMinutes(5);

    public void Tick()
    {
        // Practice mode is untimed, so the clock runs up and nothing expires.
        if (IsTimed && Started && !Ended && Remaining == TimeSpan.Zero)
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
                p.Item.CorrectAnswerLines,
                state.UsedHint,
                state.UsedHelp);
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
        var inExam = Screen is ExamScreen.Item or ExamScreen.Feedback or ExamScreen.Review
            or ExamScreen.Score or ExamScreen.Report;
        var scored = Screen is ExamScreen.Score or ExamScreen.Report;

        return
        [
            new("Select Exam", Screen == ExamScreen.Pick ? StepState.Current : StepState.Done),

            new("Welcome", Screen == ExamScreen.Agreement ? StepState.Current
                : Screen == ExamScreen.Pick ? StepState.Pending : StepState.Done),

            new("Exam Overview", Screen is ExamScreen.Summary or ExamScreen.Ready ? StepState.Current
                : inExam ? StepState.Done : StepState.Pending),

            new($"Questions ({TotalQuestions})",
                Screen is ExamScreen.Item or ExamScreen.Feedback ? StepState.Current
                : scored || Screen == ExamScreen.Review ? StepState.Done : StepState.Pending),

            new("End Questions", Screen == ExamScreen.Review ? StepState.Current
                : scored ? StepState.Done : StepState.Pending),

            new("Your Score", Screen == ExamScreen.Score ? StepState.Current
                : Screen == ExamScreen.Report ? StepState.Done : StepState.Pending),

            new("Answer Review", Screen == ExamScreen.Report ? StepState.Current : StepState.Pending)
        ];
    }
}
