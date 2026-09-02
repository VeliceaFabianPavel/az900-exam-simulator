using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Modulele 2-5: prezentare generala, sintaxa, POO si POO avansata.
public static partial class JavaTraining
{
    private static TrainingModule Modul2() => new()
    {
        Id = "jm2",
        Title = "Prezentare generala a limbajului Java",
        Domain = JavaDomains.Ch2,
        Reference = "Cartea de Java, cap. 2: Prezentare generala",
        Pages = "cap. 2, p3-14",
        Blurb = "De unde vine Java, cum ajunge codul sa ruleze si ce unelte sunt necesare.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm2-l1",
                Title = "Ce este Java si de unde vine",
                Objective = "Istoricul si scopul limbajului Java",
                Pages = "p3-4",
                Intro = P("""
                    Java a fost creat la mijlocul anilor 1990 de o echipa de la Sun Microsystems
                    condusa de James Gosling. Scopul declarat era un limbaj simplu, robust si
                    portabil, iar tinta initiala nu era deloc cea de astazi.
                    """),
                Points =
                [
                    "Limbajul a fost proiectat initial pentru aparatura electronica de consum, precum set-top box-uri si dispozitive portabile.",
                    "A devenit rapid limbaj de uz general datorita caracteristicilor sale, nu pentru ca ar fi fost gandit asa de la inceput.",
                    "In Java se pot scrie aplicatii, applet-uri si servlet-uri.",
                    "Microsoft ofera trei solutii cloud; Java este un limbaj, nu o platforma cloud. Nu confundati contextele.",
                    "Java este un limbaj orientat pe obiecte, asemanator cu C++, considerat usor de invatat si de folosit.",
                    "Versatilitatea, flexibilitatea, eficienta si portabilitatea sunt aspectele care il propulseaza inaintea altora."
                ],
                Essentials =
                [
                    "Intrebarile despre origine testeaza domeniul initial, nu cel actual. Raspunsul este electronica de consum.",
                    "James Gosling si Sun Microsystems sunt perechea corecta. Oracle apare mai tarziu, ca detinator al platformei."
                ]
            },

            new Lesson
            {
                Id = "jm2-l2",
                Title = "Bytecode, masina virtuala si compilarea JIT",
                Objective = "Compilare, bytecode si masina virtuala",
                Pages = "p3-6",
                Intro = P("""
                    Portabilitatea limbajului nu este o promisiune, ci o consecinta a modului in care
                    codul ajunge sa se execute. Doua etape stau intre sursa scrisa de programator si
                    instructiunile executate de procesor.
                    """),
                Points =
                [
                    "La compilare, codul sursa este convertit in bytecode, un limbaj masina portabil pe orice arhitectura de procesor.",
                    "Bytecode-ul nu este direct executabil: el este interpretat de masina virtuala Java si tradus in limbaj masina specific calculatorului.",
                    "La rulare, compilatorul JIT converteste bytecode-ul in cod nativ optimizat pentru arhitectura concreta, ceea ce accelereaza executia.",
                    "Masina virtuala gestioneaza automat memoria, iar colectorul de gunoi recupereaza memoria care nu mai este folosita.",
                    "Modelul de securitate ruleaza programele intr-un mediu izolat, fara acces direct la resursele sistemului.",
                    "Interpretarea bytecode-ului face programele Java mai lente decat cele scrise in C sau C++, dezavantaj redus de la o versiune la alta."
                ],
                Essentials =
                [
                    "Portabilitatea vine din bytecode plus masina virtuala, nu din rescrierea codului pentru fiecare sistem.",
                    "Nu afirmati ca Java este mai rapid decat C sau C++. Cartea spune explicit contrariul, cu mentiunea ca diferenta s-a redus."
                ],
                Table = new LessonTable(
                    "Etapele executiei",
                    ["Etapa", "Ce se intampla"],
                    [
                        ["Compilare", "Codul sursa devine bytecode independent de platforma"],
                        ["Incarcare", "Masina virtuala preia bytecode-ul"],
                        ["Rulare", "Compilatorul JIT produce cod nativ optimizat"]
                    ])
            },

            new Lesson
            {
                Id = "jm2-l3",
                Title = "Platforma, pachetele si avantajele",
                Objective = "Avantajele limbajului Java",
                Pages = "p3-6",
                Intro = P("""
                    Dincolo de limbaj, Java inseamna un set foarte mare de clase gata scrise. Modul
                    in care acestea sunt organizate explica de ce limbajul este usor de extins.
                    """),
                Points =
                [
                    "Platforma Java este ansamblul claselor existente in orice kit de instalare, numita si mediul Java sau nucleul API.",
                    "Clasele sunt grupate in pachete, organizate dupa rol: retea, grafica, interfata utilizator, securitate.",
                    "Un alt nume pentru astfel de seturi de clase este cadru de lucru.",
                    "Scrie o data, ruleaza oriunde este conceptul central: aplicatia ruleaza pe orice platforma care suporta Java, fara modificari.",
                    "Securitatea permite descarcarea de cod prin retea intr-un mediu sigur, in care codul nesigur nu poate infecta sistemul gazda.",
                    "Programele sunt usor de extins pentru ca organizarea este modulara, pe clase incarcate de interpretor doar cand este nevoie."
                ],
                Essentials =
                [
                    "Pachetele nu sunt doar o conventie de nume: ele organizeaza clasele dupa functie si delimiteaza directoare.",
                    "Incarcarea claselor doar cand sunt necesare este ceea ce face aplicatia o interactiune intre componente independente, nu un bloc monolitic."
                ]
            },

            new Lesson
            {
                Id = "jm2-l4",
                Title = "JDK, JRE si uneltele de dezvoltare",
                Objective = "Mediul de dezvoltare Java",
                Pages = "p6-12",
                Intro = P("""
                    Doua acronime apropiate acopera lucruri diferite, iar confuzia dintre ele este
                    cea mai frecventa problema practica a inceputului.
                    """),
                Points =
                [
                    "JRE ofera bibliotecile, masina virtuala si componentele necesare rularii aplicatiilor si applet-urilor, si poate fi redistribuit cu o aplicatie.",
                    "JDK include JRE si adauga uneltele necesare dezvoltatorului, precum compilatorul si depanatorul.",
                    "Uneltele de baza sunt javac pentru compilare, java pentru rulare si javadoc pentru documentatie.",
                    "Mediile integrate de dezvoltare uzuale sunt Eclipse, NetBeans si IntelliJ IDEA; primele doua sunt cu sursa deschisa, al treilea este comercial.",
                    "Uneltele de constructie precum Maven si Gradle automatizeaza construirea si impachetarea aplicatiei.",
                    "Cadrele de testare precum JUnit si TestNG servesc la teste automate, iar sistemele de versionare precum Git si Subversion la gestiunea codului sursa."
                ],
                Essentials =
                [
                    "Cu JRE nu se poate compila. Daca javac lipseste, raspunsul este instalarea JDK.",
                    "Un IDE nu este obligatoriu: compilarea si rularea din linia de comanda sunt perfect posibile."
                ]
            },

            new Lesson
            {
                Id = "jm2-l5",
                Title = "Primul program si tipurile de erori",
                Objective = "Structura primului program",
                Pages = "p7-10",
                Intro = P("""
                    Primul program pare banal, dar fiecare cuvant din antetul metodei main are un rol
                    care revine constant in intrebari. Tot aici apare si prima regula stricta a
                    limbajului: legatura dintre numele fisierului si numele clasei.
                    """),
                Points =
                [
                    "Un fisier Java este o unitate de compilare, cu extensia .java, si contine una sau mai multe definitii de clase.",
                    "Numele clasei publice trebuie sa fie identic cu numele fisierului care o contine.",
                    "Java este sensibil la litere mari si mici, deci Example, example si eXample sunt nume diferite.",
                    "La compilare, fiecare clasa ajunge intr-un fisier .class numit dupa clasa.",
                    "In antetul main, public este specificator de acces, static permite apelul fara instantierea clasei, void arata ca nu se returneaza nimic, iar String args[] este colectia argumentelor primite la rulare.",
                    "System este o clasa predefinita care ofera acces la sistem, out este fluxul de iesire catre consola, iar println metoda de afisare."
                ],
                Essentials =
                [
                    "Erorile de sintaxa sunt semnalate de compilator inainte de rulare; erorile la rulare apar in timpul executiei, din situatii neprevazute.",
                    "Mesajul compilatorului nu trebuie luat literal. El incearca sa dea un inteles codului oricum ar arata, asa ca eroarea raportata rareori indica adevarata cauza.",
                    "ArrayIndexOutOfBoundsException la citirea unui argument inseamna ca sirul de argumente este mai scurt decat presupune programul."
                ]
            }
        ]
    };

    private static TrainingModule Modul3() => new()
    {
        Id = "jm3",
        Title = "Sintaxa si structura de baza",
        Domain = JavaDomains.Ch3,
        Reference = "Cartea de Java, cap. 3: Sintaxa de baza",
        Pages = "cap. 3, p15-30",
        Blurb = "Tipuri, operatori, structuri de control, tablouri, siruri si metode.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm3-l1",
                Title = "Tipuri de date si variabile",
                Objective = "Tipuri de date si variabile",
                Pages = "p16-18",
                Intro = P("""
                    Java are doua categorii de tipuri, iar deosebirea dintre ele explica felul in
                    care se comporta atribuirea si transmiterea catre metode.
                    """),
                Points =
                [
                    "O variabila de tip primitiv contine o singura valoare, in formatul tipului respectiv.",
                    "Clasele, tablourile si interfetele sunt tipuri referinta; valoarea unei variabile referinta este adresa unui obiect creat pe heap.",
                    "Spre deosebire de C, in Java nu exista posibilitatea de a accesa direct zona de memorie.",
                    "Un nume de variabila trebuie sa inceapa cu o litera, sa fie compus din caractere Unicode, sa nu fie cuvant rezervat si sa fie unic in domeniul sau de vizibilitate.",
                    "Domeniul de vizibilitate este portiunea de cod in care variabila poate fi folosita si stabileste cand se aloca si se elibereaza memoria.",
                    "Cuvantul final aplicat unei variabile face ca aceasta sa nu mai poata fi modificata dupa initializare, deci o transforma in constanta."
                ],
                Essentials =
                [
                    "Retineti dimensiunile: byte 8 biti, short 16, int 32, long 64, float 32, double 64, char 16, boolean 8.",
                    "char ocupa 16 biti pentru ca reprezinta caractere Unicode. Este usor de confundat cu short."
                ],
                Table = new LessonTable(
                    "Tipuri primitive",
                    ["Tip", "Dimensiune", "Observatie"],
                    [
                        ["byte", "8 biti", "Intreg cu semn, intre -128 si 127"],
                        ["int", "32 de biti", "Tipul intreg folosit implicit"],
                        ["long", "64 de biti", "Pentru valori intregi mari"],
                        ["char", "16 biti", "Caractere Unicode"],
                        ["boolean", "8 biti", "Doar true sau false"]
                    ])
            },

            new Lesson
            {
                Id = "jm3-l2",
                Title = "Operatori",
                Objective = "Operatori",
                Pages = "p18-19",
                Intro = P("""
                    Operatorii se grupeaza dupa numarul de operanzi si dupa rolul lor. Cateva perechi
                    seamana suficient de mult incat sa merite atentie separata.
                    """),
                Points =
                [
                    "Un operator unar cere un singur operand, unul binar doi, iar operatorul conditional este singurul ternar.",
                    "Operatorii aritmetici sunt plus, minus, inmultire, impartire si rest; plus concateneaza si siruri de caractere.",
                    "Operatorii relationali compara doua valori si returneaza un rezultat logic.",
                    "Operatorii conditionali && si || evalueaza conditional al doilea operand; & si | il evalueaza intotdeauna.",
                    "Operatorul de deplasare >>> completeaza bitii din stanga cu zero, iar >> ii completeaza cu bitul de semn.",
                    "Operatorul ?: evalueaza primul operand, care trebuie sa fie boolean, si foloseste al doilea daca este adevarat, respectiv al treilea daca este fals."
                ],
                Essentials =
                [
                    "Deosebirea dintre && si & nu este de rezultat, ci de evaluare. Conteaza cand al doilea operand are efecte secundare.",
                    "Al doilea si al treilea operand ai operatorului conditional trebuie sa fie de acelasi tip sau convertibili la acelasi tip."
                ]
            },

            new Lesson
            {
                Id = "jm3-l3",
                Title = "Structuri de control",
                Objective = "Structuri de control",
                Pages = "p19-23",
                Intro = P("""
                    Buclele si instructiunile conditionale controleaza fluxul executiei. Doua
                    instructiuni de salt, break si continue, fac diferenta intre a parasi bucla si a
                    sari peste restul unei iteratii.
                    """),
                Points =
                [
                    "La while, expresia se evalueaza inaintea corpului, deci corpul poate sa nu se execute deloc.",
                    "La do-while, expresia se evalueaza la final, deci corpul se executa cel putin o data.",
                    "Instructiunea for are trei parti: initializarea, executata o singura data, conditia de terminare, evaluata la inceputul fiecarei iteratii, si incrementarea, executata la sfarsitul fiecarei iteratii.",
                    "break forteaza iesirea din bucla, iar in switch impiedica executia instructiunilor de sub ramura care s-a potrivit.",
                    "continue sare la pasul urmator al buclei, ignorand ce urmeaza dupa el in corpul buclei.",
                    "Java nu are goto clasic, pentru ca acesta permite un flux logic nestructurat; exista break cu eticheta, prezentat pur informativ."
                ],
                Essentials =
                [
                    "break iese, continue sare. Confuzia dintre ele schimba complet rezultatul unui program.",
                    "Variabila dintr-un switch poate fi char, byte, short, int sau tip enumerat, iar incepand cu Java 7 si String."
                ]
            },

            new Lesson
            {
                Id = "jm3-l4",
                Title = "Tablouri si siruri de caractere",
                Objective = "Tablouri",
                Pages = "p23-26",
                Intro = P("""
                    Tablourile si sirurile sunt ambele obiecte, dar se comporta diferit la
                    modificare. Imutabilitatea sirurilor este subiectul cel mai testat din acest
                    capitol.
                    """),
                Points =
                [
                    "Tablourile sunt obiecte care stocheaza mai multe variabile de acelasi tip, ordonate si accesibile prin indice.",
                    "Elementele unui tablou pot fi modificate, dar dimensiunea este fixata la creare si nu mai poate fi schimbata.",
                    "Lungimea unui tablou se obtine prin proprietatea length, scrisa fara paranteze.",
                    "Sirurile de caractere sunt obiecte imutabile: odata creat, continutul unui String nu mai poate fi schimbat.",
                    "Metodele clasei String returneaza un sir nou si nu il modifica pe cel original.",
                    "Metoda indexOf returneaza indicele primei aparitii, sau -1 daca elementul cautat nu exista."
                ],
                Essentials =
                [
                    "Imutabilitatea aduce securitate, comportament sigur intre fire de executie si posibilitatea pastrarii in cache.",
                    "Pentru modificari frecvente ale sirurilor se recomanda StringBuilder sau StringBuffer.",
                    "Nu confundati length de la tablou, length() de la String si size() de la colectii."
                ]
            },

            new Lesson
            {
                Id = "jm3-l5",
                Title = "Metode",
                Objective = "Metode",
                Pages = "p27-29",
                Intro = P("""
                    Metodele sunt blocurile din care se construieste programul. Antetul lor contine
                    patru informatii, iar supraincarcarea si recursivitatea sunt cele doua mecanisme
                    de retinut.
                    """),
                Points =
                [
                    "Antetul unei metode contine modificatorul de acces, eventualul cuvant static, tipul returnat, numele si lista de parametri.",
                    "Cuvantul static arata ca metoda apartine clasei, nu unei instante anume.",
                    "Numele metodei se scrie de obicei in stilul camelCase.",
                    "Supraincarcarea permite mai multe metode cu acelasi nume dar cu liste de parametri diferite; compilatorul le deosebeste dupa parametri.",
                    "Tipul returnat poate fi acelasi sau diferit intre metodele supraincarcate, dar nu el este criteriul de deosebire.",
                    "O metoda recursiva se apeleaza pe ea insasi, direct sau indirect, si are nevoie de un caz de baza care sa opreasca recursia."
                ],
                Essentials =
                [
                    "Doua metode care difera doar prin tipul returnat nu se compileaza. Compilatorul nu are cum sa aleaga intre ele.",
                    "Fara cazul de baza, o metoda recursiva nu returneaza un rezultat gresit: se apeleaza la nesfarsit."
                ]
            }
        ]
    };

    private static TrainingModule Modul4() => new()
    {
        Id = "jm4",
        Title = "Programare orientata pe obiecte",
        Domain = JavaDomains.Ch4,
        Reference = "Cartea de Java, cap. 4: POO",
        Pages = "cap. 4, p31-46",
        Blurb = "Clase, obiecte, incapsulare, constructori, mostenire si clasa Object.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm4-l1",
                Title = "Clase, obiecte si incapsulare",
                Objective = "Clase si obiecte",
                Pages = "p31-34",
                Intro = P("""
                    Obiectele modeleaza entitati din lumea reala. Doua caracteristici comune ale
                    acestora se traduc direct in doua constructii din cod.
                    """),
                Points =
                [
                    "O clasa este un sablon pentru un obiect: defineste proprietatile si metodele pe care le va avea obiectul.",
                    "Un obiect se creeaza cu operatorul new, urmat de numele clasei si de argumentele cerute de constructor.",
                    "Obiectele reale au stare si comportament; in cod, starea devine variabile, iar comportamentul devine metode.",
                    "Metodele care evalueaza sau modifica starea unui obiect anume se numesc metode de instanta.",
                    "Incapsularea este ascunderea detaliilor interne si expunerea doar a informatiei necesare.",
                    "Se realizeaza prin modificatorii de acces public, private, protected si cel implicit, impreuna cu metodele getter si setter."
                ],
                Essentials =
                [
                    "Getterele si setterele permit controlul accesului la membrii privati si pot impune constrangeri asupra valorilor.",
                    "Al doilea avantaj important este flexibilitatea: implementarea interna poate fi schimbata fara a afecta codul care foloseste clasa."
                ]
            },

            new Lesson
            {
                Id = "jm4-l2",
                Title = "Constructori si cuvantul this",
                Objective = "Constructori",
                Pages = "p35-38",
                Intro = P("""
                    Initializarea membrilor unul cate unul dupa creare este usor de gresit.
                    Constructorul rezolva asta, iar cuvantul this lamureste la ce ne referim cand
                    numele se repeta.
                    """),
                Points =
                [
                    "Un constructor initializeaza obiectul la creare, poarta acelasi nume cu clasa si nu returneaza nimic.",
                    "O clasa poate avea mai multi constructori, cu numar si tipuri diferite de parametri.",
                    "La new se apeleaza constructorul ai carui parametri corespund ca tip celor folositi in apel.",
                    "Cuvantul this reprezinta instanta curenta a obiectului.",
                    "In constructor, this deosebeste membrul clasei de parametrul cu acelasi nume.",
                    "Supraincarcarea metodelor cere parametri diferiti ca tip sau ca numar; daca difera doar tipul returnat, codul nu se compileaza."
                ],
                Essentials =
                [
                    "Initializarea manuala dupa creare nu este profesionista: cu multi membri, unul poate fi uitat usor.",
                    "Mecanismul supraincarcarii se numeste o interfata, mai multe metode."
                ]
            },

            new Lesson
            {
                Id = "jm4-l3",
                Title = "Mostenire si suprascriere",
                Objective = "Mostenire",
                Pages = "p40-43",
                Intro = P("""
                    Mostenirea permite reutilizarea codului, iar suprascrierea permite
                    specializarea lui. Impreuna, ele produc polimorfismul la rulare.
                    """),
                Points =
                [
                    "O subclasa se creeaza cu cuvantul cheie extends si mosteneste proprietatile si metodele clasei de baza.",
                    "Constructorul superclasei instantiaza portiunea superclasei, iar cel al subclasei portiunea proprie.",
                    "O subclasa poate apela constructorul superclasei cu super, urmat de lista de parametri.",
                    "Cand o metoda din clasa copil are aceeasi semnatura cu una din clasa parinte, o suprascrie; la apel se foloseste doar cea din copil.",
                    "Suprascrierea difera de supraincarcare: la suprascriere semnatura ramane identica, la supraincarcare lista de parametri se schimba.",
                    "Cuvantul final aplicat unei metode impiedica suprascrierea ei in clasele derivate."
                ],
                Essentials =
                [
                    "Suprascrierea sta la baza polimorfismului la rulare: clasa generala declara metode comune, iar copiii pot avea implementari proprii.",
                    "super() fara argumente apeleaza constructorul fara parametri al clasei de baza."
                ]
            },

            new Lesson
            {
                Id = "jm4-l4",
                Title = "Clasa Object",
                Objective = "Clasa Object",
                Pages = "p43-45",
                Intro = P("""
                    Toate clasele ajung, direct sau indirect, la aceeasi radacina. De acolo mostenesc
                    un set de metode care apar constant in cod.
                    """),
                Points =
                [
                    "Object este clasa fundamentala pe care toate celelalte clase o extind direct sau indirect.",
                    "Metodele ei sunt clone, equals, finalize, getClass, hashCode, toString, wait si notify.",
                    "Metodele getClass, notify, notifyAll si wait sunt declarate final si nu pot fi suprascrise.",
                    "equals determina daca un obiect este egal cu altul, iar hashCode returneaza un identificator specific fiecarui obiect.",
                    "Pentru clonare, clasa trebuie sa implementeze interfata Cloneable si sa suprascrie metoda clone.",
                    "Metodele wait, notify si notifyAll servesc la sincronizarea firelor de executie care ruleaza independent."
                ],
                Essentials =
                [
                    "Cand suprascrieti equals, suprascrieti si hashCode: cele doua trebuie sa fie in acord.",
                    "Rolul clasei Object este de stramos comun, ceea ce permite tratarea unitara a obiectelor de tipuri diferite la serializare, clonare sau comparare."
                ]
            }
        ]
    };

    private static TrainingModule Modul5() => new()
    {
        Id = "jm5",
        Title = "Programare orientata pe obiecte avansata",
        Domain = JavaDomains.Ch5,
        Reference = "Cartea de Java, cap. 5: POO avansata",
        Pages = "cap. 5, p47-56",
        Blurb = "Clase abstracte, interfete si alegerea dintre ele.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm5-l1",
                Title = "Metode si clase abstracte",
                Objective = "Metode si clase abstracte",
                Pages = "p47-50",
                Intro = P("""
                    Cand o superclasa trebuie sa declare o operatie fara sa stie cum se face,
                    raspunsul este metoda abstracta. De aici decurg cateva reguli stricte.
                    """),
                Points =
                [
                    "O metoda abstracta nu are corp, ci doar semnatura, iar declaratia se incheie cu punct si virgula.",
                    "Orice clasa care contine o metoda abstracta este automat abstracta si trebuie declarata ca atare.",
                    "O clasa abstracta nu poate fi instantiata.",
                    "O subclasa poate fi instantiata doar daca suprascrie si implementeaza toate metodele abstracte ale parintelui; astfel de clase se numesc concrete.",
                    "Daca o subclasa nu implementeaza toate metodele abstracte mostenite, devine ea insasi abstracta.",
                    "Metodele static, private sau final nu pot fi abstracte, iar o clasa final nu poate contine metode abstracte."
                ],
                Essentials =
                [
                    "O clasa poate fi declarata abstracta chiar fara metode abstracte, semnaland ca este incompleta si serveste ca parinte.",
                    "Daca un obiect este vazut prin tipul superclasei, nu se poate accesa un membru specific subclasei, chiar daca acesta este public."
                ]
            },

            new Lesson
            {
                Id = "jm5-l2",
                Title = "Interfete",
                Objective = "Interfete",
                Pages = "p50-54",
                Intro = P("""
                    Interfata separa complet ce trebuie facut de cum se face. Regulile ei sunt mai
                    stricte decat cele ale unei clase abstracte.
                    """),
                Points =
                [
                    "Intr-o interfata nicio metoda nu are voie sa aiba corp, iar metodele sunt implicit publice.",
                    "O clasa poate implementa una sau mai multe interfete, folosind cuvantul cheie implements.",
                    "O interfata poate extinde una sau mai multe alte interfete, folosind extends.",
                    "Variabilele dintr-o interfata trebuie sa fie public, final si static, si trebuie initializate: sunt practic constante.",
                    "O interfata nu poate fi instantiata si nu poate defini un constructor.",
                    "Daca o clasa nu implementeaza toate metodele interfetei, mosteneste acele metode ca abstracte si devine ea insasi abstracta."
                ],
                Essentials =
                [
                    "Clasa foloseste implements pentru interfete si extends pentru clase. O interfata foloseste extends si pentru alte interfete.",
                    "Clauza extends este optionala si poate aparea impreuna cu implements: o clasa poate mosteni de la o clasa si prelua in acelasi timp interfete."
                ]
            },

            new Lesson
            {
                Id = "jm5-l3",
                Title = "Interfata sau clasa abstracta",
                Objective = "Interfete si clase abstracte",
                Pages = "p54",
                Intro = P("""
                    Cand definiti un tip de date trebuie sa alegeti intre cele doua. Cartea da un
                    raspuns preferat si un contra-argument, plus un criteriu de compatibilitate.
                    """),
                Points =
                [
                    "Interfata este in general recomandata, pentru ca orice clasa o poate implementa, chiar daca extinde deja alta superclasa fara legatura cu ea.",
                    "Contra-argumentul este ca o interfata cu multe metode devine greoaie de implementat pentru fiecare clasa.",
                    "O clasa abstracta nu trebuie sa fie in intregime abstracta: poate contine cel putin o implementare partiala pe care subclasele o pot folosi.",
                    "O clasa care extinde o clasa abstracta nu mai poate extinde altceva, ceea ce poate crea dificultati.",
                    "Adaugarea unei metode intr-o interfata dintr-o biblioteca strica clasele care implementau versiunea anterioara.",
                    "Cu o clasa abstracta se pot adauga metode neabstracte fara a afecta clasele care o mostenesc."
                ],
                Essentials =
                [
                    "Argumentul principal pentru interfata este limitarea mostenirii unice din Java.",
                    "Argumentul principal pentru clasa abstracta este compatibilitatea la evolutia bibliotecii."
                ],
                Table = new LessonTable(
                    "Comparatie",
                    ["Criteriu", "Interfata", "Clasa abstracta"],
                    [
                        ["Corp de metoda", "Nu", "Da, partial"],
                        ["Cate poate prelua o clasa", "Oricate", "Una singura"],
                        ["Adaugarea unei metode noi", "Strica implementarile", "Nu le strica, daca nu e abstracta"],
                        ["Instantiere", "Nu", "Nu"]
                    ])
            }
        ]
    };
}
