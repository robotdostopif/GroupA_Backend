# Sprint Reviews

## 2020-05-29

### SKRAC-an Sprint 9

* Sekreterare: **Fredrika**

* **Vad var målet för sprinten?** 
  Målet för sprinten var att implementera HATEOAS samt lägga till API Requests för alla controllers (PUT, POST, DELETE). Ett annat delmål var att lägga till fler tester. 

* **Uppfylldes målet för sprinten?** 

  :white_check_mark: Ja

- **Blev alla issues klara?**

  Nej, vi har ett issue kvar med två stycken subtasks [SKRAC-204]. 
  Detta var ett issue som vi la till ganska sent under sprintens gång. 

- **Om inte, varför**
  På slutet fokuserade vi mer på tester och att snygga upp koden och göra så att våra CRUD-metoder följer samma struktur för returer .

- *Icke klara issues återförs till backlog, efter att de har uppdaterats. Har vissa
  delar klarats av? Skall vi ha en ny tidsuppskattning? Vad behövs för att vi
  skall klara detta issue nästa gång?*

- **Höll tidsplaneringen för alla issues?**

  Nej, ibland stötte vi på problem som vi inte hade räknat med. Ibland kunde man spinna iväg på annat också. Ibland när man satt och sökte på problem/lösningar så kunde de ta längre tid än vi förutspått.

  

- Bedöm vad ni kan göra bättre i nästa sprint**

  Göra pullrequesten snabbare. Det låg en del pullrequests och väntade. 
  Det uppstod mergeconflicts som *kanske* hade kunnat undvikas om man var snabbare på att mergea/reviewa pullrequests. 


  **Vad vi gjorde bra i denna sprinten:** Vi upplever att vi hade bra issues, de var välplanerade. I förra sprinten hade vi väldigt små issues som inte kunde utföras utan ett annat issue så man kunde inte testa sin kod, alltså fick vi sammanföra flera issues till ett. Alla visste vad de skulle göra hela tiden, fördelningen av issues fungerade bra.

  

- **Har det kommit upp nya saker som skall läggas till på er backlog?**
  Ja vi har lagt till issues i backlogen ett flertal gånger. Vi la exempelvis till att vi skulle ha dynamic includes. 
  Vi har funderat och kikat lite på paging men inte gjort slag i saken och lagt till ett issue för det (och alltså heller inte implementerat det ännu). 

  **Vad vi vill lägga till i backlogen men inte hunnit:** Vi vill ändra om det generiska repot och ändra de olika metoderna. Detta för att slippa referera till det generiska interfacet i de andra repositorie-interfaces.

  

## 2020-05-21

### SKRAC-an Sprint 8

* Sekreterare: **Fredrika**

* **Vad var målet för sprinten?** 
  Implementera getbyid metoder för controllerklasserna. 
  Fixa automapper (model -> DTO) för controllermetoderna. 

* **Uppfylldes målet för sprinten?** 

  :white_check_mark: Ja

- **Blev alla issues klara?**

  Nej, vi har ett issue kvar SKRAK-115 som rör hateoas. 
  Denna går över till nästa sprint istället.

- **Om inte, varför**
  Det blev strul i veckoschemat pga kristihimmelfärd, aka tidsbrist. 

- *Icke klara issues återförs till backlog, efter att de har uppdaterats. Har vissa
  delar klarats av? Skall vi ha en ny tidsuppskattning? Vad behövs för att vi
  skall klara detta issue nästa gång?*

- **Höll tidsplaneringen för alla issues?**

  ​	:white_check_mark: Ja

  Tidsplaneringen höll, vissa issues gick snabbare än vad vi förutspått.

- **Bedöm vad ni kan göra bättre i nästa sprint**
  Vi märkte att vi ville ha lite större issues, vi hade de nu på metodnivå. 
  Det blev strul med vissa issues då man behövde den andra klar för att det skulle gå att testa/fungera. 
  Det fanns för lite i backlogen. Vi skapade issues i backlogen för att kunna skapa en ny sprint. Vi kan/bör bli bättre på att fylla upp backlogen. Vi skulle kunna lägga in fler xunit-tester i backlogen till nästa gång.

- **Har det kommit upp nya saker som skall läggas till på er backlog?**
  Vi har inte lagt till något i backlogen. 

## 2020-05-15

### SKRAC-an Sprint 7

Sekreterare: André

- Vad var målet för sprinten?
  - Alla crud metoder klara i både controllers och repository * DbContext ska seeda data med hjälp av ModelBuilder och HasData() Påbörja tester med Xunit för GetAll()  ... fler tester i mån av tid, men viktigt är att få igång testprojekt och lära sig
    
* Uppfylldes målet för sprinten?
  *  :white_check_mark: Ja

- Blev alla issues klara?
  - :white_check_mark: Ja
  - La även flera issues
- Höll tidsplanering för era issues.
  
  - :white_check_mark: Ja
- Bedöm vad ni kan göra bättre i nästa sprint
  
  - Schemalägg frivilligt gemensamt arbete med startpunkter.
- Har det kommit upp nya saker som skall läggas till på er backlog?
  - Säkerställ Implementering av Iloggers i alla repos.
  
  - Logga relevant information i alla repo metoder
  
  - Imapper ska implementeras i alla controllers
  
  - Göra likadana tester i test projektet för alla IEntitys.
  
  - Ha en test fil för varje typ, ex DirectorTest.cs
  
    

## 2020-05-08

### SKRAC-an Sprint 5

Sekreterare: Pierre

* Vad var målet för sprinten?
  * Målet var att ha ett fungerande API till den mån att kunna hämta alla Genrer ifrån API:et
* Uppfylldes målet för sprinten?
  *  :white_check_mark: Ja

- Blev alla issues klara?
  - :white_check_mark: Alla issues blev färdiga
- Höll tidsplanering för era issues.
  - Vi tycker att den höll bra
- Bedöm vad ni kan göra bättre i nästa sprint
  - Till hög grad rapporterade vi tiderna på issues men det var lite slarv från somliga
  - Till nästa sprint ser vi till att **alltid** rapportera in tidsåtgången på en issue
- Har det kommit upp nya saker som skall läggas till på er backlog?
  - Framöver behöver vi issues för att rensa ut CRUD metoder i Alla repositories, detta blir aktuellt efter vi skapat RepositoryCRUD
  - En issue kan vara DbContext bör innehålla HasData()
  - Lägg till nödvändiga paket för Xunit till projektet. Skapa en mapp UnitTests för att hålla tester
  - Tester bör läggas till som nya issues.
    - GenreController GetAll bör testas output med innehåll
      - Förväntas ge ut JSON med innehåll
    - GenreController GetAll bör testas output utan innehåll
      - Förväntas ge NoContext() resultat 



## Sprint Reviews Mall

* Sekreterare: 
* Vad var målet för sprinten?
* Uppfylldes målet för sprinten?

- Blev alla issues klara?

- Om inte, varför
- Icke klara issues återförs till backlog, efter att de har uppdaterats. Har vissa
  delar klarats av? Skall vi ha en ny tidsuppskattning? Vad behövs för att vi
  skall klara detta issue nästa gång?
- Höll tidsplaneringen för alla issues.
- Bedöm vad ni kan göra bättre i nästa sprint
- Har det kommit upp nya saker som skall läggas till på er backlog?
