namespace IP_Bankomaten
{
    internal class Program
    {
        static string[][] users;
        static string[][] accounts;
        static void Main(string[] args)
        {
            InitializeUsersAndAccount();

            Console.WriteLine("Välkommen till Daniels Bank AB");
            Console.WriteLine($"{users[0][0]}");
            Console.WriteLine($"{accounts[0][1]}: {accounts[0][2]}");
            Console.ReadKey();
        }
        public static void InitializeUsersAndAccount()
        {
            users = [
        [ "910101-0101" , "12345"],
                [ "920202-0202" , "12345"],
                [ "930303-0303" , "12345"],
                [ "940404-0404" , "12345"],
                [ "950505-0505" , "12345"]
        ];
            accounts = [
                [users[0][0], "Kortkonto" , "1000"],
                [users[0][0], "Sparkonto" , "500"],
                [users[1][0], "Kortkonto" , "2000"],
                [users[1][0], "Sparkonto" , "1000"],
                [users[2][0], "Kortkonto" , "3000"],
                [users[2][0], "Sparkonto" , "1500"],
                [users[3][0], "Kortkonto" , "4000"],
                [users[3][0], "Sparkonto" , "2000"],
                [users[4][0], "Kortkonto" , "5000"],
                [users[4][0], "Sparkonto" , "2500"],
                ];
        }
    }
}
