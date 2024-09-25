using System.Net.Http.Headers;

namespace IP_Bankomaten
{
    internal class Program
    {
        public static long[][] users;
        public static string[][] accounts;
        static void Main(string[] args)
        {
            InitializeUsersAndAccount();
            bool run = true;
            while (run)
            {
                int userIndex = UserLoggIn();
                if (userIndex != -1)
                {
                    UserLoggedIn(userIndex);
                }
                else
                {
                    run = false;
                }
            }
        }

        public static int UserLoggIn()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Välkommen till Daniels Bank AB");
                Console.WriteLine("Ange personnr och din 5-siffriga pinkod!");
                Console.Write("Personnr: ");

                if (!long.TryParse(Console.ReadLine(), out long userName))
                {
                    Console.WriteLine("Ogiltligt personnummer, försök igen.");
                    continue;
                }
                int userIndex = SearchUser(userName);

                if (userIndex != -1)
                {
                    int tries = 3;
                    while (tries != 0)
                    {
                        Console.Write("pinkod: ");
                        if (!int.TryParse(Console.ReadLine(), out int pinCode))
                        {
                            Console.WriteLine("ogiltligt värde, försök igen");
                            continue;
                        }
                        bool checkedPinCode = CheckPinCode(userIndex, pinCode);
                        if (checkedPinCode)
                        {
                            Console.WriteLine("lyckad inloggning");
                            return userIndex;
                        }
                        else
                        {
                            tries--;
                            Console.WriteLine($"Fel pinkod! Du har {tries} försök kvar.");
                        }
                    }
                    return -1;
                }
                else
                {
                    Console.WriteLine("Användaren kunde inte hittas. Försök igen.");
                }

                Console.ReadKey();
                Console.Clear();
            }
            return -1;
        }

        public static void UserLoggedIn(int userIndex)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Du får nu fyra val att välja på!" +
                    "\n1. Se dina konton och saldo" +
                    "\n2. Överföring mellan konton" +
                    "\n3. Ta ut pengar" +
                    "\n4. Logga ut");
                if (!int.TryParse(Console.ReadLine(), out int menuChoice))
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltligt val!\n");
                    continue;
                }
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
                Console.ReadKey();
            }
        }
        public static void Accounts(int userIndex)
        {
            foreach (var account in accounts)
            {
                if (account[0] == users[userIndex][0].ToString())
                {
                    Console.WriteLine($"{account[1]}: {account[2]}");
                }
            }
            Console.WriteLine("Tryck på enter för att återgå");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            Console.Clear();
        }
        public static void Transfer(int userIndex)
        {
            Console.WriteLine("Överföring. Välj konto.");
            foreach (var account in accounts)
            {
                if (account[0] == users[userIndex].ToString())
                {

                }
            }
        }
        public static void Withdrawal(int userIndex)
        {

        }
        public static void InitializeUsersAndAccount()
        {
            users = [
                [ 9101010101 , 1234],
                [ 9202020202 , 2345],
                [ 9303030303 , 3456],
                [ 9404040404 , 4567],
                [ 9505050505 , 5678]
        ];
            accounts = [
                [users[0][0].ToString() , "Kortkonto" , "1000"],
                [users[0][0].ToString() , "Sparkonto" , "500"],
                [users[1][0].ToString() , "Kortkonto" , "2000"],
                [users[1][0].ToString() , "Sparkonto" , "1000"],
                [users[2][0].ToString() , "Kortkonto" , "3000"],
                [users[2][0].ToString() , "Sparkonto" , "1500"],
                [users[3][0].ToString() , "Kortkonto" , "4000"],
                [users[3][0].ToString() , "Sparkonto" , "2000"],
                [users[4][0].ToString() , "Kortkonto" , "5000"],
                [users[4][0].ToString() , "Sparkonto" , "2500"],
                ];
        }
        public static int SearchUser(long userName)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i][0] == userName)
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool CheckPinCode(int userIndex, int pinCode)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[userIndex][1] == pinCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
