# Refaktoriseringstest för CGI Åre/Östersund

## Uppgift

Den här uppgiften går ut på att refaktorisera koden i Provider-projektet, med störst fokus på SkiPassService-klassen och dess OrderSkiPass-metod.
Utgå från principer som SOLID, KISS, DRY och YAGNI, och skriv gärna minst ett enhetstest.

Uppgiften bör inte ta längre tid än 2-3 timmar. Har du fler saker du vill ändra efter den tiden är såklart tillåtet, men du kan också skriva ner dem och diskutera dem med oss när vi går igenom testet.

Ingen kod i Consumer-projektet får ändras, anta att Provider-projektet ingår ett större ekosystem och därför måste vara bakåtkompatibelt.
All kod i Provider-projektet får ändras.

## Starthjälp

Koden är skriven i Visual Studio 2022 och target framework är .NET 6.
Enklast är att ladda ner Visual Studio 2022 Community Edition och öppna solution-filen där.
Det fungerar såklart också att ladda ner .NET 6 SDK:n och göra uppgiften i valfri IDE, tex VS Code.
Exempel på argument att starta med: "Test" "Test" "1985-01-01" "2021-11-11" "2022-01-20"
