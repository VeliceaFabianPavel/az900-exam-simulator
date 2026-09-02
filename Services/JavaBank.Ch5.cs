using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 5: Programare orientata pe obiecte avansata (p47-56 in carte, p55-64 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J5 = JavaDomains.Ch5;
    private const string R5 = "Cartea de Java, cap. 5: POO avansata";

    private static IEnumerable<Item> Chapter5()
    {
        // ---------------------------------------------------------- clase abstracte

        yield return Mc("j5-001", J5, "Metode si clase abstracte", R5,
            """
            Ce este o metoda abstracta si cum se scrie declaratia ei?
            """,
            [
                "O metoda fara corp definit, care are doar semnatura, iar declaratia se incheie cu punct si virgula.",
                "O metoda cu corp gol, delimitat de acolade, care returneaza valoarea implicita a tipului.",
                "O metoda care nu poate fi apelata decat din clasa in care este declarata.",
                "O metoda declarata static, care apartine clasei si nu unei instante."
            ], "A",
            """
            O metoda abstracta nu are corp definit, ci doar semnatura, iar declaratia functiei se
            incheie cu punct si virgula, la fel ca orice declaratie obisnuita.

            Situatia in care este utila apare atunci cand o superclasa, precum o forma geometrica
            generala, trebuie sa declare o operatie precum aria sau perimetrul, dar nu poate sti cum
            se calculeaza aceasta atat timp cat forma concreta nu este cunoscuta.
            """,
            """
            Deosebirea fata de o metoda obisnuita se vede la finalul declaratiei: ce urmeaza dupa
            lista de parametri?
            """);

        yield return Mc("j5-002", J5, "Metode si clase abstracte", R5,
            """
            Care doua afirmatii despre clasele abstracte sunt corecte? Fiecare raspuns corect
            reprezinta o parte a solutiei.
            """,
            [
                "Orice clasa care contine o metoda abstracta este automat abstracta si trebuie declarata ca atare.",
                "O clasa poate fi declarata abstracta chiar daca nu contine nicio metoda abstracta.",
                "O clasa abstracta poate fi instantiata daca toate metodele ei abstracte au corp gol.",
                "O clasa declarata final poate contine metode abstracte.",
                "O metoda declarata static poate fi abstracta."
            ], "A,B",
            """
            Orice clasa care contine o metoda abstracta este automat abstracta si trebuie declarata
            ca atare. In sens invers, o clasa poate fi declarata abstracta chiar daca nu contine
            metode abstracte, ceea ce semnaleaza de obicei ca este incompleta si serveste drept clasa
            parinte pentru una sau mai multe clase copil.

            Celelalte trei afirmatii sunt false. O clasa abstracta nu poate fi instantiata. Metodele
            declarate static, private sau final nu pot fi abstracte, pentru ca niciuna dintre ele nu
            poate fi suprascrisa de subclase, iar o clasa declarata final nu poate contine metode
            abstracte.
            """,
            """
            Regula merge intr-o singura directie automat. Verificati daca si reciproca este
            obligatorie.
            """);

        yield return Mc("j5-003", J5, "Metode si clase abstracte", R5,
            """
            O clasa copil mosteneste de la o superclasa abstracta, dar nu implementeaza toate
            metodele abstracte mostenite.

            Ce se intampla?
            """,
            [
                "Clasa copil devine si ea abstracta si trebuie declarata ca atare.",
                "Clasa copil se compileaza normal, iar metodele neimplementate returneaza valori implicite.",
                "Compilarea esueaza definitiv, indiferent cum este declarata clasa copil.",
                "Metodele neimplementate sunt mostenite cu implementarea din superclasa."
            ], "A",
            """
            O subclasa a unei clase abstracte poate fi instantiata doar daca suprascrie metodele
            abstracte ale parintelui si ofera o implementare pentru toate acestea. Astfel de clase
            copil se numesc concrete, tocmai pentru a sublinia ca nu sunt abstracte.

            Daca o clasa copil nu implementeaza toate metodele abstracte mostenite, atunci ea este la
            randul ei abstracta si va fi declarata ca atare. Nu este o eroare, ci o continuare a
            ierarhiei; metodele abstracte nu au implementare in superclasa, deci nu au ce mosteni.
            """,
            """
            Rezultatul nu este neaparat o eroare. Intrebati-va ce devine clasa copil in acest caz.
            """);

        yield return Mc("j5-004", J5, "Metode si clase abstracte", R5,
            """
            Un tablou este declarat de tipul superclasei abstracte <code>Shape</code> si contine
            obiecte de tip <code>Circle</code>. Incercarea de a accesa constanta <code>PI</code>,
            declarata publica in <code>Circle</code>, produce eroare de compilare.

            De ce?
            """,
            [
                "Pentru ca elementele tabloului sunt vazute ca fiind de tipul Shape, iar PI este specific subclasei, nu parintelui.",
                "Pentru ca o constanta declarata public static final nu poate fi accesata din afara clasei.",
                "Pentru ca o clasa abstracta nu poate avea tablouri de obiecte.",
                "Pentru ca elementele tabloului nu au fost instantiate inainte de acces."
            ], "A",
            """
            Desi toate obiectele din tablou sunt de tip Shape, primul si ultimul sunt in realitate de
            tip Circle, iar celelalte de tip Rectangle. Instantierea are loc cu subclase ale
            parintelui, dar tipul declarat al elementelor ramane cel al superclasei.

            Daca un obiect este vazut ca fiind de tip Shape, nu se poate apela un membru al clasei
            Circle, chiar daca acel membru este public. Compilatorul raporteaza ca simbolul nu poate
            fi gasit in clasa Shape.
            """,
            """
            Priviti tipul declarat al elementelor tabloului, nu tipul obiectelor pe care le contine
            efectiv.
            """);

        // ---------------------------------------------------------- interfete

        yield return Mc("j5-005", J5, "Interfete", R5,
            """
            Prin ce se deosebeste o interfata de o clasa abstracta, in privinta corpului metodelor si
            a numarului de tipuri pe care le poate prelua o clasa?
            """,
            [
                "Intr-o interfata nicio metoda nu poate avea corp, iar o clasa poate implementa una sau mai multe interfete.",
                "Intr-o interfata metodele pot avea corp, iar o clasa poate implementa o singura interfata.",
                "Intr-o interfata nicio metoda nu poate avea corp, iar o clasa poate implementa o singura interfata.",
                "Interfata si clasa abstracta sunt echivalente; deosebirea este doar de cuvant cheie."
            ], "A",
            """
            Interfetele sunt asemanatoare claselor abstracte, dar intr-o interfata nicio metoda nu
            are voie sa aiba corp, adica implementare. In plus, o clasa poate implementa una sau mai
            multe interfete.

            Pentru ca implementarea unei interfete sa fie corecta, clasa trebuie sa ofere
            implementari pentru metodele declarate in interfata. Fiecare clasa poate avea propria
            implementare pentru acele metode.
            """,
            """
            Doua deosebiri conteaza aici: ce se poate scrie in interfata si de cate astfel de tipuri
            poate depinde o clasa.
            """);

        yield return Mc("j5-006", J5, "Interfete", R5,
            """
            Ce conditii trebuie sa indeplineasca variabilele declarate intr-o interfata?
            """,
            [
                "Trebuie sa fie public, final si static, si trebuie initializate; practic sunt constante.",
                "Trebuie sa fie private si initializate in constructorul interfetei.",
                "Trebuie sa fie variabile de instanta, initializate de fiecare clasa care implementeaza interfata.",
                "Nu pot exista variabile intr-o interfata, ci doar metode."
            ], "A",
            """
            Variabilele declarate intr-o interfata nu sunt variabile de instanta. Ele trebuie
            declarate public, final si static, si trebuie initializate. Practic, sunt constante.

            Constantele declarate intr-o interfata sunt implicit publice, statice si finale. O
            interfata nu poate defini un constructor, deci varianta care mentioneaza initializarea in
            constructor este imposibila din start.
            """,
            """
            Cei trei modificatori impreuna descriu un singur lucru familiar din alte limbaje.
            """);

        yield return Mc("j5-007", J5, "Interfete", R5,
            """
            Ce cuvinte cheie se folosesc pentru ca o interfata sa preia alta interfata, respectiv
            pentru ca o clasa sa preia o interfata?
            """,
            [
                "O interfata extinde alta interfata cu extends, iar o clasa preia o interfata cu implements.",
                "O interfata extinde alta interfata cu implements, iar o clasa preia o interfata cu extends.",
                "Ambele folosesc implements.",
                "Ambele folosesc extends."
            ], "A",
            """
            Interfetele pot extinde alte interfete folosind cuvantul cheie extends. Cand o interfata
            extinde alta interfata, mosteneste toate metodele abstracte ale interfetei parinte si
            poate declara metode si constante suplimentare. O interfata poate extinde chiar mai multe
            interfete deodata.

            La fel cum o clasa foloseste extends pentru a mosteni de la o clasa parinte, ea foloseste
            implements pentru a prelua interfete. Cele doua cuvinte cheie nu sunt interschimbabile.
            """,
            """
            Cuvantul cheie depinde de ce tip face preluarea, nu de ce tip este preluat.
            """);

        yield return Mc("j5-008", J5, "Interfete", R5,
            """
            Ce se intampla daca o clasa declara <code>implements</code> pentru o interfata, dar nu
            ofera implementare pentru toate metodele acesteia?
            """,
            [
                "Mosteneste acele metode ca fiind abstracte si devine ea insasi abstracta.",
                "Se compileaza normal, iar metodele lipsa primesc o implementare goala generata automat.",
                "Compilarea esueaza, fara nicio alternativa.",
                "Metodele lipsa sunt preluate din interfata cu implementarea implicita a acesteia."
            ], "A",
            """
            Cand o clasa preia o interfata, ea ofera o implementare pentru toate metodele interfetei.
            Daca o clasa implementeaza o interfata fara sa ofere o implementare pentru fiecare metoda,
            va mosteni acele metode abstracte si va deveni ea insasi abstracta.

            Comportamentul este acelasi ca la mostenirea dintr-o clasa abstracta cu metode
            neimplementate. Interfata nu are implementari implicite de oferit, de vreme ce metodele
            ei nu au corp.
            """,
            """
            Comparati cu ce se intampla cand o subclasa nu implementeaza toate metodele abstracte
            mostenite.
            """);

        yield return Drag("j5-009", J5, "Interfete si clase abstracte", R5,
            """
            Potriviti fiecare afirmatie cu tipul caruia i se aplica. Fiecare tip poate fi folosit o
            data, de mai multe ori sau deloc.
            """,
            "Tipuri",
            [
                "Interfata",
                "Clasa abstracta"
            ],
            [
                ("Nicio metoda nu poate avea corp", 1),
                ("Poate contine si implementari partiale, folosibile de subclase", 2),
                ("O clasa poate prelua mai multe de acest fel", 1),
                ("O clasa care o extinde nu mai poate extinde altceva", 2),
                ("Adaugarea unei metode noi strica clasele care o preluau deja", 1)
            ],
            """
            Deosebirile decurg din doua proprietati. Interfata nu permite corp de metoda, dar poate
            fi preluata de orice clasa si in numar oricat de mare. Clasa abstracta poate contine cel
            putin o implementare partiala pe care subclasele o pot folosi, insa o clasa care o extinde
            nu mai poate extinde altceva.

            Ultimul rand priveste compatibilitatea. Daca se adauga o metoda unei interfete dintr-o
            biblioteca, clasele care implementau versiunea anterioara se strica, pentru ca nu mai
            implementeaza corect noua interfata. Cu o clasa abstracta se pot adauga metode
            neabstracte fara a afecta clasele care o mostenesc.
            """,
            """
            Ultimul rand este argumentul de compatibilitate din carte. Ganditi-va ce se intampla cu
            codul deja scris cand tipul se schimba.
            """);

        yield return Mc("j5-010", J5, "Interfete si clase abstracte", R5,
            """
            De ce recomanda cartea, in general, folosirea unei interfete in locul unei clase
            abstracte la definirea unui tip de date?
            """,
            [
                "Pentru ca orice clasa o poate implementa, chiar daca extinde deja o alta superclasa fara legatura cu interfata.",
                "Pentru ca o interfata se compileaza mai rapid decat o clasa abstracta.",
                "Pentru ca o interfata poate contine implementari partiale, iar clasa abstracta nu.",
                "Pentru ca o interfata poate fi instantiata direct, spre deosebire de clasa abstracta."
            ], "A",
            """
            Interfata este recomandata pentru ca orice clasa o poate implementa, chiar si atunci cand
            acea clasa extinde deja o alta superclasa care nu are nicio legatura cu interfata. Aceasta
            este limitarea reala a claselor abstracte: o clasa care extinde o clasa abstracta nu mai
            poate extinde altceva.

            Contra-argumentul mentionat este ca, atunci cand o interfata contine multe metode,
            implementarea tuturor devine greoaie pentru fiecare clasa care o preia. Nici interfata,
            nici clasa abstracta nu pot fi instantiate.
            """,
            """
            Motivul tine de o limitare a mostenirii in Java, nu de performanta.
            """);

        yield return Mc("j5-011", J5, "Interfete", R5,
            """
            Care doua afirmatii despre interfete sunt corecte? Fiecare raspuns corect reprezinta o
            parte a solutiei.
            """,
            [
                "O interfata nu poate fi instantiata.",
                "O interfata nu poate defini un constructor.",
                "Metodele unei interfete sunt implicit private.",
                "O interfata poate extinde cel mult o singura alta interfata.",
                "O interfata trebuie declarata obligatoriu public."
            ], "A,B",
            """
            O interfata nu poate fi instantiata si nu poate defini un constructor. Ambele decurg din
            faptul ca ea descrie doar ce trebuie facut, nu si cum.

            Metodele unei interfete sunt implicit publice, nu private. O interfata poate extinde mai
            multe interfete deodata. Iar accesul poate fi public sau poate lipsi cu totul din
            declaratie.
            """,
            """
            Doua dintre variantele gresite inverseaza o valoare implicita, iar a treia impune o
            limita care nu exista.
            """);

        yield return Mc("j5-012", J5, "Clase abstracte in practica", R5,
            """
            Poate o clasa abstracta sa contina si metode concrete, cu corp?
            """,
            [
                "Da, poate contine metode concrete alaturi de cele abstracte, iar subclasele le pot folosi direct.",
                "Nu, toate metodele unei clase abstracte trebuie sa fie abstracte.",
                "Da, dar numai daca acele metode sunt declarate static.",
                "Nu, decat daca clasa implementeaza si o interfata."
            ], "A",
            """
            In clasa parinte abstracta pot exista metode concrete pe langa cele abstracte. Exemplul
            din carte este o metoda care afiseaza categoria formei, apelabila pe orice element al
            tabloului de forme.

            Aceasta este chiar deosebirea fata de interfata: o clasa abstracta nu trebuie sa fie in
            intregime abstracta si poate contine cel putin o implementare partiala pe care subclasele
            o pot folosi.
            """,
            """
            Daca raspunsul ar fi nu, deosebirea principala fata de interfete ar disparea.
            """);

        yield return Dropdowns("j5-013", J5, "Metode si clase abstracte", R5,
            """
            Alegeti varianta care completeaza corect fiecare afirmatie despre clasele abstracte.
            """,
            [
                ("O clasa abstracta poate fi",
                    ["instantiata direct", "doar extinsa, nu instantiata", "doar implementata", "doar folosita ca parametru"], 2),
                ("O subclasa care implementeaza toate metodele abstracte se numeste",
                    ["abstracta", "concreta", "finala", "statica"], 2),
                ("O metoda declarata final",
                    ["poate fi abstracta", "nu poate fi abstracta", "devine automat abstracta", "trebuie sa fie abstracta"], 2),
                ("O clasa declarata final",
                    ["poate contine metode abstracte", "nu poate contine metode abstracte", "devine automat abstracta", "trebuie sa extinda o clasa abstracta"], 2)
            ],
            """
            O clasa abstracta nu poate fi instantiata, ci doar extinsa. Subclasa care suprascrie si
            implementeaza toate metodele abstracte ale parintelui se numeste concreta, tocmai pentru
            a sublinia ca nu mai este abstracta.

            Ultimele doua randuri decurg din aceeasi regula: metodele declarate static, private sau
            final nu pot fi abstracte, pentru ca niciuna nu poate fi suprascrisa de subclase, iar o
            clasa declarata final nu poate contine metode abstracte.
            """,
            """
            Ultimele doua randuri au acelasi motiv la baza: o metoda abstracta trebuie sa poata fi
            suprascrisa.
            """);

        yield return Mc("j5-014", J5, "Interfete", R5,
            """
            In exemplul din carte, clasa <code>CenteredRectangle</code> extinde
            <code>Rectangle</code> si implementeaza interfata <code>Centered</code>.

            Ce arata aceasta constructie?
            """,
            [
                "Ca o clasa poate mosteni de la o superclasa si, in acelasi timp, sa preia una sau mai multe interfete.",
                "Ca o clasa poate mosteni de la mai multe superclase, daca cel putin una este interfata.",
                "Ca interfetele inlocuiesc mostenirea, deci extends devine optional.",
                "Ca o interfata poate fi extinsa doar de clase care mostenesc deja de la alta clasa."
            ], "A",
            """
            Forma generala a declaratiei permite o clauza extends optionala, pentru cazul in care
            clasa extinde o alta clasa obisnuita, si o clauza implements, care permite preluarea
            uneia sau mai multor interfete.

            Este exact ceea ce se intampla in exemplu: fiind vorba de o forma geometrica de tip
            dreptunghi, clasa mosteneste de la Rectangle si, in plus, implementeaza interfata
            Centered. Java nu permite mostenirea de la mai multe clase, dar permite implementarea mai
            multor interfete.
            """,
            """
            Numarati cate clase si cate interfete apar in declaratie si comparati cu ce permite Java.
            """);
    }
}
