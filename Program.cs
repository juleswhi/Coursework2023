using System;
using System.IO;
using Utils;

namespace ClaredonHighSchoolSkiTrip
{
    class Program : ReadData
    {
        static void Main(string[] args)
        {

            /*

                DEFAULT USERNAME: root
                DEFAULT PASSWORD: root

            */

            Banner();

            var Login = new Login();


        // Repeat Until Logged In
        Login:
            if (Login.logIntoAccount()) GoToMainMenu();
            else goto Login;

        }



        private static void Banner()
        {
            Console.Clear();

            Console.WriteLine("////////////////////////");
            Console.WriteLine("// CLARENDON SKI TRIP //");
            Console.WriteLine("////////////////////////");

            System.Threading.Thread.Sleep(1000);
        }
    }
}