# IP_Bankomaten

INLEDNING

Detta program ska hantera inloggning av användare mot en bankomat.
Användaren får tre försök på sig, misslyckas du stängs programmet av.
Lyckas du kommer du till menyn där du kan göra enkla kontohanteringar.

# Reflektion

REFLEKTION

Detta är en reflektion på det jag har gjort innan jag tagit mig an extrautmaningarna.

Grundtanken var att bygga en strukturerad simpelt flöde av kod med metoder som hänvisning för att enklare kunna orientera sig med enklare kommentarer till, vilket jag tycker att jag lyckats med.
Då vi i våran uppgift inte fått använda oss av klasser eller objekt, använde jag mig av jagged arrays för att underlätta indexering av användarens uppgifter samt konton.
Arrayerna hör samman genom indexering. Så användaren på index 0 i users har samhörighet med index 0 i accounts, samma för index 1 o.s.v.
Men det hade varit betydligt bättre att få använda List<T>, då den är dynamisk och ett bättre alternativ om man skulle utöka programmet ännu mer.
Eller OOP med users & accounts där man lägger in dom som sina egna klasser.
Samtidigt hade databashantering av konton och användare varit mycket lättare att hantera då man kan länka samman användare med konton genom relation. Samt att det hade varit mycket säkrare.
Felhanteringar har hanterats med hjälp av if-satser ihop med TryParse.
Förbättringar skulle behövas implementeras där hantering av uttag eller överföringar från konton där saldot är 0.



# Delmoment i projektet

Denna sektion är till för att hålla koll på vad som ska göras och vad som är gjort.

🔒 **Start av programmet och inloggning**

- [x]  När programmet startar ska användaren välkomnas till banken.
- [x]  Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut) och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten.
- [x]  Bankomaten ska ha 5 olika användare som ska kunna använda den. Det behöver inte gå att lägga till fler användare.
- [x]  Om användaren skriver in fel pinkod tre gånger ska det inte gå att försöka logga in igen utan att starta om programmet.

🧭 **Navigera som användare**

- [x]  När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:
    
    ```csharp
    1. Se dina konton och saldo
    2. Överföring mellan konton
    3. Ta ut pengar
    4. Logga ut
    ```
    
- [x]  Användaren ska kunna välja en av funktionerna ovan genom att skriva in en siffra.
- [x]  När en funktion har kört klart ska användaren få upp texten "Klicka enter för att komma till huvudmenyn". När användaren klickat enter kommer menyn upp igen.
- [x]  Om användaren väljer "Logga ut" ska programmet inte stängas av. Användaren ska komma tillbaka till inloggningen igen.
- [x]  Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer, ska systemet meddela att det är ett "ogiltigt val".
</aside>

<aside>
🔢 **Se konton och saldo**

- [x]  Denna funktion ska köras när användaren navigerat in till alternativet "Se dina konton och saldo".
- [x]  Användaren ska få en utskrift av de olika konton som användaren har och hur mycket pengar det finns på dessa.
- [x]  Konton ska kunna ha både kronor och ören.
- [x]  Alla användare ska ha olika antal konton och alla ska ha minst ett konto.
- [x]  Varje konto ska ha ett namn, ex. "lönekonto" eller "sparkonto".
- [x]  Saldon för alla konton sätts vid starten av programmet (du ställer in en en summa som finns på varje konto i koden) så om programmet startas om återställs alla saldon.
</aside>

<aside>
🔁 **Överföring mellan konton**

- [x]  Denna funktion ska köras när användaren navigerat in till alternativet "Överföring mellan konton".
- [x]  Användaren ska kunna välja ett konto att ta pengar från, ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa.
- [x]  Denna summa ska sedan flyttas mellan dessa konton och efteråt ska användaren få se vilken summa som finns på de två konton som påverkades.
</aside>

<aside>
⏏️ **Ta ut pengar**

- [x]  Denna funktion ska köras när användaren navigerat in till alternativet "Ta ut pengar".
- [x]  Användaren ska kunna välja ett av sina konton samt en summa att ta ut.
- [x]  Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar.
- [x]  Lägg till ett felmeddelande om användaren försöker ta ut mer pengar än vad som finns på kontot.
- [x]  Pengarna ska sedan tas bort från det konto som valdes.
- [x]  Sist av allt ska systemet skriva ut det nya saldot på det kontot.
</aside>

<aside>
💡 **Extrautmaningar**

*Om du känner att du hinner och vill göra mer kommer här förslag på ytterligare funktionalitet du kan bygga in i systemet. Dessa utmaningar är helt frivilliga och inget krav!*

- [ ]  Lägg till funktionalitet så att användaren kan öppna nya konton.
- [ ]  Lägg till så att användaren kan sätta in pengar.
- [ ]  Gör så att olika konton har olika valuta, inklusive att valuta omvandlas när pengar flyttas mellan dem.
- [ ]  Lägg till så att användaren kan göra överföringar till andra användare.
- [ ]  Lägg till så att om användaren skriver fel pinkod tre gånger stängs inloggning för den användaren av i tre minuter istället för att programmet måste startas om.
- [ ]  Lägg till så att saldon för alla konton för alla användare sparas mellan körningarna av programmet så att saldon inte återställs.
</aside>
