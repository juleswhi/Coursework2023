using System;


namespace ClaredonHighSchoolSkiTrip
{
    class Program : ReadData
    {
        static void Main(string[] args)
        {


            Banner();

            var Login = new Login();


            // Repeat Until Logged In
            Login.LoginLoop();

        }



        private static void Banner()
        {
            Console.Clear();

            Console.WriteLine(@" _____ _                          _               _____ _    _   _____    _       ");
            Console.WriteLine(@"/  __ \ |                        | |             /  ___| |  (_) |_   _|  (_)      ");
            Console.WriteLine(@"| /  \/ | __ _ _ __ ___ _ __   __| | ___  _ __   \ `--.| | ___    | |_ __ _ _ __  ");
            Console.WriteLine(@"| |   | |/ _` | '__/ _ \ '_ \ / _` |/ _ \| '_ \   `--. \ |/ / |   | | '__| | '_ \ ");
            Console.WriteLine(@"| \__/\ | (_| | | |  __/ | | | (_| | (_) | | | | /\__/ /   <| |   | | |  | | |_) |");
            Console.WriteLine(@" \____/_|\__,_|_|  \___|_| |_|\__,_|\___/|_| |_| \____/|_|\_\_|   \_/_|  |_| .__/ ");
            Console.WriteLine(@"                                                                           | |    ");
            Console.WriteLine(@"                                                                           |_|    ");

            System.Threading.Thread.Sleep(1500);
        }
    }
}