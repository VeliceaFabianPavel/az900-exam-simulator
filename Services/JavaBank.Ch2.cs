using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Capitolul 2: Prezentare generala a limbajului Java (p3-14 in carte, p11-22 in PDF).
// Formulare originala, scrisa pe baza continutului factual al capitolului.
public static partial class JavaBank
{
    private static readonly ExamDomain J2 = JavaDomains.Ch2;
    private const string R2 = "Cartea de Java, cap. 2: Prezentare generala";

    private static IEnumerable<Item> Chapter2()
    {
        // ---------------------------------------------------------- istoric si scop

        yield return Mc("j2-001", J2, "Istoricul si scopul limbajului Java", R2,
            """
            Un coleg sustine ca Java a fost creat de la inceput ca limbaj de uz general pentru
            aplicatii de intreprindere.

            Care este raspunsul corect, potrivit contextului in care a aparut limbajul?
            """,
            [
                "Java a fost proiectat initial pentru aparatura electronica de consum, iar abia apoi a devenit limbaj de uz general.",
                "Java a fost proiectat de la inceput pentru aplicatii de intreprindere si a ramas folosit doar acolo.",
                "Java a fost proiectat initial pentru calcul stiintific, iar ulterior a fost adaptat pentru web.",
                "Java a fost proiectat initial ca limbaj de scriptare pentru pagini web."
            ], "A",
            """
            Java a fost creat la mijlocul anilor 1990 de o echipa de la Sun Microsystems condusa de
            James Gosling, cu scopul de a obtine un limbaj simplu, robust si portabil. Tinta initiala
            au fost dispozitivele electronice de consum, precum set-top box-uri si dispozitive
            portabile.

            Popularitatea ca limbaj de uz general a venit dupa aceea, tocmai datorita
            caracteristicilor sale. Aplicatiile de intreprindere si cele web sunt domenii in care
            Java este folosit astazi pe scara larga, dar nu au fost punctul de plecare.
            """,
            """
            Intrebarea nu este unde se foloseste Java acum, ci pentru ce fel de aparate a fost
            gandit la inceput.
            """);

        yield return Mc("j2-002", J2, "Istoricul si scopul limbajului Java", R2,
            """
            Cine a condus echipa care a creat limbajul Java si la ce companie lucra aceasta echipa?
            """,
            [
                "James Gosling, la Sun Microsystems.",
                "James Gosling, la Oracle.",
                "Bjarne Stroustrup, la Sun Microsystems.",
                "Guido van Rossum, la Sun Microsystems."
            ], "A",
            """
            Java a fost creat de o echipa de la Sun Microsystems condusa de James Gosling, la
            mijlocul anilor 1990.

            Oracle apare mai tarziu in istoria limbajului, ca detinator al platformei, nu ca loc al
            crearii ei. Bjarne Stroustrup este autorul limbajului C++, iar Guido van Rossum al
            limbajului Python.
            """,
            """
            Compania care apare in raspuns este cea de la momentul crearii, nu cea care detine
            astazi platforma.
            """);

        // ---------------------------------------------------------- bytecode si JVM

        yield return Mc("j2-003", J2, "Compilare, bytecode si masina virtuala", R2,
            """
            Ce produce compilatorul atunci cand o clasa Java este compilata si cine executa
            rezultatul?
            """,
            [
                "Produce bytecode, portabil pe orice arhitectura de procesor, executat de masina virtuala Java.",
                "Produce cod masina nativ pentru procesorul calculatorului pe care s-a compilat, executat direct de sistemul de operare.",
                "Produce cod sursa optimizat, interpretat linie cu linie de compilator la fiecare rulare.",
                "Produce bytecode, executat direct de procesor fara niciun intermediar."
            ], "A",
            """
            La compilare, codul sursa este transformat in bytecode, un limbaj masina care este
            portabil pe orice arhitectura de procesor. Bytecode-ul nu este direct executabil de
            procesor.

            Executia este posibila datorita masinii virtuale Java, care interpreteaza bytecode-ul si
            il traduce in limbaj masina specific calculatorului pe care ruleaza programul. Aceasta
            este exact deosebirea fata de limbajele compilate direct in cod nativ.
            """,
            """
            Doua variante mentioneaza bytecode. Ce le separa este daca mai exista sau nu ceva intre
            bytecode si procesor.
            """);

        yield return Mc("j2-004", J2, "Compilare, bytecode si masina virtuala", R2,
            """
            Ce face compilatorul JIT in timpul executiei unui program Java si de ce este util?
            """,
            [
                "Converteste bytecode-ul in cod masina nativ la momentul rularii, optimizandu-l pentru arhitectura masinii, ceea ce accelereaza executia.",
                "Compileaza codul sursa in bytecode inainte de rulare, ceea ce reduce dimensiunea fisierelor .class.",
                "Verifica sintaxa codului sursa la fiecare rulare, ceea ce previne erorile de compilare.",
                "Traduce codul Java in C++ inainte de compilare, ceea ce permite folosirea bibliotecilor native."
            ], "A",
            """
            Procesul are doua etape. Intai, codul sursa este compilat in bytecode, care este
            independent de platforma. Apoi, la rulare, compilatorul JIT converteste bytecode-ul in
            cod masina nativ, optimizat pentru arhitectura concreta a masinii.

            Castigul este de viteza: codul nativ se executa direct de catre masina, in loc sa fie
            interpretat din nou la fiecare rulare a programului.
            """,
            """
            Numele contine "just-in-time". Intrebarea este in ce moment intervine si ce
            transformare face.
            """);

        yield return Mc("j2-005", J2, "Compilare, bytecode si masina virtuala", R2,
            """
            Care doua afirmatii despre masina virtuala Java sunt corecte? Fiecare raspuns corect
            reprezinta o parte a solutiei.
            """,
            [
                "Gestioneaza automat memoria si elibereaza, printr-un colector de gunoi, memoria care nu mai este folosita.",
                "Ofera un mediu izolat, in care programele nu pot accesa direct resursele sistemului fara permisiune.",
                "Traduce codul sursa Java direct in cod masina, fara etapa de bytecode.",
                "Elimina nevoia de a instala orice altceva pe calculatorul pe care se dezvolta aplicatii.",
                "Face programele Java mai rapide decat programele scrise in C sau C++."
            ], "A,B",
            """
            Doua dintre avantajele importante ale masinii virtuale sunt gestiunea automata a
            memoriei, prin colectorul de gunoi care recupereaza memoria nefolosita, si modelul de
            securitate, care ruleaza programele intr-un mediu izolat fata de sistemul de operare.

            Celelalte variante sunt false. Etapa de bytecode exista intotdeauna; pentru dezvoltare
            este nevoie de JDK, nu doar de masina virtuala; iar interpretarea bytecode-ului face
            programele Java in general mai lente decat cele compilate nativ in C sau C++, chiar daca
            diferenta s-a redus de la o versiune la alta.
            """,
            """
            O varianta face o afirmatie despre viteza care contrazice ceea ce spune cartea despre
            pretul portabilitatii.
            """);

        // ---------------------------------------------------------- JDK, JRE, unelte

        yield return Mc("j2-006", J2, "Mediul de dezvoltare Java", R2,
            """
            Un student are instalat doar JRE si incearca sa compileze un fisier sursa cu javac.

            De ce nu functioneaza si ce trebuie instalat?
            """,
            [
                "JRE contine masina virtuala si bibliotecile necesare rularii, dar nu si compilatorul; este nevoie de JDK, care include JRE plus uneltele de dezvoltare.",
                "JRE contine compilatorul, dar acesta trebuie activat separat dintr-un fisier de configurare.",
                "JRE este suficient pentru compilare, deci problema este exclusiv una de variabile de mediu.",
                "Este nevoie de un IDE, deoarece compilarea din linia de comanda nu este posibila in Java."
            ], "A",
            """
            JRE, mediul de rulare, ofera bibliotecile, masina virtuala si celelalte componente
            necesare pentru a rula aplicatii si applet-uri. Poate fi redistribuit impreuna cu o
            aplicatie pentru a-i da autonomie.

            JDK include JRE si adauga uneltele de care are nevoie un dezvoltator, printre care
            compilatorul si depanatorul. Fara JDK nu exista javac. Compilarea din linia de comanda
            este perfect posibila; un IDE este o comoditate, nu o conditie.
            """,
            """
            Relatia dintre cele doua este de includere. Intrebarea este care il contine pe celalalt
            si ce anume adauga.
            """);

        yield return Drag("j2-007", J2, "Mediul de dezvoltare Java", R2,
            """
            Potriviti fiecare unealta cu rolul pe care il indeplineste in dezvoltarea Java. Fiecare
            unealta poate fi folosita o data, de mai multe ori sau deloc.
            """,
            "Unelte",
            [
                "javac",
                "java",
                "javadoc",
                "JUnit",
                "Maven"
            ],
            [
                ("Compileaza codul sursa in bytecode", 1),
                ("Ruleaza o aplicatie Java deja compilata", 2),
                ("Genereaza documentatia din comentariile codului", 3),
                ("Scrie si ruleaza teste automate", 4),
                ("Automatizeaza construirea si impachetarea aplicatiei", 5)
            ],
            """
            Cele trei unelte de baza din kit sunt javac pentru compilare, java pentru rulare si
            javadoc pentru documentatie.

            JUnit este un cadru de testare, folosit pentru teste automate, iar Maven este o unealta
            de constructie, alaturi de Gradle, care automatizeaza construirea si impachetarea
            aplicatiei. Ultimele doua nu fac parte din kitul de dezvoltare propriu-zis, ci din
            ecosistemul din jurul lui.
            """,
            """
            Primele trei randuri se refera la uneltele din kit. Ultimele doua se refera la unelte
            din jurul lui, folosite in proiecte mai mari.
            """);

        // ---------------------------------------------------------- primul program

        yield return Mc("j2-008", J2, "Structura primului program", R2,
            """
            Fisierul de mai jos este salvat cu numele <code>Program.java</code>.

            Ce se intampla la compilare si de ce?
            """,
            [
                "Compilarea esueaza, pentru ca numele clasei publice trebuie sa coincida cu numele fisierului.",
                "Compilarea reuseste, pentru ca numele fisierului nu are nicio legatura cu numele clasei.",
                "Compilarea reuseste, dar se genereaza un fisier Program.class in loc de Example.class.",
                "Compilarea esueaza, pentru ca metoda main nu poate primi un tablou de siruri."
            ], "A",
            """
            In Java, numele clasei publice trebuie sa fie identic cu numele fisierului in care se
            afla acea clasa. Clasa se numeste Example, deci fisierul ar trebui sa fie Example.java.

            Java este, ca si C, sensibil la litere mari si mici, deci Example, example si eXample
            sunt nume diferite. La compilare, fiecare clasa ajunge intr-un fisier .class numit dupa
            clasa, nu dupa fisierul sursa, ceea ce face varianta C gresita si in privinta numelui
            rezultat. Semnatura cu tablou de siruri este exact cea corecta pentru main.
            """,
            """
            Comparati cu atentie numele din prima linie de cod cu numele fisierului din enunt.
            """,
            """
            public class Example {
                public static void main(String args[]) {
                    System.out.println("Hello Java!");
                }
            }
            """);

        yield return Dropdowns("j2-009", J2, "Structura primului program", R2,
            """
            Alegeti varianta care completeaza corect fiecare afirmatie despre antetul metodei
            <code>public static void main(String args[])</code>.
            """,
            [
                ("Cuvantul public este",
                    ["un specificator de acces", "un tip de date", "o valoare returnata", "un nume de pachet"], 1),
                ("Cuvantul static permite",
                    ["apelarea metodei fara a instantia clasa", "returnarea mai multor valori", "accesul la fisiere", "rularea metodei pe alt fir de executie"], 1),
                ("Cuvantul void arata ca metoda",
                    ["nu returneaza nicio valoare", "returneaza un intreg", "nu primeste parametri", "nu poate fi apelata"], 1),
                ("Parametrul String args[] reprezinta",
                    ["colectia argumentelor primite la rulare", "numele clasei curente", "fluxul de iesire al consolei", "lista metodelor clasei"], 1)
            ],
            """
            Antetul metodei main contine patru elemente pe care merita sa le puteti citi separat.
            public este un specificator de acces si stabileste cum pot alte clase sa ajunga la
            membrii clasei. static permite apelarea metodei fara a crea un obiect al clasei, ceea ce
            este necesar pentru ca main este punctul de intrare al programului.

            void spune compilatorului ca metoda nu returneaza nicio valoare, iar String args[]
            declara colectia de obiecte de tip sir de caractere primite ca argumente la rulare.
            """,
            """
            Fiecare rand se refera la un singur cuvant din antet. Cititi antetul de la stanga la
            dreapta si raspundeti pe rand.
            """);

        yield return Mc("j2-010", J2, "Structura primului program", R2,
            """
            Ce reprezinta <code>System.out</code> in instructiunea de afisare din primul program?
            """,
            [
                "Un obiect care incapsuleaza iesirea catre consola, unde System este o clasa predefinita, iar out fluxul de iesire.",
                "O metoda predefinita care primeste un sir si il afiseaza pe ecran.",
                "Un pachet din biblioteca standard care trebuie importat explicit.",
                "O variabila locala definita automat in interiorul metodei main."
            ], "A",
            """
            System este o clasa predefinita care ofera acces la sistem, iar out este fluxul de
            iesire conectat la consola. Impreuna, System.out este un obiect care incapsuleaza
            iesirea catre consola.

            Metoda propriu-zisa este println, apelata pe acel obiect. Nu este vorba de un pachet si
            nici de o variabila locala. Consola nu este folosita frecvent in aplicatiile reale, dar
            este utila in procesul de invatare.
            """,
            """
            Descompuneti expresia in cele trei parti ale ei si stabiliti ce este fiecare: clasa,
            obiect sau metoda.
            """);

        // ---------------------------------------------------------- erori

        yield return Mc("j2-011", J2, "Erori de sintaxa si erori la rulare", R2,
            """
            Un program se compileaza fara probleme, dar la rulare afiseaza
            <code>ArrayIndexOutOfBoundsException</code> atunci cand incearca sa citeasca
            <code>args[1]</code>.

            Ce fel de eroare este si care este cauza?
            """,
            [
                "O eroare la rulare, cauzata de o situatie neprevazuta: programul presupune ca exista argumente, dar sirul de argumente este gol.",
                "O eroare de sintaxa, pe care compilatorul ar fi trebuit sa o semnaleze inainte de rulare.",
                "O eroare de compilare intarziata, care apare doar cand clasa este incarcata de interpretor.",
                "O eroare de mediu, cauzata de o versiune gresita a masinii virtuale."
            ], "A",
            """
            Erorile de sintaxa sunt semnalate de compilator inainte de rulare. Aceasta eroare apare
            la executie, deci este o eroare la rulare, produsa de o situatie pe care programatorul
            nu a prevazut-o.

            Concret, codul presupune ca exista cel putin doua argumente transmise la lansare, cand
            in realitate sirul de argumente este gol. Accesarea argumentului cu indicele 1 devine
            astfel o eroare.
            """,
            """
            Momentul in care apare mesajul spune totul: inainte de rulare sau in timpul ei.
            """);

        yield return Mc("j2-012", J2, "Erori de sintaxa si erori la rulare", R2,
            """
            La compilarea unui program caruia ii lipseste o acolada deschisa, compilatorul
            raporteaza ca lipseste un caracter punct si virgula, pe o linie care pare corecta.

            Cum ar trebui interpretat mesajul?
            """,
            [
                "Mesajul nu trebuie luat literal: trebuie analizat contextul si liniile din jurul locului semnalat, pentru a deduce cauza reala.",
                "Mesajul trebuie luat literal si trebuie adaugat caracterul punct si virgula pe linia indicata.",
                "Mesajul indica o eroare in masina virtuala si programul trebuie recompilat cu alta versiune.",
                "Mesajul este intotdeauna corect, deci linia raportata contine cu siguranta eroarea."
            ], "A",
            """
            Compilatorul incearca sa dea un inteles codului sursa oricum ar arata acesta, asa ca
            eroarea raportata nu reflecta de obicei cauza reala a problemei.

            Cand un program contine o eroare de sintaxa, mesajul nu trebuie interpretat cuvant cu
            cuvant. Este nevoie sa priviti contextul in care apare eroarea si liniile din jurul
            locului semnalat, pentru a deduce cauza adevarata.
            """,
            """
            Exemplul din carte arata un mesaj care indica alt caracter decat cel care lipseste cu
            adevarat. Ce concluzie trageti din asta despre mesajele compilatorului?
            """);

        // ---------------------------------------------------------- rolul limbajului

        yield return Mc("j2-013", J2, "Rolul limbajului Java in dezvoltarea software", R2,
            """
            Care doua domenii sunt mentionate ca zone importante de utilizare a limbajului Java?
            Fiecare raspuns corect reprezinta o parte a solutiei.
            """,
            [
                "Dezvoltarea de aplicatii mobile pentru Android.",
                "Aplicatii de intreprindere de mari dimensiuni.",
                "Scrierea de nuclee de sisteme de operare.",
                "Programarea microcontrolerelor de 8 biti fara sistem de operare.",
                "Editarea video in timp real pe placi grafice."
            ], "A,B",
            """
            Java este folosit pe scara larga pentru aplicatii de intreprindere de mari dimensiuni,
            datorita scalabilitatii si robustetii, si pentru dezvoltarea de aplicatii mobile pe
            Android, unul dintre cele mai raspandite sisteme de operare mobile.

            Alaturi de acestea, cartea mentioneaza dezvoltarea web, in special aplicatii de partea
            serverului si servicii web, si calculul stiintific. Nucleele de sisteme de operare si
            microcontrolerele foarte mici raman domeniul limbajelor compilate nativ.
            """,
            """
            Ganditi-va la domeniile in care conteaza scalabilitatea si portabilitatea, nu la cele in
            care conteaza accesul direct la hardware.
            """);

        yield return Mc("j2-014", J2, "Platforma si pachetele Java", R2,
            """
            Ce reprezinta platforma Java si cum sunt organizate clasele ei?
            """,
            [
                "Este ansamblul claselor Java existente in orice kit de instalare, grupate in pachete organizate dupa rol, precum retea, grafica sau securitate.",
                "Este exclusiv masina virtuala, fara biblioteci, iar clasele se descarca la prima rulare.",
                "Este un singur fisier de biblioteca, fara nicio organizare interna pe categorii.",
                "Este mediul grafic de dezvoltare in care se scriu programele Java."
            ], "A",
            """
            Platforma Java este ansamblul claselor care exista in orice kit de instalare Java si
            care pot fi folosite de orice aplicatie ce ruleaza pe calculatorul unde au fost
            instalate. Mai este numita si mediul Java sau nucleul API.

            Clasele sunt grupate in colectii numite pachete, iar pachetele sunt organizate dupa
            rolul lor: pachete pentru retea, pentru grafica, pentru manipularea interfetei
            utilizator, pentru securitate si asa mai departe. Un alt nume pentru astfel de seturi de
            clase este cadru de lucru.
            """,
            """
            Cuvantul cheie este organizarea. Intrebarea nu este doar ce contine platforma, ci si cum
            este structurat acel continut.
            """);

        yield return Mc("j2-015", J2, "Avantajele limbajului Java", R2,
            """
            Principiul "scrie o data, ruleaza oriunde" este prezentat ca ideea centrala a platformei
            Java.

            Ce face acest principiu posibil?
            """,
            [
                "Compilarea in bytecode independent de platforma, executat de o masina virtuala disponibila pentru fiecare sistem de operare.",
                "Rescrierea automata a codului sursa de catre compilator pentru fiecare sistem de operare tinta.",
                "Existenta unui singur sistem de operare care poate rula programe Java.",
                "Distribuirea aplicatiei sub forma de cod sursa, compilat local la fiecare rulare."
            ], "A",
            """
            Odata scrisa, aplicatia ruleaza pe orice platforma care suporta Java, fara modificari.
            Acesta este avantajul fata de limbajele care trebuie rescrise, de cele mai multe ori
            complet, pentru a rula pe alt sistem de operare.

            Mecanismul este compilarea in bytecode independent de platforma si existenta unei masini
            virtuale pentru fiecare platforma. Nu se rescrie nimic si nu se recompileaza sursa la
            fiecare rulare.
            """,
            """
            Raspunsul este acelasi mecanism care apare si in intrebarile despre bytecode. Aici este
            privit din perspectiva portabilitatii.
            """);
    }
}
