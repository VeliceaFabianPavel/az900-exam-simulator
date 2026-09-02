using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 7: Concepte avansate de programare Java (p69-98 in carte, p77-106 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J7 = JavaDomains.Ch7;
    private const string R7 = "Cartea de Java, cap. 7: Concepte avansate";

    private static IEnumerable<Item> Chapter7()
    {
        // ---------------------------------------------------------- exceptii

        yield return Mc("j7-001", J7, "Tratarea exceptiilor", R7,
            """
            Ce sunt exceptiile in Java si ce se intampla daca nu sunt tratate?
            """,
            [
                "Sunt anomalii aparute in timpul executiei; netratate, provoaca oprirea brusca a programului.",
                "Sunt erori de sintaxa semnalate de compilator; netratate, impiedica generarea fisierului .class.",
                "Sunt avertismente ale masinii virtuale; netratate, incetinesc executia dar nu o opresc.",
                "Sunt mesaje de jurnalizare; netratate, sunt pur si simplu ignorate."
            ], "A",
            """
            Exceptiile sunt anomalii care apar in timpul executiei unui program. Cand aceste anomalii
            nu sunt tratate, ele provoaca oprirea brusca a programului.

            Tratarea lor ajuta la gestionarea eleganta a acestor situatii si face ca programul sa
            poata continua sau sa se incheie in mod controlat. Ele reprezinta modul in care Java
            trateaza erorile aparute la executie, nu la compilare.
            """,
            """
            Momentul aparitiei este cheia: inainte de rulare sau in timpul ei?
            """);

        yield return Mc("j7-002", J7, "Tratarea exceptiilor", R7,
            """
            O metoda arunca o exceptie pe care nu o prinde. Ce se intampla mai departe?
            """,
            [
                "Exceptia este transmisa metodei apelante, si tot asa; daca nicio metoda nu o prinde, programul se opreste brusc cu un mesaj de eroare.",
                "Exceptia este ignorata automat, iar executia continua cu instructiunea urmatoare.",
                "Masina virtuala trateaza exceptia implicit si reia executia metodei de la inceput.",
                "Programul se opreste imediat, fara a mai transmite exceptia altor metode."
            ], "A",
            """
            Daca metoda in care apare exceptia o prinde, se spune ca exceptia a fost tratata de acea
            metoda. In caz contrar, exceptia este transmisa metodei apelante si tot asa in sus pe
            lantul de apeluri.

            Daca nicio metoda nu prinde exceptia, programul se opreste brusc si mesajul de eroare este
            afisat la iesire, de obicei in consola. Daca insa exceptia este tratata de vreuna dintre
            metode, programul continua cu instructiunile de dupa blocul try-catch.
            """,
            """
            Exceptia urca pe lantul de apeluri. Intrebarea este ce se intampla cand ajunge in varf
            fara sa fie prinsa.
            """);

        yield return Mc("j7-003", J7, "Tratarea exceptiilor", R7,
            """
            Ce se afiseaza la rularea codului de mai jos?
            """,
            [
                "Doar mesajele Impartire la zero si Dupa instructiunea catch.",
                "Toate cele trei mesaje, in ordinea din cod.",
                "Doar mesajul Dupa instructiunea catch.",
                "Doar mesajul Impartire la zero, apoi programul se opreste."
            ], "A",
            """
            Impartirea la zero arunca o exceptie de tip ArithmeticException chiar la linia de
            atribuire. Instructiunea de afisare care urmeaza in blocul try nu se mai executa, pentru
            ca executia blocului este intrerupta in punctul in care apare exceptia.

            Controlul trece la blocul catch, care afiseaza primul mesaj. Dupa tratarea exceptiei,
            programul continua normal cu instructiunile de dupa blocul try-catch, deci se afiseaza si
            al doilea mesaj.
            """,
            """
            Urmariti unde anume se opreste executia blocului try si unde reia dupa catch.
            """,
            """
            int d, a;
            try {
                d = 0;
                a = 42 / d;
                System.out.println("Aceasta nu se va afisa.");
            } catch (ArithmeticException e) {
                System.out.println("Impartire la zero.");
            }
            System.out.println("Dupa instructiunea catch.");
            """);

        yield return Mc("j7-004", J7, "Ierarhia exceptiilor", R7,
            """
            Care este clasa aflata in varful ierarhiei exceptiilor din Java?
            """,
            ["Throwable.", "Exception.", "Error.", "RuntimeException."], "A",
            """
            Ierarhia incepe cu Throwable. Sub aceasta se afla Exception si Error, iar sub Exception se
            afla RuntimeException.

            Distinctia dintre Exception si Error este importanta: Error semnaleaza probleme grave,
            de regula in afara controlului aplicatiei, in timp ce Exception acopera situatiile pe care
            un program le poate trata.
            """,
            """
            Numele clasei din varf descrie exact ce au in comun toate celelalte: pot fi aruncate.
            """);

        yield return Mc("j7-005", J7, "Tratarea exceptiilor", R7,
            """
            Care este diferenta dintre cuvintele cheie <code>throw</code> si <code>throws</code>?
            """,
            [
                "throw arunca efectiv o exceptie in corpul metodei, iar throws o declara in antetul metodei.",
                "throw declara exceptia in antetul metodei, iar throws o arunca efectiv in corpul ei.",
                "throw se foloseste pentru exceptiile proprii, iar throws doar pentru cele din biblioteca standard.",
                "Cele doua sunt sinonime si pot fi folosite interschimbabil."
            ], "A",
            """
            Cuvantul throw arunca efectiv o exceptie din interiorul corpului unei metode, de exemplu
            prin crearea unui obiect nou de tip exceptie. Cuvantul throws se foloseste in antetul
            metodei pentru a declara ce exceptii poate arunca acea metoda.

            O exceptie prinsa poate fi si rearuncata cu throw, dupa ce a fost tratata partial, ceea ce
            permite metodei apelante sa o trateze la randul ei.
            """,
            """
            Diferenta este de loc: unul apare in corpul metodei, celalalt in antetul ei.
            """);

        yield return Mc("j7-006", J7, "Tratarea exceptiilor", R7,
            """
            Care doua afirmatii despre blocurile <code>try-catch</code> sunt corecte? Fiecare raspuns
            corect reprezinta o parte a solutiei.
            """,
            [
                "Un bloc try poate avea mai multe blocuri catch, pentru tipuri diferite de exceptii.",
                "Blocurile try-catch pot fi imbricate unele in altele.",
                "Un bloc try poate avea cel mult un singur bloc catch.",
                "Blocul finally se executa doar daca nu a aparut nicio exceptie.",
                "O exceptie prinsa nu mai poate fi aruncata din nou."
            ], "A,B",
            """
            Un bloc try poate avea mai multe blocuri catch, fiecare tratand un alt tip de exceptie, si
            blocurile try-catch pot fi imbricate unele in altele.

            Celelalte afirmatii sunt false. Blocul finally contine cod care se executa dupa incheierea
            blocului try, iar o exceptie prinsa poate fi rearuncata cu throw, asa cum arata exemplul
            din carte cu rearuncarea unei exceptii de tip NullPointerException.
            """,
            """
            Doua dintre variantele gresite impun o limita care nu exista, iar a treia contrazice
            exemplul de rearuncare.
            """);

        yield return Mc("j7-007", J7, "Strategii de tratare a exceptiilor", R7,
            """
            Ce trebuie evitat atunci cand se jurnalizeaza o exceptie?
            """,
            [
                "Inregistrarea informatiilor sensibile in jurnal.",
                "Inregistrarea intregii stive de apeluri.",
                "Oferirea de context despre operatiile in desfasurare.",
                "Folosirea unei biblioteci de jurnalizare in locul afisarii in consola."
            ], "A",
            """
            Jurnalizarea exceptiilor lasa o urma care ajuta dezvoltatorii sa diagnosticheze cauzele.
            Recomandarile sunt sa se inregistreze intreaga stiva de apeluri si sa se ofere context
            despre operatiile in desfasurare in momentul aparitiei exceptiei.

            Ceea ce trebuie evitat este inregistrarea informatiilor sensibile in jurnal. Primele doua
            variante gresite sunt de fapt recomandari, nu greseli.
            """,
            """
            Trei dintre variante sunt lucruri recomandate. Cautati-o pe cea care ar crea o problema de
            securitate.
            """);

        yield return Drag("j7-008", J7, "Jurnalizare", R7,
            """
            Potriviti fiecare tip de jurnal cu ce semnaleaza. Fiecare tip poate fi folosit o data, de
            mai multe ori sau deloc.
            """,
            "Tipuri de jurnal",
            [
                "Debug",
                "Info",
                "Warning",
                "Error",
                "Fatal"
            ],
            [
                ("Informatii detaliate despre executie, folosite de dezvoltatori la depanare", 1),
                ("Mesaje operationale generale despre fluxul aplicatiei", 2),
                ("Ceva neasteptat, care ar putea fi o problema dar nu intrerupe aplicatia", 3),
                ("Ceva a mers prost, adesea insotit de stiva de apeluri", 4),
                ("Probleme grave, care ar putea duce la oprirea aplicatiei", 5)
            ],
            """
            Cele cinci niveluri formeaza o scara de gravitate. Debug ofera detalii de executie pentru
            dezvoltatori, Info descrie fluxul normal al aplicatiei, iar Warning semnaleaza ceva
            neasteptat care nu intrerupe functionarea.

            Error arata ca ceva a mers prost, de regula cu stiva de apeluri inclusa, iar Fatal sau
            Critical semnaleaza probleme grave care pot duce la oprirea aplicatiei.
            """,
            """
            Randurile sunt asezate in ordinea crescatoare a gravitatii. Potriviti-le in aceeasi
            ordine.
            """);

        // ---------------------------------------------------------- fire de executie

        yield return Mc("j7-009", J7, "Fire de executie", R7,
            """
            Ce este un fir de executie si prin ce se deosebeste de o functie obisnuita?
            """,
            [
                "Este o secventa de instructiuni dintr-un proces, executata in paralel cu alte secvente similare; spre deosebire de o functie, permite rularea in paralel.",
                "Este o copie a intregului proces, cu propria memorie, executata independent.",
                "Este o functie care se apeleaza automat la pornirea programului.",
                "Este o metoda sincronizata, care nu poate fi apelata din mai multe locuri deodata."
            ], "A",
            """
            Un fir de executie este o secventa de instructiuni dintr-un proces, executata in paralel
            cu alte secvente similare. Reprezinta o singura secventa de instructiuni in cadrul unui
            proces.

            Spre deosebire de o functie simpla, un fir permite codului sa ruleze in paralel cu alte
            secvente de instructiuni. Firele pot fi sincronizate si pot comunica intre ele prin mesaje
            sau prin apeluri de functii.
            """,
            """
            Cuvantul cheie din definitie este paralel. Comparati cu ce se intampla la un apel obisnuit
            de functie.
            """);

        yield return Mc("j7-010", J7, "Fire de executie", R7,
            """
            Care sunt cele doua moduri de a crea un fir de executie prezentate in carte?
            """,
            [
                "Implementarea interfetei Runnable sau extinderea clasei Thread.",
                "Extinderea interfetei Runnable sau implementarea clasei Thread.",
                "Apelarea metodei start pe obiectul curent sau folosirea cuvantului cheie synchronized.",
                "Crearea unui obiect de tip Executor sau apelarea metodei sleep."
            ], "A",
            """
            Prima metoda este implementarea interfetei Runnable, in care clasa isi creeaza un obiect
            Thread si ii transmite propria referinta. A doua metoda este extinderea clasei Thread.

            In ambele cazuri, punctul de intrare al firului este metoda run, iar firul porneste prin
            apelul metodei start. Interfetele se implementeaza si clasele se extind, nu invers.
            """,
            """
            Una dintre cai porneste de la o interfata, cealalta de la o clasa. Atentie la cuvantul
            cheie potrivit pentru fiecare.
            """);

        yield return Mc("j7-011", J7, "Fire de executie", R7,
            """
            Care este rolul metodelor <code>isAlive</code> si <code>join</code>?
            """,
            [
                "isAlive arata daca un fir mai ruleaza sau s-a incheiat, iar join permite unui fir sa astepte pana cand altul isi termina executia.",
                "isAlive porneste un fir oprit, iar join uneste doua fire intr-unul singur.",
                "isAlive verifica daca firul este sincronizat, iar join il adauga intr-un grup de fire.",
                "isAlive returneaza numele firului, iar join ii schimba prioritatea."
            ], "A",
            """
            Scopul principal al metodei isAlive este sa spuna daca un fir este inca in executie sau
            s-a terminat, ceea ce ajuta la monitorizarea si gestionarea comportamentului firelor.

            Metoda join permite unui fir sa astepte pana cand altul isi incheie executia. Este
            folosita pentru executie secventiala, pentru dependente de resurse intre fire, pentru a
            asigura incheierea tuturor firelor inainte de curatare si pentru a evita problemele de
            concurenta.
            """,
            """
            Una raspunde la o intrebare, cealalta produce o asteptare.
            """);

        yield return Mc("j7-012", J7, "Sincronizare", R7,
            """
            Ce este o conditie de cursa si cum o previne sincronizarea?
            """,
            [
                "Apare cand doua sau mai multe fire acceseaza si modifica simultan aceleasi date, iar rezultatul depinde de ordinea accesului; sincronizarea permite accesul unui singur fir la un moment dat.",
                "Apare cand un fir consuma prea mult procesor, iar sincronizarea ii reduce prioritatea.",
                "Apare cand doua fire asteapta la infinit resurse detinute reciproc, iar sincronizarea le opreste pe amandoua.",
                "Apare cand un fir este pornit de doua ori, iar sincronizarea impiedica al doilea apel al metodei start."
            ], "A",
            """
            O conditie de cursa apare cand doua sau mai multe fire pot accesa date partajate si
            incearca sa le modifice simultan. Daca ordinea in care firele acceseaza datele afecteaza
            rezultatul final, atunci poate aparea o conditie de cursa.

            Sincronizarea se asigura ca un singur fir poate accesa resursa partajata la un moment dat,
            prevenind astfel conditiile de cursa. Situatia descrisa in a treia varianta este
            interblocajul, o alta problema pe care sincronizarea aplicata judicios o poate preveni.
            """,
            """
            O varianta gresita descrie o alta problema de concurenta, care are propriul nume in carte.
            """);

        yield return Mc("j7-013", J7, "Sincronizare", R7,
            """
            Ce este interblocajul si de ce apare?
            """,
            [
                "Doua sau mai multe fire asteapta la infinit un set de resurse, fiecare detinand o resursa si asteptand alta.",
                "Un fir consuma toata memoria disponibila si impiedica pornirea altor fire.",
                "Un fir modifica date partajate in timp ce altul le citeste, rezultand valori inconsistente.",
                "Un fir se opreste inainte de a elibera memoria alocata."
            ], "A",
            """
            Interblocajul apare atunci cand doua sau mai multe fire asteapta la infinit un set de
            resurse, fiecare fir detinand un blocaj asupra unei resurse si asteptand alta.

            Tehnicile de sincronizare aplicate cu discernamant pot ajuta la prevenirea acestor
            situatii. Varianta a treia descrie o problema de integritate a datelor, alt motiv pentru
            care sincronizarea este necesara.
            """,
            """
            Cuvantul cheie este reciproc: fiecare are ceva ce ii trebuie celuilalt.
            """);

        yield return Mc("j7-014", J7, "Sincronizare", R7,
            """
            Care doua motive justifica folosirea sincronizarii intr-un program cu mai multe fire?
            Fiecare raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Pastrarea integritatii datelor partajate, care altfel ar putea fi citite invechite sau incorecte.",
                "Garantarea ordinii de executie, atunci cand anumite procese trebuie sa se petreaca intr-o anumita secventa.",
                "Cresterea numarului de fire care pot rula simultan.",
                "Eliminarea nevoii de a trata exceptii in firele secundare.",
                "Reducerea automata a consumului de memorie al aplicatiei."
            ], "A,B",
            """
            Fara sincronizare, firele ar putea citi valori invechite sau incorecte din resursele
            partajate; sincronizarea accesului asigura ca datele partajate raman consistente. De
            asemenea, unele procese trebuie sa se petreaca intr-o anumita ordine, iar mecanismele de
            sincronizare pot garanta acea ordine.

            Sincronizarea nu creste numarul de fire si nu are legatura cu tratarea exceptiilor sau cu
            consumul de memorie. Ea ajuta insa la utilizarea eficienta a resurselor, evitand irosirea
            ciclurilor de procesor.
            """,
            """
            Ambele motive corecte se refera la ce se intampla cu datele si cu ordinea, nu la cate fire
            ruleaza.
            """);

        // ---------------------------------------------------------- lambda

        yield return Mc("j7-015", J7, "Expresii lambda", R7,
            """
            Incepand cu ce versiune de Java au fost introduse expresiile lambda si ce reprezinta o
            interfata functionala?
            """,
            [
                "Java 8; o interfata functionala contine exact o singura metoda abstracta, putand avea insa si metode implicite sau statice.",
                "Java 7; o interfata functionala contine exact doua metode abstracte.",
                "Java 8; o interfata functionala este orice interfata care nu declara nicio metoda.",
                "Java 11; o interfata functionala este o interfata care extinde alta interfata."
            ], "A",
            """
            Expresiile lambda au fost introduse in Java 8 si ofera un mod concis de a reprezenta
            interfetele functionale.

            O interfata functionala este o interfata care contine exact o singura metoda abstracta,
            desi poate contine si metode implicite sau statice suplimentare. Expresiile lambda permit
            exprimarea instantelor unor astfel de interfete intr-un mod mult mai concis si mai
            expresiv.
            """,
            """
            Numarul din definitia interfetei functionale este ceea ce face posibila scrierea concisa.
            """);

        yield return Mc("j7-016", J7, "Expresii lambda", R7,
            """
            Ce afiseaza codul de mai jos?
            """,
            [
                "true, pentru ca lambda verifica daca restul impartirii la 2 este zero, iar 10 este par.",
                "false, pentru ca lambda verifica daca numarul este impar.",
                "10, pentru ca metoda test returneaza valoarea primita.",
                "Codul nu se compileaza, pentru ca Predicate nu accepta expresii lambda."
            ], "A",
            """
            Expresiile lambda sunt folosite adesea cu interfete functionale predefinite din Java,
            precum Predicate, Function si Consumer.

            Aici lambda primeste un numar si returneaza rezultatul comparatiei dintre restul impartirii
            la 2 si zero. Pentru valoarea 10, restul este zero, deci rezultatul afisat este true.
            """,
            """
            Cititi expresia din dreapta sagetii ca pe corpul unei metode care returneaza un boolean.
            """,
            """
            Predicate<Integer> isEven = number -> number % 2 == 0;
            System.out.println(isEven.test(10));
            """);

        yield return Dropdowns("j7-017", J7, "Expresii lambda", R7,
            """
            Alegeti varianta care completeaza corect fiecare afirmatie despre sintaxa expresiilor
            lambda.
            """,
            [
                ("O expresie lambda fara parametri se scrie",
                    ["() -> instructiune", "-> instructiune", "(void) -> instructiune", "lambda -> instructiune"], 1),
                ("Cand corpul contine mai multe instructiuni, acesta se scrie",
                    ["intre acolade", "intre paranteze rotunde", "intre paranteze drepte", "fara delimitatori"], 1),
                ("Pentru un singur parametru, tipul acestuia",
                    ["poate fi omis", "trebuie declarat obligatoriu", "trebuie sa fie Object", "trebuie sa fie final"], 1),
                ("Simbolul care separa parametrii de corp este",
                    ["->", "=>", "::", ":"], 1)
            ],
            """
            Sintaxa unei expresii lambda este parametri urmati de sageata si apoi de expresie sau de
            un bloc de instructiuni. Fara parametri se scriu paranteze rotunde goale, iar pentru un
            singur parametru tipul poate fi omis.

            Cand corpul contine mai multe instructiuni, acesta se scrie intre acolade, iar valoarea se
            returneaza explicit. Simbolul de separare este sageata formata din minus si semnul mai
            mare.
            """,
            """
            Toate cele patru raspunsuri se pot verifica pe exemplele scurte din carte.
            """);

        yield return Mc("j7-018", J7, "Expresii lambda", R7,
            """
            Care doua avantaje ale expresiilor lambda sunt mentionate in carte? Fiecare raspuns corect
            reprezinta o parte a solutiei.
            """,
            [
                "Reduc codul repetitiv, facand exprimarea mai concisa.",
                "Se integreaza direct cu Stream API din Java 8.",
                "Elimina nevoia de a trata exceptiile in interiorul lor.",
                "Permit accesul direct la memoria obiectelor.",
                "Fac programele sa ruleze pe orice versiune de Java, indiferent de vechime."
            ], "A,B",
            """
            Avantajele mentionate sunt concizia, prin reducerea codului repetitiv, introducerea unor
            capabilitati de programare functionala, imbunatatirea lizibilitatii prin concentrarea pe
            logica de business si integrarea cu Stream API din Java 8.

            Ultima varianta contrazine chiar conditia de folosire: expresiile lambda cer Java 8 sau
            mai nou, deci nu asigura rularea pe versiuni mai vechi.
            """,
            """
            O varianta gresita promite exact opusul faptului ca lambda a aparut intr-o anumita
            versiune.
            """);

        // ---------------------------------------------------------- intrari si iesiri

        yield return Mc("j7-019", J7, "Intrari si iesiri", R7,
            """
            Ce reprezinta serializarea unui obiect?
            """,
            [
                "Transformarea obiectului intr-o forma care poate fi salvata sau transmisa, si apoi reconstruita.",
                "Executarea metodelor obiectului intr-o ordine strict secventiala.",
                "Sincronizarea accesului la obiect intre mai multe fire de executie.",
                "Conversia obiectului intr-un sir de caractere prin metoda toString."
            ], "A",
            """
            Serializarea este mecanismul prin care un obiect este transformat intr-o forma ce poate fi
            salvata pe disc sau transmisa, urmand ca ulterior sa fie reconstruit.

            Nu are legatura cu ordinea de executie a metodelor si nici cu sincronizarea intre fire.
            Metoda toString produce o descriere textuala a obiectului, ceea ce este cu totul altceva
            decat serializarea.
            """,
            """
            Numele operatiei se refera la transformarea intr-o serie de octeti, nu la o ordine de
            executie.
            """);

        yield return Mc("j7-020", J7, "Fire de executie", R7,
            """
            Ce metoda constituie punctul de intrare al unui fir de executie si ce metoda il porneste?
            """,
            [
                "Punctul de intrare este metoda run, iar firul se porneste prin apelul metodei start.",
                "Punctul de intrare este metoda start, iar firul se porneste prin apelul metodei run.",
                "Punctul de intrare este metoda main, iar firul se porneste prin apelul metodei execute.",
                "Punctul de intrare este constructorul clasei, iar firul se porneste automat la instantiere."
            ], "A",
            """
            Metoda run este punctul de intrare al firului, adica locul unde incepe executia codului
            care ruleaza in paralel. Firul propriu-zis se porneste prin apelul metodei start.

            Confuzia dintre cele doua este frecventa. Apelarea directa a metodei run ar executa codul
            pe firul curent, nu pe unul nou; doar start creeaza un fir nou de executie.
            """,
            """
            Una dintre metode este scrisa de programator, cealalta este apelata de el. Care este care?
            """);
    }
}
