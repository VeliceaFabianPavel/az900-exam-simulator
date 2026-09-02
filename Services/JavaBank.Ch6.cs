using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 6: Colectii in Java (p57-68 in carte, p65-76 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J6 = JavaDomains.Ch6;
    private const string R6 = "Cartea de Java, cap. 6: Colectii";

    private static IEnumerable<Item> Chapter6()
    {
        // ---------------------------------------------------------- cadrul de colectii

        yield return Mc("j6-001", J6, "Cadrul de lucru pentru colectii", R6,
            """
            Din ce trei parti este alcatuit cadrul de lucru pentru colectii din Java?
            """,
            [
                "Interfete, implementari si algoritmi.",
                "Clase, pachete si module.",
                "Liste, multimi si dictionare.",
                "Interfete, generice si iteratoare."
            ], "A",
            """
            Cadrul de lucru pentru colectii este alcatuit din trei parti: interfete, implementari si
            algoritmi. Implementarile sunt clasele concrete oferite de cadru, iar algoritmii sunt
            actiuni sau metode predefinite care pot exista in interiorul claselor.

            In total, cadrul cuprinde in jur de douazeci si cinci de clase si interfete si se afla in
            pachetul java.util. Rolul lui este comparabil cu cel al bibliotecii standard de sabloane
            din C++.
            """,
            """
            Una dintre parti se refera la contracte, alta la clasele care le respecta, iar a treia la
            operatiile predefinite.
            """);

        yield return Mc("j6-002", J6, "Cadrul de lucru pentru colectii", R6,
            """
            Ce se intampla daca o colectie este modificata in timp ce se itereaza prin elementele ei?
            """,
            [
                "Se arunca o exceptie de tip ConcurrentModificationException, pentru ca iteratoarele sunt de tip fail-fast.",
                "Iteratia continua, iar elementul nou este pur si simplu ignorat.",
                "Colectia se blocheaza automat pana la incheierea iteratiei.",
                "Iteratia se reia de la inceput cu noua stare a colectiei."
            ], "A",
            """
            Toate clasele din cadru ofera iteratoare de tip fail-fast. Daca o colectie este modificata
            in timp ce se itereaza prin elementele ei, se arunca o exceptie de tipul
            ConcurrentModificationException.

            Comportamentul este deliberat: problema este semnalata imediat, in loc sa duca la
            rezultate imprevizibile mai tarziu. Colectiile nu se blocheaza singure, pentru ca toate
            implementarile sunt nesincronizate.
            """,
            """
            Numele mecanismului spune ce se intampla: esueaza, si o face repede.
            """);

        yield return Mc("j6-003", J6, "Cadrul de lucru pentru colectii", R6,
            """
            Care doua afirmatii despre implementarile din cadrul de colectii sunt corecte? Fiecare
            raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Toate implementarile sunt nesincronizate, iar accesul sincronizat poate fi adaugat daca este nevoie.",
                "Daca o clasa nu suporta o anumita operatie, arunca o exceptie de tip UnsupportedOperationException.",
                "Toate implementarile sunt sincronizate implicit, deci sunt sigure intre fire de executie.",
                "Interfata Collection implementeaza Cloneable si Serializable.",
                "Nicio implementare nu accepta elemente nule."
            ], "A,B",
            """
            Toate implementarile sunt nesincronizate; accesul sincronizat poate fi adaugat, dar nu
            este obligatoriu. Clasele se bazeaza pe conceptul de metode optionale in interfete: daca
            o clasa nu suporta o anumita operatie, arunca o exceptie de tip
            UnsupportedOperationException.

            Celelalte afirmatii sunt false. Implementarile lucreaza cu elemente nule, iar interfata
            Collection nu implementeaza nici Cloneable, nici Serializable; pentru a copia o colectie
            se recomanda transmiterea ei ca parametru constructorului la instantiere.
            """,
            """
            O varianta afirma exact opusul primei reguli despre sincronizare.
            """);

        yield return Drag("j6-004", J6, "Interfata Collection", R6,
            """
            Potriviti fiecare metoda a interfetei <code>Collection</code> cu ce face. Fiecare metoda
            poate fi folosita o data, de mai multe ori sau deloc.
            """,
            "Metode",
            [
                "contains",
                "retainAll",
                "removeAll",
                "iterator",
                "toArray"
            ],
            [
                ("Verifica daca un element se afla in colectie", 1),
                ("Elimina din colectie elementele care nu se afla in alta colectie", 2),
                ("Elimina din colectia curenta elementele altei colectii", 3),
                ("Returneaza un obiect care permite parcurgerea elementelor", 4),
                ("Returneaza elementele colectiei sub forma de tablou", 5)
            ],
            """
            Metodele removeAll si retainAll sunt cele mai usor de confundat, pentru ca amandoua
            primesc o alta colectie si amandoua sterg elemente. removeAll sterge elementele care se
            afla in cealalta colectie, iar retainAll sterge elementele care nu se afla in ea, deci
            pastreaza intersectia.

            iterator returneaza obiectul care permite parcurgerea colectiei, iar toArray returneaza
            elementele sub forma de tablou.
            """,
            """
            Doua dintre metode primesc o alta colectie si sterg elemente. Ce le deosebeste este care
            elemente raman.
            """);

        // ---------------------------------------------------------- generice

        yield return Mc("j6-005", J6, "Tipuri generice", R6,
            """
            Care doua beneficii aduc tipurile generice? Fiecare raspuns corect reprezinta o parte a
            solutiei.
            """,
            [
                "Verificari de tip mai stricte la compilare, ceea ce permite depistarea timpurie a erorilor.",
                "Eliminarea conversiilor explicite de tip, care altfel pot duce la erori la rulare.",
                "Reducerea dimensiunii fisierelor .class generate.",
                "Sincronizarea automata a colectiilor generice.",
                "Cresterea vitezei de acces la elementele unei liste."
            ], "A,B",
            """
            Genericele permit scrierea de cod care functioneaza cu mai multe tipuri de date diferite.
            Beneficiile mentionate sunt verificari de tip mai stricte la compilare, ceea ce permite
            depistarea erorilor devreme, reutilizarea codului, pentru ca o singura clasa sau metoda
            generica poate fi folosita cu tipuri diferite, si eliminarea conversiilor explicite de
            tip, care fara generice pot duce la erori la rulare.

            Genericele nu au legatura cu sincronizarea, cu dimensiunea fisierelor compilate sau cu
            viteza de acces.
            """,
            """
            Ambele beneficii corecte se refera la tipuri: unul la momentul verificarii, celalalt la o
            operatie care devine inutila.
            """);

        yield return Mc("j6-006", J6, "Tipuri generice", R6,
            """
            Ce reprezinta <code>T</code> in declaratia de mai jos si cand primeste o valoare concreta?
            """,
            [
                "Este un parametru de tip, inlocuit cu un tip real in momentul instantierii clasei.",
                "Este numele unei clase existente din biblioteca standard, folosita implicit.",
                "Este o variabila de instanta, initializata in constructor.",
                "Este un tip primitiv special, care poate stoca orice valoare."
            ], "A",
            """
            Genericele se implementeaza prin parametri de tip, specificati intre paranteze unghiulare
            dupa numele clasei sau al metodei. In clasa Box, T este un parametru de tip.

            Acest T poate fi inlocuit cu un tip real atunci cand se instantiaza clasa. In interiorul
            clasei, T se foloseste ca si cum ar fi un tip adevarat: variabila content are tipul T. La
            creare se precizeaza tipul continutului dorit, de exemplu un sir sau un intreg.
            """,
            """
            Priviti ultimele doua linii ale exemplului: acolo se decide ce este T pentru fiecare
            obiect.
            """,
            """
            public class Box<T> {
                private T content;

                public Box(T content) {
                    this.content = content;
                }

                public T getContent() {
                    return content;
                }
            }

            Box<String> myBox = new Box<>("Hello, world!");
            Box<Integer> myOtherBox = new Box<>(42);
            """);

        // ---------------------------------------------------------- ArrayList si LinkedList

        yield return Mc("j6-007", J6, "ArrayList si LinkedList", R6,
            """
            Ce structura de date foloseste intern fiecare dintre cele doua implementari ale interfetei
            <code>List</code>?
            """,
            [
                "ArrayList foloseste un tablou dinamic, iar LinkedList o lista dublu inlantuita.",
                "ArrayList foloseste o lista dublu inlantuita, iar LinkedList un tablou dinamic.",
                "Ambele folosesc un tablou dinamic, dar cu strategii de redimensionare diferite.",
                "Ambele folosesc o lista dublu inlantuita, dar cu numar diferit de pointeri."
            ], "A",
            """
            ArrayList foloseste intern un tablou dinamic pentru a stoca elementele, in timp ce
            LinkedList foloseste o structura de lista dublu inlantuita.

            Din aceasta deosebire decurg toate celelalte: viteza accesului aleator, costul
            inserarilor si al stergerilor si consumul de memorie.
            """,
            """
            Numele fiecarei clase contine un indiciu despre structura pe care o foloseste.
            """);

        yield return Mc("j6-008", J6, "ArrayList si LinkedList", R6,
            """
            O aplicatie trebuie sa citeasca frecvent elemente de la pozitii aleatoare dintr-o lista
            care se modifica rar.

            Ce implementare este potrivita si de ce?
            """,
            [
                "ArrayList, pentru ca ofera acces aleator rapid, in O(1), pe cand LinkedList are acces aleator lent, in O(n).",
                "LinkedList, pentru ca ofera acces aleator rapid, in O(1), pe cand ArrayList are acces aleator lent, in O(n).",
                "LinkedList, pentru ca inserarile si stergerile sunt mai rapide.",
                "Oricare dintre ele, pentru ca ambele ofera acces aleator in O(1)."
            ], "A",
            """
            ArrayList ofera acces aleator rapid, cu complexitate O(1), pentru ca elementele sunt
            asezate intr-o zona contigua de memorie. LinkedList are acces aleator lent, O(n), pentru
            ca necesita parcurgerea de la cap pana la elementul cerut.

            Criteriul din enunt este tocmai accesul aleator frecvent si modificarea rara, deci
            ArrayList este alegerea buna. LinkedList devine avantajos in situatia inversa: inserari si
            stergeri frecvente, fara nevoie de acces aleator rapid.
            """,
            """
            Doua variante inverseaza complexitatile. Reamintiti-va care structura permite saltul
            direct la o pozitie.
            """);

        yield return Mc("j6-009", J6, "ArrayList si LinkedList", R6,
            """
            De ce are <code>LinkedList</code> un consum de memorie mai mare decat
            <code>ArrayList</code>?
            """,
            [
                "Pentru ca fiecare nod pastreaza in plus doi pointeri, catre elementul urmator si catre cel precedent.",
                "Pentru ca aloca de la inceput spatiu pentru un numar fix de elemente.",
                "Pentru ca pastreaza doua copii ale fiecarui element, pentru acces mai rapid.",
                "Pentru ca stocheaza si indicele fiecarui element alaturi de valoarea lui."
            ], "A",
            """
            ArrayList are un consum de memorie mai mic pentru ca foloseste o singura alocare contigua
            de memorie. LinkedList are un consum mai mare din cauza memoriei suplimentare folosite de
            fiecare nod pentru doi pointeri, catre urmatorul si catre precedentul element.

            Aceasta este consecinta directa a structurii dublu inlantuite. In schimb, LinkedList nu
            are nevoie de redimensionare, operatie costisitoare la ArrayList.
            """,
            """
            Cuvantul dublu din numele structurii interne explica exact ce se pastreaza in plus la
            fiecare element.
            """);

        yield return Mc("j6-010", J6, "ArrayList si LinkedList", R6,
            """
            Ce metode suplimentare ofera <code>LinkedList</code> fata de <code>ArrayList</code>?
            """,
            [
                "Metode pentru manipularea capetelor listei, precum addFirst, addLast, pollFirst si pollLast.",
                "Metode pentru sortarea automata a elementelor la inserare.",
                "Metode pentru sincronizarea accesului intre fire de executie.",
                "Metode pentru conversia directa in tablou, precum toArray."
            ], "A",
            """
            ArrayList ofera metodele de baza precum add, get, remove si size. LinkedList ofera in plus
            metode pentru manipularea capului si a cozii listei, precum addFirst, addLast, pollFirst si
            pollLast.

            Aceste metode decurg din structura dublu inlantuita, in care capetele sunt direct
            accesibile. Sortarea si sincronizarea nu sunt oferite de niciuna dintre ele, iar toArray
            provine din interfata Collection si exista la ambele.
            """,
            """
            Metodele suplimentare se refera la cele doua puncte pe care o lista inlantuita le are
            imediat la indemana.
            """);

        yield return Mc("j6-011", J6, "ArrayList si LinkedList", R6,
            """
            Accepta <code>ArrayList</code> si <code>LinkedList</code> elemente nule?
            """,
            [
                "Da, ambele accepta elemente nule.",
                "Nu, niciuna nu accepta elemente nule.",
                "Doar ArrayList accepta elemente nule.",
                "Doar LinkedList accepta elemente nule."
            ], "A",
            """
            Atat ArrayList cat si LinkedList accepta elemente nule. Aceasta este in acord cu regula
            generala a cadrului, potrivit careia toate implementarile lucreaza cu elemente nule.

            Situatia difera la dictionare si multimi, unde exista limite privind numarul de chei sau
            elemente nule acceptate.
            """,
            """
            Verificati regula generala a cadrului de colectii inainte de a cauta o exceptie.
            """);

        // ---------------------------------------------------------- HashMap si HashSet

        yield return Mc("j6-012", J6, "HashMap si HashSet", R6,
            """
            Care este deosebirea fundamentala dintre <code>HashMap</code> si <code>HashSet</code>?
            """,
            [
                "HashMap implementeaza interfata Map si stocheaza perechi cheie-valoare, iar HashSet implementeaza Set si stocheaza doar elemente unice.",
                "HashMap implementeaza interfata Set si stocheaza elemente unice, iar HashSet implementeaza Map si stocheaza perechi cheie-valoare.",
                "Ambele stocheaza perechi cheie-valoare, dar HashSet nu permite chei nule.",
                "Ambele stocheaza elemente unice, dar HashMap le pastreaza in ordinea inserarii."
            ], "A",
            """
            HashMap implementeaza interfata Map si stocheaza perechi cheie-valoare. HashSet
            implementeaza interfata Set si stocheaza doar elemente unice.

            Detaliul de implementare este interesant: HashSet foloseste intern un HashMap, in care
            elementele sunt pastrate drept chei, iar valorile sunt o constanta, adesea null.
            """,
            """
            Numele interfetelor implementate spune totul: una asociaza, cealalta doar retine.
            """);

        yield return Dropdowns("j6-013", J6, "HashMap si HashSet", R6,
            """
            Alegeti varianta care completeaza corect fiecare afirmatie despre <code>HashMap</code> si
            <code>HashSet</code>.
            """,
            [
                ("Intr-un HashMap, valorile duplicate sunt",
                    ["permise", "interzise", "permise doar daca sunt nule", "permise doar pentru chei numerice"], 1),
                ("Intr-un HashMap, cheile duplicate sunt",
                    ["permise", "interzise", "permise doar daca sunt nule", "permise doar pentru chei numerice"], 2),
                ("Un HashMap accepta chei nule in numar de",
                    ["niciuna", "una singura", "oricat de multe", "cel mult doua"], 2),
                ("Un HashSet accepta elemente nule in numar de",
                    ["niciunul", "unul singur", "oricat de multe", "cel mult doua"], 2)
            ],
            """
            HashMap permite valori duplicate, dar nu si chei duplicate, ceea ce decurge direct din
            rolul cheii de identificator. HashSet nu permite elemente duplicate.

            In privinta valorilor nule, HashMap accepta o singura cheie nula si oricate valori nule,
            iar HashSet accepta un singur element nul. Diferenta dintre chei si valori este cheia
            intregii intrebari.
            """,
            """
            Cheia identifica, valoarea doar insoteste. De aici decurg si regulile privind duplicatele
            si valorile nule.
            """);

        yield return Mc("j6-014", J6, "HashMap si HashSet", R6,
            """
            Ce se poate spune despre ordinea elementelor si despre sincronizare la
            <code>HashMap</code> si <code>HashSet</code>?
            """,
            [
                "Niciuna nu mentine vreo ordine si niciuna nu este sincronizata, deci nu sunt sigure intre fire de executie.",
                "Ambele mentin ordinea inserarii si sunt sincronizate implicit.",
                "HashMap mentine ordinea cheilor, iar HashSet nu mentine nicio ordine; ambele sunt sincronizate.",
                "Niciuna nu mentine vreo ordine, dar ambele sunt sincronizate implicit."
            ], "A",
            """
            HashMap nu mentine nicio ordine a cheilor sau a valorilor, iar HashSet nu mentine nicio
            ordine a elementelor.

            De asemenea, niciuna dintre ele nu este sincronizata, ceea ce inseamna ca nu sunt sigure
            intre fire de executie in mod implicit. Este aceeasi regula generala care se aplica
            tuturor implementarilor din cadru.
            """,
            """
            Prefixul comun al celor doua clase indica structura interna folosita, iar aceasta explica
            de ce nu exista o ordine.
            """);

        yield return Mc("j6-015", J6, "HashMap si HashSet", R6,
            """
            Care este complexitatea medie a operatiilor de baza la <code>HashMap</code> si
            <code>HashSet</code>?
            """,
            [
                "O(1) pentru get si put la HashMap, respectiv pentru add, remove si contains la HashSet.",
                "O(n) pentru toate operatiile la ambele clase.",
                "O(log n) pentru toate operatiile la ambele clase.",
                "O(1) la HashMap, dar O(n) la HashSet, pentru ca acesta parcurge elementele."
            ], "A",
            """
            Complexitatea medie de timp pentru operatiile get si put la HashMap este O(1). Pentru
            HashSet, complexitatea medie pentru add, remove si contains este de asemenea O(1).

            Aceasta este consecinta folosirii unei tabele de dispersie ca structura interna. Faptul ca
            HashSet foloseste intern un HashMap explica de ce cele doua au acelasi comportament.
            """,
            """
            Cele doua clase au aceeasi structura interna, deci nu ar fi logic sa aiba complexitati
            diferite.
            """);

        yield return Mc("j6-016", J6, "Egalitatea in liste", R6,
            """
            Pe langa metoda <code>equals</code>, ce se mai compara atunci cand se verifica prezenta
            unui element intr-o lista?
            """,
            [
                "Identificatorul elementului, adica valoarea returnata de metoda hashCode.",
                "Adresa de memorie a obiectului, obtinuta prin operatorul ==.",
                "Numele clasei elementului, obtinut prin getClass.",
                "Pozitia elementului in lista, obtinuta prin indexOf."
            ], "A",
            """
            Egalitatea se verifica folosind metoda equals, care poate fi suprascrisa atunci cand se
            lucreaza cu o lista specializata. Pe langa metoda equals se compara si identificatorii
            elementelor din lista, adica ceea ce returneaza functia hashCode.

            De aceea, cand se suprascrie equals este necesar sa se suprascrie si hashCode, astfel
            incat cele doua sa fie in acord. Functia hashCode ar trebui sa returneze valori diferite
            pentru obiecte diferite.
            """,
            """
            Cele doua metode merg intotdeauna impreuna cand se suprascriu. A doua returneaza un numar.
            """);
    }
}
