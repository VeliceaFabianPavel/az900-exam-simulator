using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 8: Colectii Java in detaliu (p99-114 in carte, p107-122 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J8 = JavaDomains.Ch8;
    private const string R8 = "Cartea de Java, cap. 8: Colectii avansate";

    private static IEnumerable<Item> Chapter8()
    {
        // ---------------------------------------------------------- TreeSet

        yield return Mc("j8-001", J8, "TreeSet si arbori rosu-negru", R8,
            """
            Prin ce se deosebeste <code>TreeSet</code> de <code>HashSet</code> si ce complexitate are
            cautarea in el?
            """,
            [
                "TreeSet pastreaza elementele ordonate intr-un arbore echilibrat rosu-negru, iar cautarea are complexitate logaritmica, O(log n).",
                "TreeSet pastreaza elementele in ordinea inserarii, iar cautarea are complexitate constanta, O(1).",
                "TreeSet nu pastreaza nicio ordine, dar garanteaza cautare in O(1) prin dispersie.",
                "TreeSet pastreaza elementele ordonate intr-un tablou sortat, iar cautarea are complexitate liniara, O(n)."
            ], "A",
            """
            Clasa TreeSet functioneaza asemanator cu HashSet, dar mentine elementele intr-o ordine.
            Elementele sunt organizate intr-un arbore echilibrat, mai exact un arbore rosu-negru.

            Pastrarea elementelor intr-un arbore rosu-negru face ca acest cost al cautarii sa devina
            logaritmic, cu ordinul de complexitate O(log n). Aceasta este diferenta fata de HashSet,
            care ofera O(1) in medie, dar nicio ordine.
            """,
            """
            Structura interna decide si ordinea, si complexitatea. Numele clasei contine un indiciu
            despre acea structura.
            """);

        yield return Mc("j8-002", J8, "TreeSet si arbori rosu-negru", R8,
            """
            Care doua reguli respecta un arbore rosu-negru? Fiecare raspuns corect reprezinta o parte a
            solutiei.
            """,
            [
                "Radacina este intotdeauna un nod negru.",
                "Daca un nod este rosu, copiii lui trebuie sa fie negri.",
                "Radacina este intotdeauna un nod rosu.",
                "Fiecare nod are exact doi copii, fara exceptie.",
                "Toate nodurile de pe acelasi nivel au aceeasi culoare."
            ], "A,B",
            """
            Un arbore rosu-negru respecta urmatoarele reguli: fiecare nod este rosu sau negru,
            radacina este intotdeauna un nod negru, daca nodul este rosu atunci copiii lui trebuie sa
            fie negri, iar fiecare drum de la radacina la frunze trebuie sa contina acelasi numar de
            noduri negre.

            Nu exista o regula care sa impuna doi copii pentru fiecare nod sau aceeasi culoare pe un
            nivel. Ultima regula, cea a numarului egal de noduri negre pe fiecare drum, este cea care
            asigura echilibrarea si deci complexitatea logaritmica.
            """,
            """
            Una dintre reguli priveste radacina, alta priveste relatia dintre un nod si copiii lui.
            """);

        yield return Drag("j8-003", J8, "Metodele clasei TreeSet", R8,
            """
            Potriviti fiecare metoda a clasei <code>TreeSet</code> cu ce face. Fiecare metoda poate fi
            folosita o data, de mai multe ori sau deloc.
            """,
            "Metode",
            [
                "first",
                "last",
                "headSet",
                "tailSet",
                "comparator"
            ],
            [
                ("Returneaza primul element al multimii", 1),
                ("Returneaza ultimul element al multimii", 2),
                ("Returneaza o submultime de elemente de la inceputul multimii", 3),
                ("Returneaza o submultime de elemente de la sfarsitul multimii", 4),
                ("Returneaza obiectul folosit pentru comparare", 5)
            ],
            """
            Pentru ca TreeSet mentine elementele ordonate, are sens sa existe metode care se refera la
            pozitii: first si last returneaza primul, respectiv ultimul element.

            headSet returneaza o submultime de la inceputul multimii, tailSet o submultime de la
            sfarsit, iar subSet o submultime a multimii initiale. Metoda comparator returneaza obiectul
            de comparare folosit. Aceste metode nu ar avea sens la o multime neordonata.
            """,
            """
            Doua metode returneaza un singur element, doua returneaza submultimi, iar una returneaza
            regula de ordonare.
            """);

        yield return Mc("j8-004", J8, "TreeSet", R8,
            """
            Ce face <code>Collections.reverseOrder()</code> atunci cand este transmis constructorului
            unui <code>TreeSet</code>?
            """,
            [
                "Returneaza un comparator care impune inversul ordinii naturale pentru obiecte care implementeaza Comparable.",
                "Inverseaza ordinea elementelor deja existente in multime, o singura data.",
                "Sorteaza elementele in ordine naturala, dar le afiseaza invers.",
                "Dezactiveaza ordonarea, transformand TreeSet intr-un HashSet."
            ], "A",
            """
            Metoda Collections.reverseOrder() returneaza un comparator care impune inversul ordinii
            naturale asupra unei colectii de obiecte care implementeaza interfata Comparable.

            Transmis constructorului, acest comparator devine regula de ordonare a multimii, deci se
            aplica tuturor elementelor adaugate, nu doar celor existente la un moment dat. Ultima linie
            din exemplul cartii afiseaza chiar numele clasei acelui comparator.
            """,
            """
            Rezultatul este un obiect care stabileste o regula, nu o operatie executata o singura data.
            """);

        // ---------------------------------------------------------- sortare

        yield return Mc("j8-005", J8, "Sortarea colectiilor", R8,
            """
            Care sunt cele doua moduri de a sorta colectii prezentate in carte?
            """,
            [
                "Implementarea interfetei Comparable sau folosirea unui Comparator separat.",
                "Implementarea interfetei Iterable sau folosirea metodei sort din clasa Arrays.",
                "Folosirea unui TreeSet sau a unui HashSet, in functie de tipul elementelor.",
                "Suprascrierea metodei equals sau a metodei hashCode."
            ], "A",
            """
            Exista in esenta doua moduri de a sorta colectiile: prin implementarea interfetei
            Comparable sau printr-un Comparator propriu.

            Comparable defineste ordinea naturala a clasei insasi, prin metoda compareTo. Comparator
            este o clasa separata de clasa de baza, folosita atunci cand nu se doreste impunerea
            ordinii naturale sau cand clasele nu implementeaza Comparable.
            """,
            """
            Una dintre solutii se afla in interiorul clasei, cealalta in afara ei.
            """);

        yield return Mc("j8-006", J8, "Interfata Comparable", R8,
            """
            Ce metoda defineste interfata <code>Comparable</code> si ce exprima valoarea returnata?
            """,
            [
                "Metoda compareTo, iar valoarea returnata exprima pozitia relativa in ordinea naturala.",
                "Metoda compare, iar valoarea returnata exprima egalitatea celor doua obiecte.",
                "Metoda equals, iar valoarea returnata exprima daca obiectele sunt identice.",
                "Metoda sort, iar valoarea returnata este colectia sortata."
            ], "A",
            """
            Interfata Comparable are o singura metoda, compareTo, care defineste cum sunt comparate si
            deci sortate obiectele. Valoarea returnata exprima pozitia relativa intr-o ordine naturala.

            Metoda compare apartine interfetei Comparator, care este cealalta cale de sortare. Confuzia
            dintre compareTo si compare este exact ce verifica intrebarea.
            """,
            """
            Cele doua interfete de sortare au metode cu nume asemanatoare. Aceasta intrebare se refera
            la cea implementata de clasa insasi.
            """);

        yield return Mc("j8-007", J8, "Interfata Comparable", R8,
            """
            Care doua conditii sunt cerute metodei <code>compareTo</code>? Fiecare raspuns corect
            reprezinta o parte a solutiei.
            """,
            [
                "Elementele trebuie sa fie comparabile intre ele.",
                "Ordinea naturala ar trebui sa se bazeze pe metoda equals.",
                "Metoda trebuie apelata direct de programator inainte de sortare.",
                "Metoda trebuie sa returneze intotdeauna o valoare pozitiva.",
                "Metoda trebuie declarata static."
            ], "A,B",
            """
            Conditiile enuntate pentru metoda compareTo sunt ca elementele sa fie comparabile intre
            ele, ca valoarea returnata sa exprime pozitia relativa in ordinea naturala, ca ordinea
            naturala sa se bazeze pe metoda equals si ca metoda sa nu fie apelata niciodata direct.

            Ultima conditie este exact opusul variantei gresite: metoda este apelata de mecanismul de
            sortare, nu de programator. Valoarea returnata poate fi negativa, zero sau pozitiva, dupa
            pozitia relativa.
            """,
            """
            Una dintre variantele gresite spune exact opusul unei conditii din carte.
            """);

        yield return Mc("j8-008", J8, "Interfata Comparator", R8,
            """
            Cand se recurge la un <code>Comparator</code> in locul interfetei
            <code>Comparable</code>?
            """,
            [
                "Cand nu se doreste impunerea ordinii naturale a claselor sau cand clasele nu implementeaza Comparable.",
                "Cand colectia contine mai mult de o mie de elemente.",
                "Cand elementele colectiei sunt de tipuri primitive.",
                "Cand se doreste sortarea in ordine naturala, dar mai rapid."
            ], "A",
            """
            Cand nu se doreste impunerea ordinii naturale a claselor, sau cand clasele nu implementeaza
            interfata Comparable, este disponibila metoda compare din interfata Comparator.

            Exemplul din carte este un nou manager care doreste sa vada numele angajatului inaintea
            departamentului, adica exact inversul ordinii definite in clasa Employee. Pentru asta se
            implementeaza o clasa separata de clasa de baza.
            """,
            """
            Motivul tine de ordinea dorita si de ce ofera deja clasa, nu de dimensiunea colectiei.
            """);

        yield return Mc("j8-009", J8, "Interfata Comparator", R8,
            """
            Ce deosebire exista intre semnaturile metodelor <code>compareTo</code> si
            <code>compare</code>?
            """,
            [
                "compareTo primeste un singur obiect si il compara cu obiectul curent, iar compare primeste doua obiecte si le compara intre ele.",
                "compareTo primeste doua obiecte, iar compare primeste unul singur.",
                "Ambele primesc doua obiecte, dar compare returneaza boolean.",
                "Ambele primesc un singur obiect, dar compareTo returneaza boolean."
            ], "A",
            """
            Metoda compareTo apartine clasei care se compara pe sine, deci primeste un singur obiect si
            il compara cu obiectul curent. In exemplul cartii, compara departamentul si, la egalitate,
            numele.

            Metoda compare apartine unui comparator extern, deci primeste doua obiecte, obj1 si obj2,
            pe care le foloseste pentru comparatie. Ambele returneaza un intreg, nu un boolean.
            """,
            """
            Numarul de parametri decurge din cine face comparatia: obiectul insusi sau un tert.
            """);

        // ---------------------------------------------------------- Dictionary, HashTable

        yield return Mc("j8-010", J8, "Dictionary, HashTable si Properties", R8,
            """
            Ce fel de clasa este <code>Dictionary</code> si ce analogie foloseste cartea pentru a o
            explica?
            """,
            [
                "Este o clasa abstracta, care contine doar metode abstracte, comparabila cu o agenda telefonica in care numele este cheia unica si numarul este valoarea.",
                "Este o clasa concreta, gata de instantiat, comparabila cu un tablou indexat numeric.",
                "Este o interfata, comparabila cu o lista ordonata de perechi.",
                "Este o clasa finala, care nu poate fi extinsa, comparabila cu o multime de chei."
            ], "A",
            """
            Dictionary este o clasa abstracta care contine doar metode abstracte. Poate fi imaginata
            prin analogie cu o agenda telefonica, in care numele persoanei este cheia unica, iar
            numarul de telefon este valoarea.

            Metodele importante din clasa Dictionary sunt elements, get, isEmpty, keys, put, remove si
            size. Fiind abstracta, nu poate fi instantiata direct.
            """,
            """
            Faptul ca toate metodele ei sunt abstracte spune si ce fel de clasa este, si daca poate fi
            instantiata.
            """);

        yield return Mc("j8-011", J8, "Dictionary, HashTable si Properties", R8,
            """
            Ce este <code>HashTable</code> si care este complexitatea obisnuita a operatiilor de
            inserare?
            """,
            [
                "Este o implementare concreta a clasei Dictionary, care foloseste un algoritm de dispersie; inserarea lucreaza in general in timp constant, O(1).",
                "Este o interfata implementata de HashMap; inserarea lucreaza in timp logaritmic, O(log n).",
                "Este o clasa abstracta care extinde Dictionary; inserarea lucreaza in timp liniar, O(n).",
                "Este o implementare a interfetei Set; inserarea lucreaza in timp constant, O(1)."
            ], "A",
            """
            HashTable este o implementare concreta a clasei Dictionary, care foloseste un algoritm de
            dispersie pentru a oferi cautari rapide. Functia de dispersie converteste cheile in coduri
            de dispersie, care accelereaza cautarile in colectie.

            Operatiile de inserare lucreaza in general in timp constant, O(1), datorita implementarii
            bazate pe dispersie. Coliziunile de dispersie pot insa reduce eficienta structurii.
            """,
            """
            Retineti si limita mentionata: ce anume poate reduce eficienta acestei structuri?
            """);

        yield return Drag("j8-012", J8, "Metodele clasei HashTable", R8,
            """
            Potriviti fiecare metoda a clasei <code>HashTable</code> cu ce face. Fiecare metoda poate
            fi folosita o data, de mai multe ori sau deloc.
            """,
            "Metode",
            [
                "containsKey",
                "containsValue",
                "keys",
                "put",
                "clone"
            ],
            [
                ("Verifica daca o anumita cheie exista", 1),
                ("Verifica daca o anumita valoare exista", 2),
                ("Returneaza o enumerare a cheilor", 3),
                ("Asociaza o valoare unei chei", 4),
                ("Creeaza o copie superficiala a structurii", 5)
            ],
            """
            Perechea containsKey si containsValue este cea care cere atentie: prima cauta printre chei,
            a doua printre valori. Exista si o metoda contains, care verifica prezenta unui obiect.

            Metoda keys returneaza o enumerare a cheilor, folosita in exemplul de numarare a
            cuvintelor pentru a parcurge rezultatele. Metoda put asociaza o valoare unei chei, iar
            clone creeaza o copie superficiala.
            """,
            """
            Doua metode au nume aproape identice si difera printr-un singur cuvant, care spune unde
            anume cauta.
            """);

        yield return Mc("j8-013", J8, "Dictionary, HashTable si Properties", R8,
            """
            In exemplul de numarare a aparitiilor cuvintelor dintr-un fisier, ce reprezinta cheia si ce
            reprezinta valoarea din <code>HashTable</code>?
            """,
            [
                "Cheia este cuvantul citit din fisier, iar valoarea este numarul de aparitii ale acelui cuvant.",
                "Cheia este numarul liniei, iar valoarea este continutul liniei.",
                "Cheia este numarul de aparitii, iar valoarea este cuvantul.",
                "Cheia este numele fisierului, iar valoarea este lista tuturor cuvintelor."
            ], "A",
            """
            Ideea programului este ca in structura de tip HashTable se mentine o pereche cheie-valoare,
            in care cheia reprezinta cuvantul citit din fisier, iar valoarea reprezinta numarul de
            aparitii ale acelui cuvant.

            Metoda care proceseaza linia imparte linia citita in cuvinte separate prin spatii si apoi
            apeleaza metoda de adaugare. Acolo se verifica daca cuvantul a fost deja inregistrat: daca
            nu, se adauga perechea formata din cuvantul nou si valoarea unu; daca da, valoarea
            corespunzatoare cheii este incrementata.
            """,
            """
            Cheia trebuie sa fie unica. Dintre cuvant si numarul de aparitii, care dintre ele poate
            aparea de mai multe ori?
            """);

        yield return Mc("j8-014", J8, "Colectii ordonate", R8,
            """
            Un program trebuie sa pastreze un set de nume fara duplicate si sa le parcurga mereu in
            ordine alfabetica.

            Ce colectie este potrivita si de ce?
            """,
            [
                "TreeSet, pentru ca este o multime, deci elimina duplicatele, si mentine elementele ordonate.",
                "HashSet, pentru ca este o multime si mentine ordinea de inserare.",
                "ArrayList, pentru ca permite accesul aleator rapid si sortarea la fiecare parcurgere.",
                "HashMap, pentru ca nu permite chei duplicate si mentine cheile ordonate."
            ], "A",
            """
            Cerinta are doua parti: fara duplicate si mereu in ordine. Prima parte cere o multime, deci
            un Set, iar a doua cere o multime ordonata.

            TreeSet indeplineste ambele conditii: fiind o multime elimina duplicatele, iar arborele
            rosu-negru mentine elementele ordonate. HashSet elimina duplicatele, dar nu mentine nicio
            ordine, iar HashMap nu mentine nici el ordinea cheilor.
            """,
            """
            Doua cerinte trebuie indeplinite simultan. Verificati fiecare varianta pe amandoua, nu doar
            pe prima.
            """);
    }
}
