using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 4: Programare orientata pe obiecte (p31-46 in carte, p39-54 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J4 = JavaDomains.Ch4;
    private const string R4 = "Cartea de Java, cap. 4: POO";

    private static IEnumerable<Item> Chapter4()
    {
        // ---------------------------------------------------------- clase si obiecte

        yield return Mc("j4-001", J4, "Clase si obiecte", R4,
            """
            Ce este o clasa in Java si ce relatie are cu un obiect?
            """,
            [
                "Clasa este un sablon care defineste proprietatile si metodele pe care le va avea un obiect al acelei clase; obiectul este o instanta a sablonului.",
                "Clasa este o instanta a unui obiect, creata cu operatorul new.",
                "Clasa este o colectie de obiecte pastrate in memorie, iar obiectul este o referinta catre ea.",
                "Clasa si obiectul sunt doua nume pentru acelasi lucru, folosite in contexte diferite."
            ], "A",
            """
            In Java, o clasa este un sablon pentru un obiect. Ea defineste proprietatile si metodele
            pe care le va avea un obiect al acelei clase.

            Obiectul se creeaza cu operatorul new, urmat de numele clasei si de argumentele cerute de
            constructor. Relatia merge deci de la sablon catre instanta, nu invers: o bicicleta anume
            este o instanta a clasei Bicicleta.
            """,
            """
            Unul dintre cele doua este planul, celalalt este lucrul construit dupa plan. Stabiliti
            care este care.
            """);

        yield return Mc("j4-002", J4, "Clase si obiecte", R4,
            """
            Obiectele din lumea reala au doua caracteristici comune, care se regasesc si in modelarea
            software.

            Care sunt acestea si cum sunt reprezentate in cod?
            """,
            [
                "Starea, reprezentata prin variabile, si comportamentul, reprezentat prin metode.",
                "Starea, reprezentata prin metode, si comportamentul, reprezentat prin variabile.",
                "Tipul, reprezentat prin clasa, si valoarea, reprezentata prin constructor.",
                "Numele, reprezentat prin identificator, si adresa, reprezentata prin referinta."
            ], "A",
            """
            Obiectele reale au in comun starea si comportamentul. Un animal are stari precum nume,
            culoare sau specie, si comportamente precum modul de deplasare sau hranirea.

            In programare, starea este modelata prin una sau mai multe variabile, iar comportamentul
            prin metode. Tot ce se stie despre un obiect reprezinta starea lui, iar ce poate face
            reprezinta comportamentul lui.
            """,
            """
            Un aspect raspunde la intrebarea "ce este", celalalt la intrebarea "ce poate face".
            Asociati fiecaruia constructia din cod potrivita.
            """);

        yield return Mc("j4-003", J4, "Incapsulare", R4,
            """
            Ce se intelege prin incapsulare si prin ce mijloace este realizata in Java?
            """,
            [
                "Ascunderea detaliilor interne ale unui obiect si expunerea doar a informatiei necesare, prin modificatori de acces si metode de tip getter si setter.",
                "Gruparea mai multor clase intr-un pachet, prin cuvantul cheie package.",
                "Copierea automata a unui obiect la atribuire, prin metoda clone.",
                "Ascunderea claselor unei biblioteci de restul aplicatiei, prin compilarea lor separata."
            ], "A",
            """
            Incapsularea este procesul de ascundere a detaliilor interne ale unui obiect si de
            expunere doar a informatiei necesare lumii exterioare. Impachetarea variabilelor unui
            obiect pentru a proteja informatia pe care o contin poarta acest nume.

            In Java se realizeaza prin modificatorii de acces, adica public, private, protected si
            cel implicit, impreuna cu metodele de acces de tip getter si setter.
            """,
            """
            Cuvantul se refera la ce vede lumea din afara obiectului, nu la felul in care sunt
            organizate fisierele.
            """);

        yield return Mc("j4-004", J4, "Incapsulare", R4,
            """
            Care doua avantaje ofera folosirea metodelor de tip getter si setter in locul accesului
            direct la campuri? Fiecare raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Permit controlul accesului la membrii privati, prevenind modificari nedorite.",
                "Permit modificarea detaliilor de implementare ale clasei fara a afecta codul exterior care o foloseste.",
                "Reduc dimensiunea fisierului .class rezultat la compilare.",
                "Fac inutila folosirea modificatorilor de acces.",
                "Garanteaza ca obiectul devine imutabil."
            ], "A,B",
            """
            Getterele si setterele permit controlul accesului la membrii privati ai unei clase, ceea
            ce previne modificarile nedorite si asigura integritatea datelor. Setterele pot in plus
            impune constrangeri asupra valorilor primite, de exemplu verificarea validitatii sau
            incadrarea intr-un interval.

            Al doilea avantaj este flexibilitatea: implementarea interna a clasei poate fi schimbata
            fara a afecta codul din afara care o foloseste. Ele nu inlocuiesc modificatorii de acces,
            ci lucreaza impreuna cu ei, si nu fac obiectul imutabil, de vreme ce setterul exista tocmai
            pentru a-l modifica.
            """,
            """
            O varianta sustine ca aceste metode fac inutil ceva care este de fapt conditia lor de
            functionare.
            """);

        // ---------------------------------------------------------- constructori

        yield return Mc("j4-005", J4, "Constructori", R4,
            """
            Ce este un constructor si prin ce se deosebeste de o metoda obisnuita?
            """,
            [
                "Este o metoda care initializeaza obiectul la creare, poarta acelasi nume cu clasa si nu returneaza nimic.",
                "Este o metoda care elibereaza memoria obiectului, poarta acelasi nume cu clasa si returneaza un boolean.",
                "Este o metoda statica apelata inaintea metodei main, cu numele init.",
                "Este o metoda care poate fi apelata explicit oricand pentru a reinitializa obiectul."
            ], "A",
            """
            Un constructor este o metoda care initializeaza un obiect atunci cand acesta este creat
            cu operatorul new. Poarta acelasi nume cu clasa si nu returneaza nimic.

            Rolul lui este sa creeze proceduri de initializare care sa dea forma noului obiect.
            Alternativa, initializarea membrilor unul cate unul dupa creare, nu este profesionista,
            pentru ca programatorul poate omite cu usurinta un membru atunci cand clasa are multi
            membri.
            """,
            """
            Doua trasaturi il fac usor de recunoscut in cod: numele lui si ceea ce lipseste din
            antetul lui.
            """);

        yield return Mc("j4-006", J4, "Constructori", R4,
            """
            O clasa are trei constructori: unul fara parametri, unul cu un parametru si unul cu doi
            parametri.

            Cum decide compilatorul care constructor se apeleaza la <code>new</code>?
            """,
            [
                "Dupa tipul si numarul argumentelor folosite in apel: se apeleaza constructorul ai carui parametri corespund.",
                "Se apeleaza intotdeauna constructorul fara parametri, iar ceilalti trebuie apelati explicit dupa aceea.",
                "Se apeleaza constructorii in ordinea declararii lor in clasa.",
                "Se apeleaza constructorul cu cei mai multi parametri, iar cei lipsa primesc valori implicite."
            ], "A",
            """
            Cand se foloseste operatorul new pentru a crea un obiect, se apeleaza constructorul ai
            carui parametri sunt de acelasi tip cu cei folositi in apel.

            Este acelasi mecanism ca la supraincarcarea metodelor: numele este identic, iar lista de
            parametri decide. Nu exista o ordine implicita si nici completare automata a parametrilor
            lipsa.
            """,
            """
            Este acelasi criteriu de selectie ca la metodele supraincarcate.
            """);

        yield return Mc("j4-007", J4, "Cuvantul cheie this", R4,
            """
            La ce se refera <code>this.b</code> in constructorul de mai jos?
            """,
            [
                "La membrul b al obiectului curent, deosebindu-l de parametrul base al constructorului.",
                "La clasa Power in ansamblu, nu la o instanta anume.",
                "La constructorul clasei parinte, echivalent cu super.",
                "La o variabila statica partajata de toate obiectele de tip Power."
            ], "A",
            """
            Cuvantul this reprezinta instanta curenta a obiectului. Cand se apeleaza o metoda care
            apartine unui obiect din interiorul acelui obiect, se considera implicit ca referinta cu
            care s-a facut apelul este obiectul care il invoca.

            In constructor, instructiunea this.b = base se refera la valoarea b declarata ca membru al
            clasei Power. La crearea unui obiect nou, constructorul initializeaza membrii noului
            obiect, la care se face referire prin this.
            """,
            """
            In constructor exista doua nume apropiate: unul este membru al clasei, celalalt este
            parametru. Cuvantul cheie il indica pe primul.
            """,
            """
            class Power {
                double b;
                int e;
                double val;

                Power(double base, int exp) {
                    this.b = base;
                    this.e = exp;
                    this.val = 1;
                }
            }
            """);

        // ---------------------------------------------------------- supraincarcare

        yield return Mc("j4-008", J4, "Supraincarcarea metodelor", R4,
            """
            Codul de mai jos nu se compileaza. De ce?
            """,
            [
                "Pentru ca doua metode cu acelasi nume si aceeasi lista de parametri nu pot coexista; tipul returnat nu este suficient pentru a le deosebi.",
                "Pentru ca o metoda care returneaza int nu poate afisa nimic pe consola.",
                "Pentru ca metodele supraincarcate trebuie sa fie declarate static.",
                "Pentru ca o clasa nu poate contine doua metode cu acelasi nume in nicio situatie."
            ], "A",
            """
            Supraincarcarea cere ca parametrii sa difere, fie ca tip, fie ca numar. Daca difera doar
            tipul returnat, compilatorul nu poate alege ce metoda sa apeleze, pentru ca tipul returnat
            nu ofera destula informatie pentru a face deosebirea.

            Compilatorul raporteaza ca metoda test(int) este deja definita in clasa. Doua metode cu
            acelasi nume pot coexista perfect, cu conditia ca listele lor de parametri sa fie
            diferite.
            """,
            """
            Comparati cu atentie cele doua antete. Ce difera intre ele si ce ramane identic?
            """,
            """
            class NoOverloadDemo {
                void test(int a) {
                    System.out.println("parametrul int: " + a);
                }

                int test(int a) {
                    return a * a;
                }
            }
            """);

        // ---------------------------------------------------------- mostenire

        yield return Mc("j4-009", J4, "Mostenire", R4,
            """
            Ce cuvant cheie se foloseste pentru a crea o subclasa in Java, si ce se mosteneste?
            """,
            [
                "Cuvantul extends; subclasa mosteneste proprietatile si metodele clasei de baza.",
                "Cuvantul implements; subclasa mosteneste doar semnaturile metodelor.",
                "Cuvantul inherits; subclasa mosteneste doar campurile publice.",
                "Cuvantul super; subclasa mosteneste doar constructorii."
            ], "A",
            """
            Mostenirea este mecanismul care permite unei clase sa preia proprietati si metode de la
            alta clasa. In Java, o subclasa se creeaza folosind cuvantul cheie extends.

            Cuvantul implements se foloseste pentru interfete si va fi tratat in capitolul urmator.
            Cuvantul super serveste la apelarea constructorului sau a membrilor clasei parinte, nu la
            declararea mostenirii.
            """,
            """
            Una dintre variante este cuvantul folosit pentru interfete, alta este folosita in
            interiorul constructorului.
            """);

        yield return Mc("j4-010", J4, "Mostenire", R4,
            """
            Intr-o ierarhie de mostenire, ce parte a obiectului este instantiata de constructorul
            clasei de baza si ce parte de constructorul subclasei?
            """,
            [
                "Constructorul clasei de baza instantiaza portiunea corespunzatoare clasei de baza, iar cel al subclasei portiunea proprie subclasei.",
                "Constructorul subclasei instantiaza intregul obiect, iar cel al clasei de baza nu se apeleaza niciodata.",
                "Constructorul clasei de baza instantiaza intregul obiect, iar cel al subclasei doar il valideaza.",
                "Ambii constructori instantiaza intregul obiect, ceea ce duce la initializare dubla."
            ], "A",
            """
            Atat superclasele cat si subclasele isi pot avea propriii constructori. Raspunsul la
            intrebarea cine instantiaza obiectul este ca fiecare instantiaza portiunea care ii
            corespunde: constructorul superclasei se ocupa de portiunea superclasei, iar cel al
            subclasei de portiunea subclasei.

            Portiunea superclasei este instantiata automat prin apelul constructorului implicit al
            clasei de baza, daca subclasa nu apeleaza explicit un alt constructor.
            """,
            """
            Obiectul are doua portiuni, mostenita si proprie. Fiecare constructor se ocupa de una
            dintre ele.
            """);

        yield return Mc("j4-011", J4, "Mostenire", R4,
            """
            La ce foloseste apelul <code>super(a, b)</code> in constructorul unei subclase?
            """,
            [
                "Apeleaza constructorul clasei de baza cu doi parametri, inlocuind initializarea manuala a membrilor mosteniti.",
                "Creeaza un obiect nou de tipul clasei de baza, separat de obiectul curent.",
                "Apeleaza metoda cu numele super din clasa de baza.",
                "Declara ca subclasa nu are constructor propriu."
            ], "A",
            """
            O subclasa poate apela constructorul superclasei folosind cuvantul cheie super, urmat de
            lista de parametri. In exemplul din carte, cele doua instructiuni care initializau membrii
            clasei Shape2D au fost inlocuite cu un apel catre constructorul clasei parinte.

            Apelul nu creeaza un obiect separat: initializeaza portiunea mostenita a aceluiasi obiect.
            Forma super() fara argumente apeleaza constructorul fara parametri al clasei de baza.
            """,
            """
            Intrebati-va cate obiecte exista dupa acest apel: unul singur sau doua?
            """);

        // ---------------------------------------------------------- suprascriere

        yield return Mc("j4-012", J4, "Suprascrierea metodelor", R4,
            """
            Care este deosebirea dintre suprascrierea si supraincarcarea unei metode?
            """,
            [
                "La suprascriere metoda din subclasa are aceeasi semnatura cu cea din clasa de baza; la supraincarcare metodele au acelasi nume dar liste de parametri diferite.",
                "La suprascriere metodele au liste de parametri diferite; la supraincarcare au aceeasi semnatura.",
                "Suprascrierea se face in aceeasi clasa, iar supraincarcarea intre o clasa si subclasa ei.",
                "Cele doua sunt denumiri diferite ale aceluiasi mecanism."
            ], "A",
            """
            Cand o metoda dintr-o clasa copil are aceeasi semnatura, adica acelasi nume, aceiasi
            parametri si acelasi tip, ca o metoda din clasa parinte, metoda din clasa copil o
            suprascrie pe cea din parinte. La apel din clasa copil se foloseste doar metoda din copil,
            ca si cum cea din parinte nu ar exista.

            Supraincarcarea presupune ca aceeasi functie are parametri diferiti, ceea ce nu se
            intampla la suprascriere. Confuzia dintre cele doua este frecventa tocmai pentru ca
            numele metodei ramane acelasi in ambele cazuri.
            """,
            """
            Amandoua pastreaza numele metodei. Ce le deosebeste este daca lista de parametri se
            schimba sau ramane identica.
            """);

        yield return Mc("j4-013", J4, "Suprascrierea metodelor", R4,
            """
            Cum se impiedica suprascrierea unei metode intr-o clasa derivata?
            """,
            [
                "Prin adaugarea cuvantului cheie final la acea metoda.",
                "Prin declararea metodei ca private in clasa derivata.",
                "Prin adaugarea cuvantului cheie static la acea metoda.",
                "Prin declararea clasei de baza ca abstracta."
            ], "A",
            """
            Cand o metoda nu trebuie suprascrisa in niciuna dintre clasele copil, se poate adauga
            cuvantul cheie final la acea metoda. Daca se incearca totusi suprascrierea ei, se
            primeste un mesaj de eroare.

            Cuvantul static schimba apartenenta metodei, nu posibilitatea de suprascriere, iar o clasa
            abstracta este proiectata tocmai pentru a fi extinsa.
            """,
            """
            Este acelasi cuvant cheie folosit pentru a face o variabila constanta, aplicat aici unei
            metode.
            """);

        yield return Mc("j4-014", J4, "Suprascrierea metodelor", R4,
            """
            De ce este importanta suprascrierea in programarea orientata pe obiecte?
            """,
            [
                "Pentru ca sta la baza polimorfismului la rulare: o clasa generala poate declara metode comune, iar clasele derivate pot avea implementari proprii.",
                "Pentru ca reduce numarul de clase necesare intr-o aplicatie.",
                "Pentru ca permite unei clase sa mosteneasca de la mai multe clase de baza.",
                "Pentru ca elimina nevoia de constructori in clasele derivate."
            ], "A",
            """
            Mecanismul suprascrierii este unul dintre elementele care contribuie la polimorfismul la
            rulare. Polimorfismul este fundamental in programarea orientata pe obiecte pentru ca
            permite unei clase generale sa specifice metode care vor fi aceleasi pentru toate clasele
            derivate din ea, lasand totodata unora dintre clasele copil libertatea de a avea propriile
            implementari pentru acele metode.

            Nu are legatura cu numarul de clase, nu introduce mostenirea multipla si nu inlocuieste
            constructorii.
            """,
            """
            Raspunsul introduce un al treilea concept din POO, alaturi de incapsulare si mostenire.
            """);

        // ---------------------------------------------------------- clasa Object

        yield return Mc("j4-015", J4, "Clasa Object", R4,
            """
            Ce loc ocupa clasa <code>Object</code> in ierarhia claselor Java?
            """,
            [
                "Este clasa fundamentala pe care toate celelalte clase o extind direct sau indirect.",
                "Este o clasa utilitara care trebuie extinsa explicit cand se doreste clonarea.",
                "Este o interfata pe care clasele o pot implementa optional.",
                "Este clasa de baza doar pentru tipurile primitive."
            ], "A",
            """
            Clasa Object este clasa fundamentala din Java, pe care toate celelalte clase o extind
            direct sau indirect. Ea defineste mai multe metode importante care pot fi folosite sau
            suprascrise de alte clase.

            Rolul ei este de stramos comun, ceea ce permite tratarea obiectelor de tipuri diferite ca
            obiecte ale unei superclase comune. Acest lucru este util pentru operatii precum
            serializarea, clonarea sau compararea.
            """,
            """
            Intrebarea este daca mostenirea de la aceasta clasa este optionala sau automata.
            """);

        yield return Drag("j4-016", J4, "Clasa Object", R4,
            """
            Potriviti fiecare metoda din clasa <code>Object</code> cu scopul ei. Fiecare metoda poate
            fi folosita o data, de mai multe ori sau deloc.
            """,
            "Metode",
            [
                "equals",
                "hashCode",
                "toString",
                "getClass",
                "finalize"
            ],
            [
                ("Determina daca un obiect este sau nu egal cu altul", 1),
                ("Returneaza un identificator specific fiecarui obiect", 2),
                ("Returneaza un sir care descrie obiectul", 3),
                ("Determina clasa careia ii apartine obiectul", 4),
                ("Este apelata inainte ca obiectul sa fie distrus", 5)
            ],
            """
            Clasa Object defineste metodele clone, equals, finalize, getClass, hashCode, toString,
            wait si notify.

            Dintre acestea, getClass, notify, notifyAll si wait sunt declarate final, ceea ce inseamna
            ca nu pot fi suprascrise. Celelalte, precum equals, hashCode si toString, sunt suprascrise
            frecvent pentru a oferi implementari specifice clasei.
            """,
            """
            Doua dintre metodele acestei liste sunt declarate final si nu pot fi suprascrise. Asta nu
            schimba insa raspunsul, care priveste doar scopul fiecareia.
            """);

        yield return Mc("j4-017", J4, "Clasa Object", R4,
            """
            Ce conditie trebuie indeplinita pentru ca un obiect sa poata fi clonat?
            """,
            [
                "Clasa lui trebuie sa implementeze interfata Cloneable si sa suprascrie metoda clone.",
                "Clasa lui trebuie sa extinda clasa Cloneable si sa declare metoda clone ca final.",
                "Clasa lui trebuie sa declare toate campurile ca fiind final.",
                "Nu este nevoie de nicio conditie, pentru ca metoda clone este mostenita de la Object."
            ], "A",
            """
            Pentru ca un obiect sa fie eligibil pentru clonare, clasa lui trebuie sa implementeze
            interfata Cloneable si sa suprascrie metoda clone.

            Metoda clone este intr-adevar mostenita de la Object, dar simpla mostenire nu este
            suficienta. Cloneable este o interfata, deci se implementeaza, nu se extinde.
            """,
            """
            Doua actiuni sunt necesare, nu una singura. Retineti si daca Cloneable este clasa sau
            interfata.
            """);

        yield return Mc("j4-018", J4, "Clasa Object", R4,
            """
            Care doua metode din clasa <code>Object</code> tin de lucrul cu fire de executie? Fiecare
            raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Metoda wait, care suspenda firul de executie apelant.",
                "Metoda notifyAll, care reia executia tuturor firelor aflate in asteptare.",
                "Metoda equals, care compara starea a doua fire de executie.",
                "Metoda toString, care descrie firul de executie curent.",
                "Metoda getClass, care returneaza clasa firului de executie."
            ], "A,B",
            """
            Metodele wait, notify si notifyAll tin de programarea cu mai multe fire de executie si de
            concurenta. Ele sunt folosite pentru sincronizarea activitatilor firelor care ruleaza
            independent intr-un program.

            wait suspenda firul de executie apelant, notify reia executia unui fir aflat in asteptare,
            iar notifyAll reia executia tuturor firelor aflate in asteptare. Celelalte metode
            enumerate au alte scopuri si nu au legatura cu firele de executie.
            """,
            """
            Cautati metodele al caror nume descrie o actiune de asteptare sau de anuntare.
            """);
    }
}
