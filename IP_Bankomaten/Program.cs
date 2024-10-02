using System.Net.Http.Headers;

namespace IP_Bankomaten
{
    internal class Program
    {
        // create the jagged array for users & accounts
        public static long[][] users;
        public static string[][][] accounts;
        static void Main(string[] args)
        {
            // call method to store users and accounts
            InitializeUsersAndAccount();
            // call method and store return value
            int userIndex = UserLoggIn();
            // if return value is not negative
            if (userIndex != -1)
            {
                // call method and pass index value
                UserLoggedIn(userIndex);
            }
        }
        public static void InitializeUsersAndAccount()
        {
            // initialize users
            users = new long[][]
            {
                new long[] { 9101010101 , 1234 },
                new long[] { 9202020202 , 2345 },
                new long[] { 9303030303 , 3456 },
                new long[] { 9404040404 , 4567 },
                new long[] { 9505050505 , 5678 }
            };
            // initialize accounts
            accounts = new string[][][]
            {
                new string[][] { new string[] { "Kortkonto", "1000" }, new string[] { "Sparkonto", "500" } },
                new string[][] { new string[] { "Kortkonto", "2000" }, new string[] { "Sparkonto", "1000" } },
                new string[][] { new string[] { "Kortkonto", "3000" }, new string[] { "Sparkonto", "1500" } },
                new string[][] { new string[] { "Kortkonto", "4000" }, new string[] { "Sparkonto", "2000" } },
                new string[][] { new string[] { "Kortkonto", "5000" }, new string[] { "Sparkonto", "2500" } }
            };
        }

        public static int UserLoggIn()
        {
            bool run = true;
            // keep running until users choose to exit
            while (run)
            {
                Console.WriteLine("Välkommen till Daniels Bank AB");
                Console.WriteLine("Ange personnr och din 5-siffriga pinkod!");
                Console.Write("Personnr: ");
                // declare and try the user input else write out to try again
                if (!long.TryParse(Console.ReadLine(), out long userName))
                {
                    Console.WriteLine("Ogiltligt personnummer, försök igen.");
                    continue;
                }
                // call method with user input and save return value
                int userIndex = SearchUser(userName);
                // if return value does not return negative
                // else user input wrong personal number
                if (userIndex != -1)
                {
                    // how many tries user have to input correct pin code
                    int tries = 3;
                    // the parameter is oboslete as the code block returns
                    // a value either way
                    while (tries != 0)
                    {
                        Console.Write("pinkod: ");
                        // if the user does not input correct value i.e. "abc" or "/&¤"
                        if (!int.TryParse(Console.ReadLine(), out int pinCode))
                        {
                            Console.Clear();
                            Console.WriteLine("ogiltligt värde, försök igen");
                            Console.WriteLine($"Du har {tries} försök kvar.");
                            continue;
                        }
                        // call method and pass along values and save return bool value
                        bool checkedPinCode = CheckPinCode(userIndex, pinCode);
                        // if personal number & pin code match return index value
                        if (checkedPinCode)
                        {
                            Console.WriteLine("lyckad inloggning");
                            return userIndex;
                        }
                        // if user input correct pin code negate tries with 1
                        // and write out how many attempts left
                        else
                        {
                            Console.Clear();
                            tries--;
                            Console.WriteLine($"Fel pinkod! Du har {tries} försök kvar.");
                        }
                        // if no tries are left return -1
                        if (tries == 0)
                        {
                            return -1;
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
                Console.Clear();
            }
        }
        public static void Accounts(int userIndex)
        {
            Console.WriteLine($"Konton för användare {users[userIndex][0]}:");
            for (int i = 0; i < accounts[userIndex].Length; i++)
            {
                Console.WriteLine($"Konto: {accounts[userIndex][i][0]}, Saldo: {accounts[userIndex][i][1]}");
            }
        }
        public static void Withdrawal(int userIndex)
        {

        }
        public static void Transfer(int userIndex)
        {

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
