using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 3: Sintaxa si structura de baza (p15-30 in carte, p23-38 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J3 = JavaDomains.Ch3;
    private const string R3 = "Cartea de Java, cap. 3: Sintaxa de baza";

    private static IEnumerable<Item> Chapter3()
    {
        // ---------------------------------------------------------- tipuri si variabile

        yield return Mc("j3-001", J3, "Tipuri de date si variabile", R3,
            """
            Care este diferenta dintre un tip primitiv si un tip referinta in Java?
            """,
            [
                "O variabila de tip primitiv contine o singura valoare, in timp ce o variabila de tip referinta contine adresa unui obiect creat pe heap.",
                "O variabila de tip primitiv contine adresa unei valori, iar una de tip referinta contine valoarea propriu-zisa.",
                "Tipurile primitive pot fi folosite doar in interiorul metodelor, iar cele referinta doar la nivel de clasa.",
                "Nu exista nicio diferenta de reprezentare; deosebirea este doar de notatie."
            ], "A",
            """
            Java are doua categorii de tipuri de date: primitive si referinta. O variabila de tip
            primitiv poate contine o singura valoare, in formatul tipului respectiv.

            Clasele, tablourile si interfetele sunt tipuri referinta. Valoarea unei variabile
            referinta este adresa unui obiect creat pe heap. Spre deosebire de C, in Java nu exista
            posibilitatea de a accesa direct zona de memorie.
            """,
            """
            Intrebati-va ce anume este stocat efectiv in variabila: valoarea insasi sau un indicator
            catre ea.
            """);

        yield return Dropdowns("j3-002", J3, "Tipuri de date si variabile", R3,
            """
            Alegeti varianta care completeaza corect fiecare afirmatie despre tipurile primitive.
            """,
            [
                ("Tipul byte este reprezentat pe",
                    ["8 biti", "16 biti", "32 de biti", "64 de biti"], 1),
                ("Tipul int este reprezentat pe",
                    ["8 biti", "16 biti", "32 de biti", "64 de biti"], 3),
                ("Tipul long este reprezentat pe",
                    ["8 biti", "16 biti", "32 de biti", "64 de biti"], 4),
                ("Tipul char este reprezentat pe",
                    ["8 biti", "16 biti", "32 de biti", "64 de biti"], 2)
            ],
            """
            Dimensiunile tipurilor primitive intregi cresc din doi in doi: byte pe 8 biti, short pe
            16, int pe 32 si long pe 64.

            Tipul char ocupa 16 biti pentru ca reprezinta caractere Unicode, nu doar caractere ASCII
            pe un octet. Este singurul tip pe 16 biti alaturi de short, iar confuzia dintre ele este
            frecventa.
            """,
            """
            Trei dintre randuri urmeaza sirul intregilor. Al patrulea se refera la un tip care nu
            este numeric si care trebuie sa acopere Unicode.
            """);

        yield return Mc("j3-003", J3, "Tipuri de date si variabile", R3,
            """
            Ce inseamna cuvantul cheie <code>final</code> aplicat unei variabile?
            """,
            [
                "Variabila nu mai poate fi modificata dupa initializare, devenind practic o constanta.",
                "Variabila este eliberata automat din memorie la iesirea din metoda.",
                "Variabila devine vizibila in intreaga clasa, indiferent de locul declararii.",
                "Variabila poate fi initializata doar cu valoarea implicita a tipului ei."
            ], "A",
            """
            Cuvantul final aplicat unei variabile inseamna ca aceasta nu mai poate fi modificata
            odata ce a fost initializata, ceea ce o transforma practic intr-o constanta.

            Nu are legatura cu durata de viata a variabilei, cu vizibilitatea ei sau cu valoarea cu
            care este initializata. Domeniul de vizibilitate este stabilit de locul declararii, nu
            de acest cuvant cheie.
            """,
            """
            Cuvantul se refera la o singura proprietate a variabilei: daca valoarea ei se mai poate
            schimba sau nu.
            """);

        yield return Mc("j3-004", J3, "Tipuri de date si variabile", R3,
            """
            Care doua conditii trebuie indeplinite pentru ca un nume de variabila sa fie valid in
            Java? Fiecare raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Sa inceapa cu o litera si sa fie compus din caractere Unicode.",
                "Sa fie unic in domeniul sau de vizibilitate.",
                "Sa aiba cel mult opt caractere.",
                "Sa fie scris exclusiv cu litere mici.",
                "Sa coincida cu numele tipului sau de date."
            ], "A,B",
            """
            Un nume de variabila valid trebuie sa inceapa cu o litera si sa fie compus din caractere
            Unicode, sa nu fie un cuvant rezervat al limbajului si sa fie unic in domeniul sau de
            vizibilitate.

            Nu exista o limita de opt caractere si nu exista o constrangere privind literele mari
            sau mici. Java este insa sensibil la litere mari si mici, deci doua nume care difera doar
            prin acest aspect sunt nume diferite.
            """,
            """
            O regula priveste forma numelui, alta priveste unicitatea lui. A treia regula, care nu
            apare intre variante, se refera la cuvintele rezervate.
            """);

        // ---------------------------------------------------------- operatori

        yield return Mc("j3-005", J3, "Operatori", R3,
            """
            Care este diferenta dintre operatorul <code>&amp;&amp;</code> si operatorul
            <code>&amp;</code> atunci cand ambii operanzi sunt de tip boolean?
            """,
            [
                "Operatorul && evalueaza conditional al doilea operand, in timp ce & evalueaza intotdeauna ambii operanzi.",
                "Operatorul && evalueaza intotdeauna ambii operanzi, in timp ce & il evalueaza conditional pe al doilea.",
                "Operatorul && lucreaza doar cu valori boolean, iar & doar cu valori intregi.",
                "Cei doi operatori sunt complet echivalenti pentru operanzi de tip boolean."
            ], "A",
            """
            Ambii operatori returneaza adevarat cand cei doi operanzi boolean sunt adevarati.
            Deosebirea este de evaluare: && evalueaza conditional al doilea operand, adica il
            evalueaza doar daca este necesar, in timp ce & evalueaza intotdeauna ambii operanzi.

            Diferenta conteaza cand al doilea operand are efecte secundare sau ar produce o eroare,
            de exemplu la verificarea unei referinte inainte de a o folosi.
            """,
            """
            Ambii dau acelasi rezultat logic. Deosebirea este daca al doilea operand ajunge sau nu
            sa fie evaluat.
            """);

        yield return Mc("j3-006", J3, "Operatori", R3,
            """
            Care este diferenta dintre operatorii de deplasare <code>&gt;&gt;</code> si
            <code>&gt;&gt;&gt;</code>?
            """,
            [
                "Operatorul >>> completeaza bitii din stanga cu zero, in timp ce >> ii completeaza cu bitul de semn.",
                "Operatorul >>> completeaza bitii din stanga cu bitul de semn, in timp ce >> ii completeaza cu zero.",
                "Operatorul >>> deplaseaza spre stanga, in timp ce >> deplaseaza spre dreapta.",
                "Cei doi operatori sunt identici, iar al doilea este pastrat doar pentru compatibilitate."
            ], "A",
            """
            Ambii operatori deplaseaza bitii spre dreapta cu numarul de pozitii indicat de al doilea
            operand. Deosebirea este ce se pune in locurile ramase libere in stanga.

            Operatorul >>> completeaza cu zero, iar >> completeaza cu bitul de semn, ceea ce pastreaza
            semnul numarului. Deplasarea spre stanga se face cu <<.
            """,
            """
            Ambii deplaseaza in aceeasi directie. Priviti ce se intampla cu bitii din partea opusa
            celei in care se face deplasarea.
            """);

        yield return Mc("j3-007", J3, "Operatori", R3,
            """
            Ce valoare va avea variabila <code>rezultat</code> si de ce?
            """,
            [
                "Va avea valoarea 7, pentru ca operatorul conditional evalueaza al doilea operand cand conditia este adevarata.",
                "Va avea valoarea 3, pentru ca operatorul conditional evalueaza al treilea operand cand conditia este adevarata.",
                "Va avea valoarea 0, pentru ca operatorul conditional returneaza intotdeauna valoarea implicita a tipului.",
                "Codul nu se compileaza, pentru ca operatorul conditional cere operanzi de acelasi tip cu conditia."
            ], "A",
            """
            Operatorul conditional este un operator ternar mostenit din C, care permite introducerea
            unei conditii intr-o expresie. Primul operand trebuie sa fie de tip boolean.

            Evaluarea decurge astfel: se evalueaza primul operand; daca este adevarat, se evalueaza
            al doilea operand si se foloseste valoarea lui, iar daca este fals, se evalueaza al
            treilea. Aici conditia este adevarata, deci rezultatul este 7. Al doilea si al treilea
            operand pot fi de orice tip, atat timp cat sunt de acelasi tip sau convertibile la
            acelasi tip.
            """,
            """
            Urmariti ordinea celor trei operanzi si stabiliti care dintre ei este folosit cand
            conditia este adevarata.
            """,
            """
            int x = 7, y = 3;
            int rezultat = (x > y) ? x : y;
            """);

        // ---------------------------------------------------------- structuri de control

        yield return Mc("j3-008", J3, "Structuri de control", R3,
            """
            Care este diferenta esentiala dintre instructiunea <code>while</code> si instructiunea
            <code>do-while</code>?
            """,
            [
                "La do-while expresia este evaluata la finalul buclei, deci instructiunile din corp se executa cel putin o data.",
                "La do-while expresia este evaluata la inceputul buclei, deci corpul poate sa nu se execute niciodata.",
                "La do-while numarul de iteratii trebuie cunoscut dinainte, spre deosebire de while.",
                "Cele doua instructiuni sunt echivalente, iar do-while este pastrata doar pentru compatibilitate."
            ], "A",
            """
            Instructiunea do-while este asemanatoare cu while, cu deosebirea ca expresia este
            evaluata la finalul buclei. Consecinta este ca instructiunile din interiorul buclei se
            executa cel putin o data, chiar daca expresia este falsa de la inceput.

            La while, expresia se evalueaza inainte de prima iteratie, deci corpul poate sa nu se
            execute deloc. Cunoasterea numarului de iteratii este criteriul care recomanda de obicei
            instructiunea for, nu do-while.
            """,
            """
            Deosebirea este locul in care se afla conditia fata de corpul buclei. De acolo rezulta
            numarul minim de executii.
            """);

        yield return Mc("j3-009", J3, "Structuri de control", R3,
            """
            Ce afiseaza programul de mai jos?
            """,
            [
                "Numerele pare de la 0 la 50.",
                "Numerele impare de la 0 la 50.",
                "Toate numerele de la 0 la 50.",
                "Nimic, pentru ca instructiunea continue opreste bucla la prima iteratie."
            ], "A",
            """
            Instructiunea continue este folosita intr-o bucla si sare la pasul urmator, ignorand
            instructiunile care o urmeaza in corpul buclei.

            Aici conditia verifica daca restul impartirii la 2 este diferit de zero, adica daca
            numarul este impar. In acel caz se executa continue si se trece la pasul urmator fara a
            se afisa nimic. Prin urmare se afiseaza doar numerele pare. Spre deosebire de break,
            continue nu iese din bucla, ci doar sare peste restul iteratiei curente.
            """,
            """
            Urmariti ce se intampla cand conditia din if este adevarata: se iese din bucla sau se
            trece la pasul urmator?
            """,
            """
            for (int i = 0; i <= 50; i++) {
                if ((i % 2) != 0) continue;
                System.out.println(i);
            }
            """);

        yield return Mc("j3-010", J3, "Structuri de control", R3,
            """
            De ce nu are Java o instructiune <code>goto</code> clasica, si ce ofera in schimb?
            """,
            [
                "Pentru ca goto permite un flux logic nestructurat, greu de urmarit si intretinut; Java ofera in schimb break cu eticheta.",
                "Pentru ca goto nu poate fi compilata in bytecode; Java ofera in schimb continue cu eticheta.",
                "Pentru ca goto exista, dar este rezervata pentru versiuni viitoare ale limbajului.",
                "Pentru ca goto ar intra in conflict cu colectorul de gunoi; Java ofera in schimb return."
            ], "A",
            """
            Java nu are o instructiune goto clasica pentru ca aceasta permite un flux logic
            nestructurat. Programele care o folosesc sunt greu de urmarit si de intretinut.

            Exista in schimb forma break urmata de o eticheta, care transfera controlul la blocul
            identificat de acea eticheta. Cartea o prezinta pur informativ si nu recomanda folosirea
            ei in acest scop.
            """,
            """
            Motivul tine de lizibilitatea codului, nu de o limitare tehnica a masinii virtuale.
            """);

        yield return Drag("j3-011", J3, "Structuri de control", R3,
            """
            Potriviti fiecare instructiune cu efectul ei asupra executiei. Fiecare instructiune poate
            fi folosita o data, de mai multe ori sau deloc.
            """,
            "Instructiuni",
            [
                "break",
                "continue",
                "return",
                "default"
            ],
            [
                ("Forteaza iesirea imediata din bucla", 1),
                ("Sare la pasul urmator al buclei, ignorand restul iteratiei", 2),
                ("Incheie executia metodei si transmite eventual o valoare", 3),
                ("Ramura executata intr-un switch cand nicio valoare nu se potriveste", 4),
                ("Impiedica executia instructiunilor de sub ramura care s-a potrivit intr-un switch", 1)
            ],
            """
            break forteaza iesirea din bucla, iar continue sare la pasul urmator fara a parasi bucla.
            return incheie executia metodei.

            Ultimul rand este motivul pentru care break apare de doua ori: in interiorul unui switch,
            break impiedica executia instructiunilor scrise sub ramura care s-a potrivit initial.
            Fara el, executia ar continua in ramurile urmatoare. Ramura default se executa cand
            variabila nu corespunde niciunei valori din case.
            """,
            """
            O singura instructiune raspunde la doua randuri, pentru ca are efecte diferite in bucla
            si in switch.
            """);

        // ---------------------------------------------------------- tablouri

        yield return Mc("j3-012", J3, "Tablouri", R3,
            """
            Un student sustine ca un tablou din Java isi poate schimba dimensiunea dupa creare,
            pentru ca elementele lui pot fi modificate.

            Care este raspunsul corect?
            """,
            [
                "Elementele pot fi modificate, dar dimensiunea este fixata la creare si nu poate fi schimbata; pentru redimensionare exista colectii precum ArrayList.",
                "Nici elementele si nici dimensiunea nu pot fi modificate dupa creare, pentru ca tablourile sunt imutabile.",
                "Si elementele si dimensiunea pot fi modificate, folosind proprietatea length.",
                "Dimensiunea poate fi modificata, dar elementele nu, pentru ca sunt stocate pe stiva."
            ], "A",
            """
            Tablourile din Java nu sunt imutabile: elementele lor pot fi schimbate dupa initializare.
            Dimensiunea insa este fixata la creare si nu mai poate fi modificata.

            Aceasta este deosebirea fata de alte colectii din Java, precum ArrayList, care se pot
            redimensiona dinamic. Proprietatea length doar citeste lungimea tabloului, nu o modifica.
            """,
            """
            Sunt doua lucruri diferite in joc: continutul tabloului si marimea lui. Doar unul dintre
            ele este fix.
            """);

        yield return Mc("j3-013", J3, "Tablouri", R3,
            """
            Cum se obtine lungimea unui tablou in Java?
            """,
            [
                "Prin proprietatea length, scrisa fara paranteze.",
                "Prin metoda length(), scrisa cu paranteze.",
                "Prin metoda size(), scrisa cu paranteze.",
                "Prin proprietatea count, scrisa fara paranteze."
            ], "A",
            """
            Lungimea unui tablou se obtine prin proprietatea length, folosita fara paranteze.

            Confuzia frecventa este cu metoda length() a clasei String, care se scrie cu paranteze,
            si cu metoda size() a colectiilor. Cele trei apartin unor tipuri diferite si nu sunt
            interschimbabile.
            """,
            """
            Trei forme foarte asemanatoare apartin unor tipuri diferite: tabloului, sirului de
            caractere si colectiei. Aceasta intrebare se refera la prima.
            """);

        // ---------------------------------------------------------- siruri de caractere

        yield return Mc("j3-014", J3, "Siruri de caractere", R3,
            """
            Ce se afiseaza la rularea codului de mai jos?
            """,
            [
                "Original: Original si Modificat: Oroginal, pentru ca metoda replace returneaza un sir nou fara a-l modifica pe cel initial.",
                "Original: Oroginal si Modificat: Oroginal, pentru ca metoda replace modifica sirul pe care este apelata.",
                "Original: Original si Modificat: Original, pentru ca metoda replace nu are efect asupra caracterelor.",
                "Codul nu se compileaza, pentru ca metoda replace nu accepta argumente de tip char."
            ], "A",
            """
            Clasa String este proiectata pornind de la ideea de imutabilitate: odata creat, continutul
            unui obiect String nu mai poate fi schimbat.

            Metodele clasei String returneaza un sir nou si nu il modifica pe cel original. De aceea,
            dupa apelul replace, variabila initiala ramane neschimbata, iar rezultatul modificat se
            regaseste doar in noua variabila.
            """,
            """
            Intrebarea nu este ce face metoda, ci pe ce anume actioneaza: pe sirul existent sau pe
            unul nou.
            """,
            """
            String immutable = "Original";
            String modified = immutable.replace('i', 'o');

            System.out.println("Original: " + immutable);
            System.out.println("Modificat: " + modified);
            """);

        yield return Mc("j3-015", J3, "Siruri de caractere", R3,
            """
            Care doua avantaje sunt mentionate pentru imutabilitatea sirurilor de caractere? Fiecare
            raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Obiectele imutabile sunt in mod natural sigure in context cu mai multe fire de executie.",
                "Datele din sir sunt sigure, pentru ca nu pot fi schimbate.",
                "Operatiile de concatenare repetata devin mai eficiente decat cu StringBuilder.",
                "Sirurile ocupa mai putina memorie decat tablourile de caractere.",
                "Sirurile pot fi folosite ca tipuri primitive."
            ], "A,B",
            """
            Imutabilitatea aduce trei avantaje mentionate: securitatea datelor, care nu pot fi
            schimbate, comportamentul natural sigur in context concurent, pentru ca obiectele
            imutabile sunt implicit sigure intre fire de executie, si posibilitatea de a le pastra in
            memoria cache, pentru ca au mereu aceeasi stare.

            Concatenarea repetata este exact cazul in care imutabilitatea devine dezavantajoasa;
            pentru asa ceva se recomanda StringBuilder sau StringBuffer. Sirurile sunt obiecte, nu
            tipuri primitive.
            """,
            """
            O varianta descrie tocmai situatia in care cartea recomanda sa nu folositi String.
            """);

        yield return Mc("j3-016", J3, "Siruri de caractere", R3,
            """
            Ce returneaza metoda <code>indexOf</code> atunci cand caracterul sau subsirul cautat nu
            exista in sir?
            """,
            ["Valoarea -1.", "Valoarea 0.", "Lungimea sirului.", "Arunca o exceptie."], "A",
            """
            Metoda indexOf returneaza indicele primei aparitii a caracterului sau a subsirului
            cautat. Daca acesta nu exista, metoda returneaza -1.

            Valoarea 0 nu ar putea semnala absenta, pentru ca este un indice valid, cel al primului
            caracter. Metoda nu arunca exceptie pentru absenta.
            """,
            """
            Valoarea returnata trebuie sa fie una care nu poate fi confundata cu un indice valid.
            """);

        // ---------------------------------------------------------- switch si metode

        yield return Mc("j3-017", J3, "Instructiunea switch", R3,
            """
            Incepand cu ce versiune de Java se poate folosi un obiect de tip <code>String</code> in
            instructiunea <code>switch</code>, si ce alte tipuri sunt acceptate?
            """,
            [
                "Incepand cu Java 7; sunt acceptate si char, byte, short, int si tipurile enumerate.",
                "Incepand cu Java 5; sunt acceptate si double, float si boolean.",
                "Incepand cu Java 7; sunt acceptate exclusiv tipurile enumerate si String.",
                "String nu poate fi folosit in switch in nicio versiune de Java."
            ], "A",
            """
            Variabila dintr-un switch poate fi de tip char, byte, short, int sau un tip enumerat.
            Valoarea ei este comparata cu valorile din ramurile case, iar daca se potriveste cu una
            dintre ele se executa codul corespunzator.

            Incepand cu Java 7 se poate folosi si un obiect de tip String in instructiunea switch.
            Tipurile in virgula mobila si boolean nu sunt acceptate.
            """,
            """
            Doua variante dau versiunea corecta. Ce le separa este lista completa a tipurilor
            acceptate.
            """);

        yield return Mc("j3-018", J3, "Metode", R3,
            """
            Ce este supraincarcarea metodelor si dupa ce criteriu le deosebeste compilatorul?
            """,
            [
                "Mai multe metode cu acelasi nume dar cu liste de parametri diferite; compilatorul le deosebeste dupa lista de parametri.",
                "Mai multe metode cu acelasi nume dar cu tipuri de retur diferite; compilatorul le deosebeste dupa tipul returnat.",
                "O metoda care se apeleaza pe ea insasi; compilatorul o deosebeste dupa conditia de oprire.",
                "O metoda dintr-o clasa derivata care inlocuieste una din clasa de baza; compilatorul le deosebeste dupa clasa."
            ], "A",
            """
            Supraincarcarea permite existenta mai multor metode cu acelasi nume, dar cu liste de
            parametri diferite. Tipul returnat poate fi acelasi sau diferit, insa nu el este
            criteriul: compilatorul deosebeste metodele dupa lista de parametri.

            Metoda care se apeleaza pe ea insasi este o metoda recursiva, iar inlocuirea unei metode
            din clasa de baza este suprascriere, un mecanism diferit tratat in capitolul urmator.
            """,
            """
            Doua variante descriu mecanisme diferite cu nume asemanatoare. Retineti ce anume trebuie
            sa difere intre metode pentru ca supraincarcarea sa fie valida.
            """);

        yield return Mc("j3-019", J3, "Metode", R3,
            """
            Ce rol are cazul <code>n == 0</code> in metoda recursiva de mai jos?
            """,
            [
                "Este cazul de baza, care asigura oprirea recursiei.",
                "Este cazul care initializeaza acumulatorul rezultatului.",
                "Este o verificare de siguranta, fara de care metoda ar returna un rezultat gresit dar s-ar opri.",
                "Este cazul care declanseaza apelul recursiv."
            ], "A",
            """
            Metodele din Java pot fi recursive, adica se pot apela pe ele insele, direct sau
            indirect. Recursivitatea este folosita des pentru probleme cu structura repetitiva,
            precum calculul factorialului sau parcurgerea arborilor.

            Cazul de baza este cel care asigura oprirea recursiei. Fara el, metoda s-ar apela la
            nesfarsit, nu doar ar returna un rezultat gresit.
            """,
            """
            Intrebati-va ce s-ar intampla daca acest caz ar lipsi cu totul: rezultat gresit sau
            executie fara sfarsit?
            """,
            """
            public static int factorial(int n) {
                if (n == 0) {
                    return 1;
                }
                return n * factorial(n - 1);
            }
            """);

        yield return Dropdowns("j3-020", J3, "Metode", R3,
            """
            Alegeti varianta care completeaza corect fiecare afirmatie despre declararea unei metode.
            """,
            [
                ("Modificatorul de acces stabileste",
                    ["vizibilitatea metodei", "tipul returnat", "numarul de parametri", "ordinea de executie"], 1),
                ("Cuvantul static arata ca metoda apartine",
                    ["clasei, nu unei instante anume", "unei instante anume", "pachetului curent", "clasei de baza"], 1),
                ("Tipul de retur specifica",
                    ["ce fel de valoare returneaza metoda", "cate argumente primeste metoda", "cine poate apela metoda", "daca metoda este recursiva"], 1),
                ("Numele unei metode se scrie de obicei in stilul",
                    ["camelCase", "PascalCase", "SNAKE_CASE", "kebab-case"], 1)
            ],
            """
            Sintaxa de declarare a unei metode cuprinde modificatorul de acces, care ii stabileste
            vizibilitatea, eventualul cuvant static, care arata ca metoda apartine clasei si nu unei
            instante anume, tipul returnat si numele.

            Numele metodei se scrie de obicei in stilul camelCase, iar dupa el urmeaza lista de
            parametri, separati prin virgula.
            """,
            """
            Fiecare rand se refera la o singura parte a antetului. Parcurgeti antetul de la stanga
            la dreapta.
            """);
    }
}
