﻿using System.Net.Http.Headers;

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
                new string[][] { new string[] { "Kortkonto", "1000.50" }, new string[] { "Sparkonto", "500.66" } },
                new string[][] { new string[] { "Kortkonto", "2000.34" }, new string[] { "Sparkonto", "1000.56" } },
                new string[][] { new string[] { "Kortkonto", "3000.23" }, new string[] { "Sparkonto", "1500.56" } },
                new string[][] { new string[] { "Kortkonto", "4000.77" }, new string[] { "Sparkonto", "2000.32" } },
                new string[][] { new string[] { "Kortkonto", "5000.53" }, new string[] { "Sparkonto", "2500.12" } }
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
                            // write out as long as the user have tries left
                            if (tries > 0)
                                Console.WriteLine($"Fel pinkod! Du har {tries} försök kvar.");
                        }
                        // if no tries are left close down
                        if (tries == 0)
                        {
                            Console.WriteLine("Du har angett fel pinkod för många gånger!" +
                                "\nTryck på valfri tanget för att stänga av.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                }
                // if user could not be found
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
                Console.Clear();
            }
        }
        public static void Accounts(int userIndex)
        {
            Console.Clear();
            Console.WriteLine($"Konton för användare {users[userIndex][0]}:");
            // Loop through and write out all associated accounts from user
            for (int i = 0; i < accounts[userIndex].Length; i++)
            {
                Console.WriteLine($"Konto: {accounts[userIndex][i][0]}, Saldo: {double.Parse(accounts[userIndex][i][1]).ToString("F2")}");
            }
            Console.WriteLine("\nTryck på enter för att återgå till menyn!");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
        public static void Withdrawal(int userIndex)
        {
            bool select = true;
            // give first "index value" to selectedAccount
            int selectedAccount = 0;
            while (select)
            {
                Console.Clear();
                Console.WriteLine($"Välj konto för uttag");
                // loop and write out the accounts
                for (int i = 0; i < accounts[userIndex].Length; i++)
                {
                    // write out the selected account marked with color
                    if (i == selectedAccount)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    // and reset the color for the accounts not selected
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine($"Konto {i + 1}: {accounts[userIndex][i][0]}, Saldo: {double.Parse(accounts[userIndex][i][1]).ToString("F2")}");
                }
                Console.ResetColor();
                // store inputkey from user
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        // as long as the value is bigger than 0, decrease
                        if (selectedAccount > 0)
                            selectedAccount--;
                        break;
                    case ConsoleKey.DownArrow:
                        // as long as the value is less than total value - 1, increase
                        if (selectedAccount < accounts[userIndex].Length - 1)
                            selectedAccount++;
                        break;
                    // if user press enter exit loop
                    case ConsoleKey.Enter:
                        select = false;
                        break;
                }
            }
            if (selectedAccount != -1)
            {
                bool run = true;
                while (run)
                {
                    Console.Clear();
                    Console.WriteLine($"Du har valt {accounts[userIndex][selectedAccount][0]} " +
                        $"med saldot: {double.Parse(accounts[userIndex][selectedAccount][1]).ToString("F2")}");
                    Console.Write("Ange belopp att ta ut: ");
                    // if user input is correct
                    if (double.TryParse(Console.ReadLine(), out double amountToWithdraw))
                    {
                        // parse the value from account to int and store to variable
                        double currentBalance = double.Parse(accounts[userIndex][selectedAccount][1]);
                        // if the amount to withdraw is less or equal to balance
                        if (amountToWithdraw <= currentBalance)
                        {
                            // negate the current balance with the amount to withdraw
                            currentBalance -= amountToWithdraw;
                            // convert to string and save amount left to account
                            accounts[userIndex][selectedAccount][1] = currentBalance.ToString();
                            Console.WriteLine($"Uttag lyckades! " +
                                $"\nUttaget belopp: {amountToWithdraw}." +
                                $"\nBefintligt saldo: {double.Parse(accounts[userIndex][selectedAccount][1]).ToString("F2")}.");
                            Console.WriteLine("\nTryck på enter för att återgå till menyn.");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                            { }
                            run = false;
                        }
                        // if the amount is bigger than the balance shut down
                        else
                        {
                            Console.WriteLine("\nOtillräckligt saldo! Tryck på enter för att försöka igen.");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                            { }
                        }
                    }
                    // if user inputed incorrect value
                    else
                    {
                        Console.WriteLine("Ogiltligt belopp.");
                        Console.WriteLine("Tryck på enter för att försöka igen.");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        { }
                    }
                }
            }
            // if no account was selected
            else
            {
                Console.WriteLine("inget konto valt. Tryck på enter för att återgå till menyn");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                }
            }
        }
        public static void Transfer(int userIndex)
        {
            bool select = true;
            // give first "index value" to selectedAccount
            int selectedAccount = 0;
            // set variable of account index to negative value
            int choice1 = -1;
            int choice2 = -1;
            while (select)
            {
                Console.Clear();
                Console.WriteLine($"Välj konto för uttag");
                // loop and write out the accounts
                for (int i = 0; i < accounts[userIndex].Length; i++)
                {
                    // write out the selected account marked with color
                    if (i == selectedAccount)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    // and reset the color for the accounts not selected
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine($"Konto {i + 1}: {accounts[userIndex][i][0]}, Saldo: {double.Parse(accounts[userIndex][i][1]).ToString("F2")}");
                }
                Console.ResetColor();
                // store inputkey from user
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        // as long as the value is bigger than 0, decrease
                        if (selectedAccount > 0)
                            selectedAccount--;
                        break;
                    case ConsoleKey.DownArrow:
                        // as long as the value is less than total value - 1, increase
                        if (selectedAccount < accounts[userIndex].Length - 1)
                            selectedAccount++;
                        break;
                    // if user press enter
                    case ConsoleKey.Enter:
                        // if the first has no index value
                        if (choice1 == -1)
                        {
                            // set choice1 to selected account index value
                            choice1 = selectedAccount;
                        }
                        // if the second has no index value
                        else if (choice2 == -1)
                        {
                            // set choice2 to selected account index value
                            choice2 = selectedAccount;
                        }
                        Console.WriteLine($"Du har valt {accounts[userIndex][selectedAccount][0]} med saldot: {double.Parse(accounts[userIndex][selectedAccount][1]).ToString("F2")}");
                        Console.WriteLine("Tryck på Enter för att fortsätta.");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {
                        }
                        // if both have given a value
                        if (choice1 != -1 && choice2 != -1)
                        {
                            select = false;
                            TransferMoney(userIndex, choice1, choice2);
                        }
                        break;
                }
            }
        }
        public static void TransferMoney(int index, int one, int two)
        {
            Console.Clear();
            bool run = true;
            while (run)
            {
                // Save current balance to int variable
                double BalanceOne = double.Parse(accounts[index][one][1]);
                double BalanceTwo = double.Parse(accounts[index][two][1]);
                Console.Write($"Hur mycket vill du föra över från {accounts[index][one][0]} med saldot: {double.Parse(accounts[index][one][1]).ToString("F2")} till " +
                    $"{accounts[index][two][0]} med saldot: {double.Parse(accounts[index][two][1]).ToString("F2")}?" +
                    $"\nAnge belopp: ");
                // check user input
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    // If amount is no more than current value
                    if (amount <= double.Parse(accounts[index][one][1]))
                    {
                        // subtract and add new value
                        BalanceOne -= amount;
                        BalanceTwo += amount;
                        // overwrite to new value
                        accounts[index][one][1] = BalanceOne.ToString();
                        accounts[index][two][1] = BalanceTwo.ToString();
                        Console.WriteLine($"Överföring gjord. Nuvarande saldo" +
                            $"\n{accounts[index][one][0]} med saldot: {double.Parse(accounts[index][one][1]).ToString("F2")}" +
                            $"\n{accounts[index][two][0]} med saldot: {double.Parse(accounts[index][two][1]).ToString("F2")}");
                        Console.WriteLine("\nTryck på enter för att återgå till menyn");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {
                        }
                        run = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Angivet belopp är mer än vad som är tillgängligt. Försök igen!");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltligt val! Försök igen");
                }
            }
        }
        public static int SearchUser(long userName)
        {
            // iteriate through all users
            for (int i = 0; i < users.Length; i++)
            {
                // if user in the array is equal to input return index value
                if (users[i][0] == userName)
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool CheckPinCode(int userIndex, int pinCode)
        {
            // iteriate through the amount of total index length
            for (int i = 0; i < users.Length; i++)
            {
                // if user index with associated pin code is same as input
                // return bool = true
                if (users[userIndex][1] == pinCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
