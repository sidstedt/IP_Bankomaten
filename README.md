# IP_Bankomaten

INLEDNING

Detta program ska hantera inloggning av användare mot en bankomat.
Användaren får tre försök på sig, misslyckas du stängs programmet av.
Lyckas du kommer du till menyn där du kan göra enkla kontohanteringar.

# Delmoment i projektet

Denna sektion är till för att hålla koll på vad som ska göras och vad som är gjort.

🔒 **Start av programmet och inloggning**

- [ ]  När programmet startar ska användaren välkomnas till banken.
- [ ]  Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut) och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten.
- [ ]  Bankomaten ska ha 5 olika användare som ska kunna använda den. Det behöver inte gå att lägga till fler användare.
- [ ]  Om användaren skriver in fel pinkod tre gånger ska det inte gå att försöka logga in igen utan att starta om programmet.

🧭 **Navigera som användare**

- [ ]  När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:
    
    ```csharp
    1. Se dina konton och saldo
    2. Överföring mellan konton
    3. Ta ut pengar
    4. Logga ut
    ```
    
- [ ]  Användaren ska kunna välja en av funktionerna ovan genom att skriva in en siffra.
- [ ]  När en funktion har kört klart ska användaren få upp texten "Klicka enter för att komma till huvudmenyn". När användaren klickat enter kommer menyn upp igen.
- [ ]  Om användaren väljer "Logga ut" ska programmet inte stängas av. Användaren ska komma tillbaka till inloggningen igen.
- [ ]  Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer, ska systemet meddela att det är ett "ogiltigt val".
</aside>

<aside>
🔢 **Se konton och saldo**

- [ ]  Denna funktion ska köras när användaren navigerat in till alternativet "Se dina konton och saldo".
- [ ]  Användaren ska få en utskrift av de olika konton som användaren har och hur mycket pengar det finns på dessa.
- [ ]  Konton ska kunna ha både kronor och ören.
- [ ]  Alla användare ska ha olika antal konton och alla ska ha minst ett konto.
- [ ]  Varje konto ska ha ett namn, ex. "lönekonto" eller "sparkonto".
- [ ]  Saldon för alla konton sätts vid starten av programmet (du ställer in en en summa som finns på varje konto i koden) så om programmet startas om återställs alla saldon.
</aside>

<aside>
🔁 **Överföring mellan konton**

- [ ]  Denna funktion ska köras när användaren navigerat in till alternativet "Överföring mellan konton".
- [ ]  Användaren ska kunna välja ett konto att ta pengar från, ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa.
- [ ]  Denna summa ska sedan flyttas mellan dessa konton och efteråt ska användaren få se vilken summa som finns på de två konton som påverkades.
</aside>

<aside>
⏏️ **Ta ut pengar**

- [ ]  Denna funktion ska köras när användaren navigerat in till alternativet "Ta ut pengar".
- [ ]  Användaren ska kunna välja ett av sina konton samt en summa att ta ut.
- [ ]  Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar.
- [ ]  Lägg till ett felmeddelande om användaren försöker ta ut mer pengar än vad som finns på kontot.
- [ ]  Pengarna ska sedan tas bort från det konto som valdes.
- [ ]  Sist av allt ska systemet skriva ut det nya saldot på det kontot.
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
