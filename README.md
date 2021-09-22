# Refaktoriseringstest för CGI Åre/Östersund

## Beskrivning

Applikationen tar emot beställningar av liftkort och räknar ut ett pris baserat på ett antal parametrar.
Uträkningen av priset ska ta hänsyn till åkarens ålder och när beställningen görs. Åkare under 15 år och yngre eller 65 år och äldre ska få 15% rabatt. Åkare under 5 åker gratis. Beställningar som görs innan första november ska få 15% rabatt. Åkdagar utöver de 20 första är halva priset och om åkdagarna överskrider 30 antas liftkortet vara ett säsongskort och priset når där ett tak, ett liftkort blir alltså aldrig dyrare än 30 dagar.

## Uppgift

Den här uppgiften går ut på att refaktorisera koden i Provider-projektet, med störst fokus på SkiPassService-klassen och dess OrderSkiPass-metod.
Utgå från principer som SOLID, KISS, DRY och YAGNI, och skriv gärna minst ett enhetstest. Det har även smugit sig in ett par buggar.

Uppgiften bör inte ta längre tid än 2-3 timmar. Har du fler saker du vill ändra efter den tiden är det såklart tillåtet, men du kan också skriva ner dem och diskutera dem med oss när vi går igenom testet.

## Starthjälp

Koden är skriven i Visual Studio 2022 och target framework är .NET 6.
Enklast är att ladda ner Visual Studio 2022 Community Edition och öppna solution-filen där.
Det fungerar såklart också att ladda ner .NET 6 SDK:n och göra uppgiften i valfri IDE, tex VS Code.
WebAPI:et går att testa med det medbyggda Swagger GUI:t.
