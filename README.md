# IP_Bankomaten

## INLEDNING

Detta program ska hantera inloggning av användare mot en bankomat.
Användaren får tre försök på sig, misslyckas du stängs programmet av.
Lyckas du kommer du till menyn där du kan göra enkla kontohanteringar.

## KODSTRUKTUR

Programet laddar in förbestämda väreden till jagged arrays genom textfiler.

```c#
public static long[][] users;
public static string[][] accountName;
public static decimal[][] accountBalance;
```
Därefter  
Och dessa läses in genom metodanrop från
```C#
public static void InitializeUsersAndAccount()
```

Sedan fortsätter koden med metodanrop UserLoggIn(), samt kallar på SearchUser() som jämför användarens input.  
Om användaren finns så kallar den på metoden CheckPinCode(userIndex) i en if sats som sedan returnerar indexvärdet.
```C#
int userIndex = UserLoggIn();
```
```C#
SearchUser(long userName)

if (users[i][0] == userName)
    {
        return i;
    }
```
```C#
if (CheckPinCode(userIndex))
    {
        return userIndex;
    }
```
Därefter tas användaren vi lyckad inloggning till menyn genom metod UserLoggedIn(userIndex), eller så sätts bool till false och programmet stängs ner.
```C#
if (userIndex == -1)
    {
        stayRunning = false;
    }
else
    {
        Console.Clear();
        UserLoggedIn(userIndex);
    }
```
Menyn körs med en switch som ropar på den metod användaren vill nå
```C#
switch (menuChoice)
    {
        case 1:
            Accounts(userIndex);
            break;
        case 2:
            Transfer(userIndex);
            break;
        case 3:
            Withdrawal(userIndex);
            break;
        case 4:
            run = false;
            break;
    }
```
Accounts(int userIndex) hanterar att lista konton med en for-loop.
```C#
for (int i = 0; i < accountName[userIndex].Length; i++)
{
    Console.WriteLine($"Konto: {accountName[userIndex][i]}, Saldo: {accountBalance[userIndex][i]:C}");
}
```
Transfer(int userIndex) körs med ConsoleKey.Down/Up-arrow och enter som val.  
När använaren har valt så får han välja nästa konto som ska överföras till och man kan inte välja samma konto.  
När man valt konto ropas metoden TransferMoney(int userIndex, int one, int two).  
Där får användaren skriva in ett positivt belopp som inte får överskrida befintligt saldo.  
Sedan skrivs dom nya saldona över i arrayen och presenteras för användaren.  

Withdrawal(int userIndex) tar hand om uttaget användaren vill göra.  
Fungerar på samma sätt som Transfer(int userIndex) när man väljer konto och hur mycket pengar som ska hanteras.  
När användaren angivit ett giltligt belopp påkallas metoden CheckPinCode(int userIndex).  
Misslyckas stängs programmet ner annars får användaren ut sina pengar och återgår till menyn.

Sista alternativ returnerar false när användaren vill logga ut.  
Vilket stänger while-loopen för menyn och tar användaren till inloggningssidan.

## REFLEKTION

Detta är en reflektion på det jag har gjort innan jag tagit mig an extrautmaningarna.

Grundtanken var att bygga en strukturerad kod med simpelt flöde där fokus ligger på att kalla på metoder som hänvisning för att enklare kunna orientera sig.  
I koden har jag lagt simplare förklaringar, vilket jag tycker att jag har lyckats med.  
Då vi i våran uppgift inte fått använda oss av klasser eller objekt, använde jag mig av jagged arrays för att underlätta indexering av användarens uppgifter samt konton.  
Arrayerna hör samman genom indexering. Så användaren på index 0 i users har samhörighet med index 0 i accounts, samma för index 1 o.s.v. Men det har fungerat bra i detta syfte.  
Och att jag gick över från att läsa in users, konton och saldon från filer istället för att hårdkoda det i programmet.  
Vilket underlättar för framtida metoder som kan hantera funktioner som att spara varje session till fil, så kontons saldon som har förändrats sparas.  
Eller om använaren skapar nya konton och instättningar.
Felhanteringar har hanterats med hjälp av if-satser ihop med TryParse, även try catch vid inläsning av txt-filerna.

Men det hade varit betydligt bättre att få använda List<T>, då den är dynamisk och ett bättre alternativ om man skulle utöka programmet ännu mer.  
Eller koda objektorienterat med users & accounts som sina egna klasser.  
Samtidigt hade databashantering av konton och användare varit mycket lättare att hantera då man kan länka samman användare med konton genom relation. Samt att det hade varit mycket säkrare.  
Jag kunde ha lagt till bättre felhantering, speciellt där användarens saldo når 0. Vilket skapar en ändlös loop vid uttag eller överföringar.  
För övrigt kunde jag lagt till så användaren kan få möjligheten att stänga ner programmet och inte bara logga ut.
Eller att användaren kunde ha gjort instättningar. För det är samma princip som transfer- eller withdrawalmetoderna.

# Delmoment i projektet

Denna sektion håller koll på vad som ska göras och vad som är gjort

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
