namespace MockExam.Fluent.Services;

/// <summary>
/// Interface strings, chosen by the language of the current course. A Romanian course should
/// not be delivered inside an English shell, so the chrome follows the content.
/// </summary>
public sealed class Ui
{
    public static Ui For(string language) =>
        language.StartsWith("ro", StringComparison.OrdinalIgnoreCase) ? Ro : En;

    // ---------------------------------------------------------------- navigation
    public required string Next { get; init; }
    public required string Previous { get; init; }
    public required string Review { get; init; }
    public required string NextQuestion { get; init; }
    public required string EndExam { get; init; }
    public required string FinishAndScore { get; init; }
    public required string BackToReview { get; init; }
    public required string BackToTheQuestion { get; init; }

    // ---------------------------------------------------------------- question chrome
    public required string Question { get; init; }
    public required string Result { get; init; }
    public required string ResetAnswer { get; init; }
    public required string ReviewLater { get; init; }
    public required string LeaveFeedback { get; init; }
    public required string Hint { get; init; }
    public required string HideHint { get; init; }
    public required string ShowAnswer { get; init; }
    public required string HideAnswer { get; init; }
    public required string CorrectAnswer { get; init; }
    public required string YourAnswer { get; init; }
    public required string NotAnswered { get; init; }
    public required string Explanation { get; init; }
    public required string SelectBest { get; init; }
    public required string SelectN { get; init; }

    // ---------------------------------------------------------------- header
    public required string TimeRemaining { get; init; }
    public required string TimeElapsed { get; init; }
    public required string Progress { get; init; }
    public required string Questions { get; init; }
    public required string ScoreReport { get; init; }
    public required string AnswerReview { get; init; }

    // ---------------------------------------------------------------- modes
    public required string PracticeModeName { get; init; }
    public required string ExamModeName { get; init; }
    public required string PracticeTagline { get; init; }
    public required string ExamTagline { get; init; }
    public required string[] PracticePoints { get; init; }
    public required string[] ExamPoints { get; init; }

    public string ModeName(ExamMode m) =>
        m == Services.ExamMode.Practice ? PracticeModeName : ExamModeName;

    public string ModeTagline(ExamMode m) =>
        m == Services.ExamMode.Practice ? PracticeTagline : ExamTagline;

    public string[] ModePoints(ExamMode m) =>
        m == Services.ExamMode.Practice ? PracticePoints : ExamPoints;

    // ---------------------------------------------------------------- feedback
    public required string ThatIsCorrect { get; init; }
    public required string ThatIsNotRight { get; init; }
    public required string YouSkipped { get; init; }
    public required string ChangeMyAnswer { get; init; }
    public required string WhyThatIsRight { get; init; }
    public required string Why { get; init; }
    public required string CorrectSub { get; init; }
    public required string WrongSub { get; init; }
    public required string SkippedSub { get; init; }
    public required string UseNextBelow { get; init; }

    // ---------------------------------------------------------------- study
    public required string StudyGuide { get; init; }
    public required string AllModules { get; init; }
    public required string Exams { get; init; }
    public required string LessonsRead { get; init; }
    public required string StartModule { get; init; }
    public required string ContinueModule { get; init; }
    public required string ReviewModule { get; init; }
    public required string MarkAsRead { get; init; }
    public required string MarkedAsRead { get; init; }
    public required string WhatToKnow { get; init; }
    public required string ExamTraps { get; init; }
    public required string ReadTheSource { get; init; }
    public required string SelectALesson { get; init; }
    public required string Lessons { get; init; }
    public required string StudyCtaTitle { get; init; }

    // ---------------------------------------------------------------- picker
    public required string ChooseCourse { get; init; }
    public required string ChooseExam { get; init; }
    public required string StepMode { get; init; }
    public required string StepForm { get; init; }
    public required string ExamTime { get; init; }
    public required string NoLimit { get; init; }
    public required string Minutes { get; init; }
    public required string PassMark { get; init; }
    public required string QuestionsWord { get; init; }
    public required string Untimed { get; init; }
    public required string StartExam { get; init; }

    // ---------------------------------------------------------------- score
    public required string CorrectAnswers { get; init; }
    public required string PercentCorrect { get; init; }
    public required string LeftUnanswered { get; init; }
    public required string TimeUsed { get; init; }
    public required string Pass { get; init; }
    public required string DidNotPass { get; init; }
    public required string PerformanceByArea { get; init; }
    public required string ReviewAnswers { get; init; }
    public required string ChooseAnother { get; init; }

    // ================================================================ English

    public static readonly Ui En = new()
    {
        Next = "Next",
        Previous = "Previous",
        Review = "Review",
        NextQuestion = "Next question",
        EndExam = "End exam",
        FinishAndScore = "Finish and score",
        BackToReview = "Back to review",
        BackToTheQuestion = "Back to the question",

        Question = "Question",
        Result = "result",
        ResetAnswer = "Reset answer",
        ReviewLater = "Review later",
        LeaveFeedback = "Leave feedback",
        Hint = "Hint",
        HideHint = "Hide hint",
        ShowAnswer = "Show answer",
        HideAnswer = "Hide answer",
        CorrectAnswer = "Correct answer",
        YourAnswer = "Your answer",
        NotAnswered = "No answer recorded.",
        Explanation = "Explanation",
        SelectBest = "Select the best answer.",
        SelectN = "Select {0} answers.",

        TimeRemaining = "Time remaining",
        TimeElapsed = "Time elapsed",
        Progress = "Progress",
        Questions = "Questions",
        ScoreReport = "Score report",
        AnswerReview = "Answer review",

        PracticeModeName = "Practice",
        ExamModeName = "Exam",
        PracticeTagline = "Untimed, with hints and answers",
        ExamTagline = "Timed, exactly like the real thing",
        PracticePoints =
        [
            "No time limit - the clock counts up so you can watch your pace",
            "A hint on any question that narrows the field without naming the answer",
            "Reveal the keyed answer and the full explanation whenever you want",
            "The result of each question, with the reasoning, before you move on"
        ],
        ExamPoints =
        [
            "The clock counts down and the exam ends by itself",
            "No hints and no answers until you finish",
            "No per-question feedback",
            "Scored against the published pass mark"
        ],

        ThatIsCorrect = "That is correct",
        ThatIsNotRight = "That is not right",
        YouSkipped = "You skipped this one",
        ChangeMyAnswer = "Change my answer",
        WhyThatIsRight = "Why that is right",
        Why = "Why",
        CorrectSub = "Here is why, so you can be sure it was not a lucky guess.",
        WrongSub = "Read why, then go back and change it if you want to.",
        SkippedSub = "The keyed answer and the reasoning are below.",
        UseNextBelow = "Use {0} below to carry on.",

        StudyGuide = "Study guide",
        AllModules = "All modules",
        Exams = "Exams",
        LessonsRead = "{0} of {1} lessons read",
        StartModule = "Start module",
        ContinueModule = "Continue",
        ReviewModule = "Review module",
        MarkAsRead = "Mark as read",
        MarkedAsRead = "Marked as read",
        WhatToKnow = "What to know",
        ExamTraps = "Where the exam catches people",
        ReadTheSource = "Read the source",
        SelectALesson = "Select a lesson to begin.",
        Lessons = "lessons",
        StudyCtaTitle = "Not ready to sit one yet?",

        ChooseCourse = "Choose a course",
        ChooseExam = "Choose a practice exam",
        StepMode = "Step 1 · How do you want to sit it?",
        StepForm = "Step 2 · Pick a form",
        ExamTime = "Exam Time:",
        NoLimit = "No limit",
        Minutes = "minutes",
        PassMark = "Pass mark:",
        QuestionsWord = "questions",
        Untimed = "untimed",
        StartExam = "Start Exam",

        CorrectAnswers = "Correct answers",
        PercentCorrect = "Percent correct",
        LeftUnanswered = "Left unanswered",
        TimeUsed = "Time used",
        Pass = "Pass",
        DidNotPass = "Did not pass",
        PerformanceByArea = "Performance by skills area",
        ReviewAnswers = "Review answers and explanations",
        ChooseAnother = "Choose another exam"
    };

    // ================================================================ Romanian

    public static readonly Ui Ro = new()
    {
        Next = "Inainte",
        Previous = "Inapoi",
        Review = "Recapitulare",
        NextQuestion = "Intrebarea urmatoare",
        EndExam = "Incheie examenul",
        FinishAndScore = "Incheie si puncteaza",
        BackToReview = "Inapoi la recapitulare",
        BackToTheQuestion = "Inapoi la intrebare",

        Question = "Intrebarea",
        Result = "rezultat",
        ResetAnswer = "Sterge raspunsul",
        ReviewLater = "Revin mai tarziu",
        LeaveFeedback = "Trimite o observatie",
        Hint = "Indiciu",
        HideHint = "Ascunde indiciul",
        ShowAnswer = "Arata raspunsul",
        HideAnswer = "Ascunde raspunsul",
        CorrectAnswer = "Raspuns corect",
        YourAnswer = "Raspunsul tau",
        NotAnswered = "Nu a fost inregistrat niciun raspuns.",
        Explanation = "Explicatie",
        SelectBest = "Alege cel mai bun raspuns.",
        SelectN = "Alege {0} raspunsuri.",

        TimeRemaining = "Timp ramas",
        TimeElapsed = "Timp scurs",
        Progress = "Progres",
        Questions = "Intrebari",
        ScoreReport = "Raport de punctaj",
        AnswerReview = "Recapitularea raspunsurilor",

        PracticeModeName = "Exersare",
        ExamModeName = "Examen",
        PracticeTagline = "Fara limita de timp, cu indicii si raspunsuri",
        ExamTagline = "Cronometrat, exact ca la examen",
        PracticePoints =
        [
            "Fara limita de timp - cronometrul creste, ca sa iti vezi ritmul",
            "Un indiciu la orice intrebare, care nu dezvaluie raspunsul",
            "Poti afisa oricand raspunsul corect si explicatia completa",
            "Rezultatul fiecarei intrebari, cu explicatie, inainte de a merge mai departe"
        ],
        ExamPoints =
        [
            "Cronometrul scade, iar testul se incheie singur",
            "Fara indicii si fara raspunsuri pana la final",
            "Fara feedback dupa fiecare intrebare",
            "Punctat fata de pragul de promovare"
        ],

        ThatIsCorrect = "Raspuns corect",
        ThatIsNotRight = "Raspuns gresit",
        YouSkipped = "Ai sarit peste aceasta intrebare",
        ChangeMyAnswer = "Schimb raspunsul",
        WhyThatIsRight = "De ce este corect",
        Why = "De ce",
        CorrectSub = "Iata de ce, ca sa fii sigur ca nu a fost noroc.",
        WrongSub = "Citeste de ce, apoi intoarce-te si schimba raspunsul daca vrei.",
        SkippedSub = "Raspunsul corect si explicatia sunt mai jos.",
        UseNextBelow = "Foloseste {0} de mai jos ca sa continui.",

        StudyGuide = "Material de studiu",
        AllModules = "Toate modulele",
        Exams = "Teste",
        LessonsRead = "{0} din {1} lectii parcurse",
        StartModule = "Incepe modulul",
        ContinueModule = "Continua",
        ReviewModule = "Reia modulul",
        MarkAsRead = "Marcheaza ca parcursa",
        MarkedAsRead = "Marcata ca parcursa",
        WhatToKnow = "Ce trebuie sa stii",
        ExamTraps = "Unde se greseste de obicei",
        ReadTheSource = "Vezi materialul",
        SelectALesson = "Alege o lectie pentru a incepe.",
        Lessons = "lectii",
        StudyCtaTitle = "Nu esti inca pregatit pentru un test?",

        ChooseCourse = "Alege un curs",
        ChooseExam = "Alege un test",
        StepMode = "Pasul 1 · Cum vrei sa il dai?",
        StepForm = "Pasul 2 · Alege un formular",
        ExamTime = "Timp de lucru:",
        NoLimit = "Fara limita",
        Minutes = "minute",
        PassMark = "Prag de promovare:",
        QuestionsWord = "intrebari",
        Untimed = "fara limita",
        StartExam = "Incepe testul",

        CorrectAnswers = "Raspunsuri corecte",
        PercentCorrect = "Procent corect",
        LeftUnanswered = "Fara raspuns",
        TimeUsed = "Timp folosit",
        Pass = "Promovat",
        DidNotPass = "Nepromovat",
        PerformanceByArea = "Rezultate pe capitole",
        ReviewAnswers = "Vezi raspunsurile si explicatiile",
        ChooseAnother = "Alege alt test"
    };
}
