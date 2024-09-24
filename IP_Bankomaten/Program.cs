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
                Console.WriteLine("Välkommen till Daniels Bank AB");
                Console.WriteLine("Ange personnr och din 5-siffriga pinkod!");
                Console.Write("Personnr: ");
                long userName = long.Parse(Console.ReadLine());

                int userIndex = SearchUser(userName);

                if (userIndex != -1)
                {
                    int tries = 3;
                    while (tries != 0)
                    {
                        Console.Write("pinkod: ");
                        int pinCode = int.Parse(Console.ReadLine());
                        bool checkedPinCode = CheckPinCode(userIndex, pinCode);
                        if (checkedPinCode)
                        {
                            Console.WriteLine("lyckad inloggning");

                        }
                        else
                        {
                            tries--;
                            Console.WriteLine($"Fel pinkod! Du har {tries} försök kvar.");
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Användaren kunde inte hittas. Försök igen.");
                }

                Console.ReadKey();
                Console.Clear();
            }
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
