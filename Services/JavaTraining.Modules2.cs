using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Modulele 6-8: colectii, concepte avansate si colectii in detaliu.
public static partial class JavaTraining
{
    private static TrainingModule Modul6() => new()
    {
        Id = "jm6",
        Title = "Colectii in Java",
        Domain = JavaDomains.Ch6,
        Reference = "Cartea de Java, cap. 6: Colectii",
        Pages = "cap. 6, p57-68",
        Blurb = "Cadrul de colectii, generice, liste, dictionare si multimi.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm6-l1",
                Title = "Cadrul de lucru pentru colectii",
                Objective = "Cadrul de lucru pentru colectii",
                Pages = "p57-59",
                Intro = P("""
                    Colectiile ofera un mod flexibil si eficient de a stoca si manipula grupuri de
                    obiecte. Cadrul care le contine are o structura pe care merita sa o cunoasteti
                    inainte de clasele concrete.
                    """),
                Points =
                [
                    "Cadrul este alcatuit din trei parti: interfete, implementari si algoritmi.",
                    "Implementarile sunt clasele concrete oferite de cadru, iar algoritmii sunt actiuni sau metode predefinite.",
                    "Cadrul cuprinde in jur de douazeci si cinci de clase si interfete si se afla in pachetul java.util.",
                    "Interfetele principale sunt Collection, List, Set, Map, SortedSet si SortedMap.",
                    "Toate clasele implementeaza fie interfata Collection, fie interfata Map.",
                    "Toate implementarile sunt nesincronizate, ofera iteratoare de tip fail-fast, lucreaza cu elemente nule si arunca UnsupportedOperationException pentru operatiile nesuportate."
                ],
                Essentials =
                [
                    "Modificarea unei colectii in timpul iterarii produce ConcurrentModificationException. Asta inseamna fail-fast.",
                    "Interfata Collection nu implementeaza nici Cloneable, nici Serializable; pentru a copia o colectie, transmiteti-o constructorului la instantiere."
                ],
                Table = new LessonTable(
                    "Clase concrete pe interfete",
                    ["Interfata", "Tabela de dispersie", "Tablou redimensionabil", "Arbore echilibrat", "Lista inlantuita"],
                    [
                        ["Set", "HashSet", "-", "TreeSet", "-"],
                        ["List", "-", "ArrayList", "-", "LinkedList"],
                        ["Map", "HashMap", "-", "TreeMap", "-"]
                    ])
            },

            new Lesson
            {
                Id = "jm6-l2",
                Title = "Tipuri generice",
                Objective = "Tipuri generice",
                Pages = "p59-60",
                Intro = P("""
                    Genericele permit scrierea de cod care functioneaza cu mai multe tipuri de date,
                    pastrand in acelasi timp verificarea la compilare.
                    """),
                Points =
                [
                    "Genericele se implementeaza prin parametri de tip, scrisi intre paranteze unghiulare dupa numele clasei sau al metodei.",
                    "Parametrul de tip se inlocuieste cu un tip real in momentul instantierii clasei.",
                    "In interiorul clasei, parametrul de tip se foloseste ca si cum ar fi un tip adevarat.",
                    "Primul beneficiu este verificarea mai stricta a tipurilor la compilare, ceea ce permite depistarea timpurie a erorilor.",
                    "Al doilea este reutilizarea codului: o singura clasa sau metoda generica functioneaza cu tipuri diferite.",
                    "Al treilea este eliminarea conversiilor explicite de tip, care altfel pot duce la erori la rulare."
                ],
                Essentials =
                [
                    "Genericele mut verificarea de la rulare la compilare. Acesta este castigul lor principal.",
                    "Doua obiecte din aceeasi clasa generica pot avea tipuri de continut complet diferite."
                ]
            },

            new Lesson
            {
                Id = "jm6-l3",
                Title = "ArrayList si LinkedList",
                Objective = "ArrayList si LinkedList",
                Pages = "p60-62",
                Intro = P("""
                    Ambele implementeaza interfata List, dar structura interna diferita le face
                    potrivite pentru situatii opuse.
                    """),
                Points =
                [
                    "ArrayList foloseste un tablou dinamic, iar LinkedList o lista dublu inlantuita.",
                    "Accesul aleator este rapid la ArrayList, O(1), si lent la LinkedList, O(n), pentru ca acesta necesita parcurgere de la cap.",
                    "Inserarile si stergerile sunt mai lente la ArrayList, O(n), din cauza redimensionarii si a deplasarii elementelor, si mai rapide la LinkedList, O(1), prin simpla schimbare a pointerilor.",
                    "ArrayList consuma mai putina memorie, folosind o alocare contigua; LinkedList consuma mai mult, din cauza celor doi pointeri pastrati de fiecare nod.",
                    "Ambele accepta elemente nule.",
                    "LinkedList ofera metode suplimentare pentru capete, precum addFirst, addLast, pollFirst si pollLast."
                ],
                Essentials =
                [
                    "ArrayList pentru acces aleator rapid si date relativ stabile; LinkedList pentru inserari si stergeri frecvente fara nevoie de acces aleator.",
                    "Redimensionarea tabloului este operatia costisitoare de la ArrayList. LinkedList nu are nevoie de ea."
                ]
            },

            new Lesson
            {
                Id = "jm6-l4",
                Title = "HashMap si HashSet",
                Objective = "HashMap si HashSet",
                Pages = "p62-65",
                Intro = P("""
                    Una asociaza chei cu valori, cealalta retine elemente unice. Detaliul care leaga
                    cele doua explica de ce se comporta aproape identic.
                    """),
                Points =
                [
                    "HashMap implementeaza Map si stocheaza perechi cheie-valoare; HashSet implementeaza Set si stocheaza doar elemente unice.",
                    "HashSet foloseste intern un HashMap, in care elementele sunt chei, iar valorile o constanta, adesea null.",
                    "Complexitatea medie este O(1) pentru get si put la HashMap, respectiv pentru add, remove si contains la HashSet.",
                    "HashMap permite valori duplicate, dar nu chei duplicate; HashSet nu permite elemente duplicate.",
                    "HashMap accepta o singura cheie nula si oricate valori nule; HashSet accepta un singur element nul.",
                    "Niciuna nu mentine vreo ordine si niciuna nu este sincronizata."
                ],
                Essentials =
                [
                    "Cheia identifica, valoarea insoteste. De aici decurg regulile despre duplicate si despre valorile nule.",
                    "La verificarea prezentei intr-o lista se compara si ce returneaza hashCode, nu doar equals."
                ]
            }
        ]
    };

    private static TrainingModule Modul7() => new()
    {
        Id = "jm7",
        Title = "Concepte avansate de programare Java",
        Domain = JavaDomains.Ch7,
        Reference = "Cartea de Java, cap. 7: Concepte avansate",
        Pages = "cap. 7, p69-98",
        Blurb = "Exceptii, jurnalizare, fire de executie, sincronizare, intrari, iesiri si lambda.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm7-l1",
                Title = "Exceptii si tratarea lor",
                Objective = "Tratarea exceptiilor",
                Pages = "p69-73",
                Intro = P("""
                    Exceptiile sunt modul in care Java trateaza erorile aparute la executie. Fara
                    tratare, ele opresc brusc programul.
                    """),
                Points =
                [
                    "Exceptiile sunt anomalii aparute in timpul executiei; netratate, provoaca oprirea brusca a programului.",
                    "Mecanismul de tratare este try-catch, cu un bloc try monitorizat si unul sau mai multe blocuri catch pentru tipuri diferite de exceptii.",
                    "Blocul finally contine cod executat dupa incheierea blocului try.",
                    "Daca metoda in care apare exceptia nu o prinde, exceptia este transmisa metodei apelante, si tot asa in sus pe lantul de apeluri.",
                    "Daca nicio metoda nu prinde exceptia, programul se opreste brusc si mesajul de eroare este afisat la iesire.",
                    "Ierarhia porneste de la Throwable, sub care se afla Exception si Error, iar sub Exception se afla RuntimeException."
                ],
                Essentials =
                [
                    "throw arunca efectiv o exceptie in corpul metodei; throws o declara in antetul metodei.",
                    "Blocurile try-catch pot fi imbricate, iar o exceptie prinsa poate fi rearuncata.",
                    "Exceptiile proprii se creeaza extinzand clasa Exception, iar cauza initiala se obtine cu getCause."
                ]
            },

            new Lesson
            {
                Id = "jm7-l2",
                Title = "Strategii de tratare si jurnalizare",
                Objective = "Strategii de tratare a exceptiilor",
                Pages = "p73-75",
                Intro = P("""
                    A prinde o exceptie este doar jumatate din treaba. Cartea enumera opt strategii
                    despre ce sa faci mai departe, dintre care jurnalizarea este detaliata separat.
                    """),
                Points =
                [
                    "Jurnalizati exceptia: inregistrati intreaga stiva de apeluri, oferiti context despre operatiile in desfasurare si nu inregistrati informatii sensibile.",
                    "Comunicati cu utilizatorul intr-un limbaj lipsit de jargon si oferiti indicatii despre pasii urmatori.",
                    "Incercati recuperarea sau functionarea in regim degradat, acolo unde este posibil.",
                    "Rearuncati sau inlantuiti exceptii, util in straturile de abstractizare, unde o exceptie de nivel jos este tradusa in una de nivel inalt.",
                    "Reincercati operatia pentru esecuri tranzitorii, folosind mecanisme precum asteptarea exponentiala.",
                    "Eliberati resursele, precum conexiuni la baze de date, fisiere sau socluri de retea, si incheiati elegant daca recuperarea nu este posibila."
                ],
                Essentials =
                [
                    "Nivelurile de jurnal, in ordinea gravitatii, sunt Debug, Info, Warning, Error si Fatal sau Critical.",
                    "Bibliotecile uzuale sunt Log4j, SLF4J ca fatada peste alte biblioteci, java.util.logging inclusa in SDK si Logback, considerat succesorul Log4j."
                ]
            },

            new Lesson
            {
                Id = "jm7-l3",
                Title = "Fire de executie",
                Objective = "Fire de executie",
                Pages = "p75-80",
                Intro = P("""
                    Concurenta este capacitatea unui program de a executa mai multe sarcini in
                    acelasi timp. In Java se obtine prin fire de executie.
                    """),
                Points =
                [
                    "Un fir de executie este o secventa de instructiuni dintr-un proces, executata in paralel cu alte secvente similare.",
                    "Spre deosebire de o functie simpla, un fir permite rularea codului in paralel cu alte secvente.",
                    "Firele pot fi sincronizate si pot comunica prin mesaje sau prin apeluri de functii.",
                    "Orice aplicatie are un fir principal, accesibil prin Thread.currentThread.",
                    "Un fir se creeaza fie implementand interfata Runnable, fie extinzand clasa Thread.",
                    "Punctul de intrare al firului este metoda run, iar firul se porneste prin apelul metodei start."
                ],
                Essentials =
                [
                    "isAlive spune daca un fir mai ruleaza sau s-a incheiat; join face ca un fir sa astepte incheierea altuia.",
                    "join se foloseste pentru executie secventiala, pentru dependente de resurse, pentru a asigura incheierea firelor inainte de curatare si pentru a evita problemele de concurenta."
                ]
            },

            new Lesson
            {
                Id = "jm7-l4",
                Title = "Sincronizare",
                Objective = "Sincronizare",
                Pages = "p80-82",
                Intro = P("""
                    Cand mai multe fire ating aceleasi date, ordinea acceselor incepe sa conteze.
                    Sincronizarea exista pentru a face comportamentul previzibil.
                    """),
                Points =
                [
                    "O conditie de cursa apare cand doua sau mai multe fire acceseaza si incearca sa modifice simultan date partajate, iar ordinea acceselor afecteaza rezultatul.",
                    "Sincronizarea asigura ca un singur fir acceseaza resursa partajata la un moment dat.",
                    "Fara sincronizare, firele ar putea citi valori invechite sau incorecte din resursele partajate.",
                    "Sincronizarea poate garanta ordinea de executie atunci cand anumite procese trebuie sa se petreaca intr-o anumita secventa.",
                    "Interblocajul apare cand doua sau mai multe fire asteapta la infinit resurse, fiecare detinand un blocaj si asteptand altul.",
                    "Prin controlul accesului la resursele partajate, sincronizarea evita irosirea ciclurilor de procesor."
                ],
                Essentials =
                [
                    "Conditia de cursa si interblocajul sunt probleme diferite. Prima tine de ordinea acceselor, a doua de asteptarea reciproca.",
                    "Metodele wait, notify si notifyAll din clasa Object servesc la comunicarea intre fire."
                ]
            },

            new Lesson
            {
                Id = "jm7-l5",
                Title = "Expresii lambda",
                Objective = "Expresii lambda",
                Pages = "p93-97",
                Intro = P("""
                    Introduse in Java 8, expresiile lambda ofera un mod concis de a reprezenta
                    interfetele functionale, apropiind limbajul de stilul functional.
                    """),
                Points =
                [
                    "O interfata functionala contine exact o singura metoda abstracta, putand avea si metode implicite sau statice.",
                    "Sintaxa este parametri, apoi sageata, apoi o expresie sau un bloc de instructiuni intre acolade.",
                    "Fara parametri se scriu paranteze rotunde goale; pentru un singur parametru tipul poate fi omis.",
                    "Lambda se foloseste des cu interfete functionale predefinite precum Predicate, Function si Consumer.",
                    "Combinate cu Stream API, expresiile lambda permit filtrarea, transformarea si parcurgerea colectiilor intr-un stil declarativ.",
                    "Avantajele sunt concizia, capabilitatile de programare functionala, lizibilitatea si integrarea cu Stream API."
                ],
                Essentials =
                [
                    "Lambda cere Java 8 sau mai nou. Nu asigura compatibilitatea cu versiuni mai vechi.",
                    "Serializarea transforma un obiect intr-o forma care poate fi salvata sau transmisa si apoi reconstruita."
                ]
            }
        ]
    };

    private static TrainingModule Modul8() => new()
    {
        Id = "jm8",
        Title = "Colectii Java in detaliu",
        Domain = JavaDomains.Ch8,
        Reference = "Cartea de Java, cap. 8: Colectii avansate",
        Pages = "cap. 8, p99-114",
        Blurb = "TreeSet, sortare cu Comparable si Comparator, Dictionary si HashTable.",
        Lessons =
        [
            new Lesson
            {
                Id = "jm8-l1",
                Title = "TreeSet si arborele rosu-negru",
                Objective = "TreeSet si arbori rosu-negru",
                Pages = "p99-101",
                Intro = P("""
                    TreeSet este varianta ordonata a multimii. Ordinea nu vine gratuit: ea este
                    produsa de o structura de date anume, cu reguli proprii.
                    """),
                Points =
                [
                    "TreeSet functioneaza asemanator cu HashSet, dar mentine elementele intr-o ordine.",
                    "Elementele sunt organizate intr-un arbore echilibrat, mai exact un arbore rosu-negru.",
                    "Costul cautarii devine logaritmic, cu complexitate O(log n).",
                    "Regulile arborelui: fiecare nod este rosu sau negru; radacina este intotdeauna neagra; copiii unui nod rosu trebuie sa fie negri; fiecare drum de la radacina la frunze contine acelasi numar de noduri negre.",
                    "Metodele first si last returneaza primul si ultimul element, iar headSet, tailSet si subSet returneaza submultimi.",
                    "Metoda comparator returneaza obiectul de comparare folosit de multime."
                ],
                Essentials =
                [
                    "Collections.reverseOrder() returneaza un comparator care impune inversul ordinii naturale pentru obiecte care implementeaza Comparable.",
                    "Metodele de pozitie precum first si last nu ar avea sens la o multime neordonata. Existenta lor este consecinta ordonarii."
                ]
            },

            new Lesson
            {
                Id = "jm8-l2",
                Title = "Sortarea colectiilor",
                Objective = "Sortarea colectiilor",
                Pages = "p101-104",
                Intro = P("""
                    Exista doua cai de a sorta o colectie, si ele difera prin locul in care este
                    scrisa regula de ordonare: inauntrul clasei sau in afara ei.
                    """),
                Points =
                [
                    "Prima cale este implementarea interfetei Comparable, care are o singura metoda, compareTo.",
                    "compareTo defineste cum sunt comparate si deci sortate obiectele, iar valoarea returnata exprima pozitia relativa in ordinea naturala.",
                    "Conditiile pentru compareTo: elementele sa fie comparabile intre ele, ordinea naturala sa se bazeze pe equals, iar metoda sa nu fie apelata niciodata direct.",
                    "Multe clase din Java implementeaza deja Comparable: String alfabetic, Date cronologic, Integer si Double numeric cu semn, File alfabetic dupa cale.",
                    "A doua cale este un Comparator, folosit cand nu se doreste ordinea naturala sau cand clasele nu implementeaza Comparable.",
                    "Metoda compare din Comparator primeste doua obiecte si le compara intre ele, spre deosebire de compareTo, care primeste unul singur."
                ],
                Essentials =
                [
                    "Comparatorul se transmite constructorului colectiei si devine regula de ordonare a acesteia.",
                    "compareTo apartine clasei care se compara pe sine; compare apartine unui comparator extern. Numarul de parametri este indiciul."
                ]
            },

            new Lesson
            {
                Id = "jm8-l3",
                Title = "Dictionary, HashTable si Properties",
                Objective = "Dictionary, HashTable si Properties",
                Pages = "p104-107",
                Intro = P("""
                    Ultima familie de colectii pastreaza pe fiecare pozitie o pereche formata dintr-o
                    cheie si o valoare.
                    """),
                Points =
                [
                    "Dictionary este o clasa abstracta care contine doar metode abstracte.",
                    "Analogia folosita este agenda telefonica: numele persoanei este cheia unica, iar numarul de telefon valoarea.",
                    "Metodele importante din Dictionary sunt elements, get, isEmpty, keys, put, remove si size.",
                    "HashTable este o implementare concreta a clasei Dictionary, care foloseste un algoritm de dispersie pentru cautari rapide.",
                    "Functia de dispersie converteste cheile in coduri de dispersie, care accelereaza cautarile.",
                    "Operatiile de inserare lucreaza in general in timp constant, O(1), dar coliziunile de dispersie pot reduce eficienta."
                ],
                Essentials =
                [
                    "containsKey cauta printre chei, containsValue printre valori. Numele spune unde se uita fiecare.",
                    "In exemplul de numarare a cuvintelor, cheia este cuvantul citit din fisier, iar valoarea numarul de aparitii."
                ]
            }
        ]
    };
}
