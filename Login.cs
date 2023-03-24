using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Utils;
using System.Threading;

namespace ClaredonHighSchoolSkiTrip
{

    class Login : ReadData
    {
        
        private string staffPath = "Staff.csv";

        private string?[] getDetails()
        {

            /*

                uname and pword have ? to indicate nullability, as ReadLine can be null

            */

            // Ask And Store Username
            Console.Clear();
            Console.WriteLine("Please Enter Your Username");
            Console.Write("> ");
            string? uname = Console.ReadLine();

            // Ask And Store Password
            Console.WriteLine("Please Enter Your Password");
            Console.Write("> ");
            string? pword = Console.ReadLine();

            string?[] details = { uname, pword };
            return details;

        }


        public bool logIntoAccount()
        {
            // Read In Staff File
            string[,] data = readData(staffPath, 4);

            string?[] enteredDetails = getDetails();

            bool breakLoop = false;

            /*

                Int.Loop is a extension method

                makes looping much quicker

                using ForLoop;

            */

            int i = -1;
            data.GetLength(0).Loop(() =>
            {
                i++;
                data.GetLength(1).Loop(() =>
                 {

                     if (enteredDetails[0] == data[i, 0])
                     {
                         if (enteredDetails[1] == data[i, 1])
                         {
                             breakLoop = true;
                         }
                     }
                 });
            });

            if (!breakLoop) { IncorrectDetails(); return false; }

            Console.WriteLine("Loggin In");
            Thread.Sleep(250);

            // Main Menu
            return true;

        }

        private void IncorrectDetails()
        {

            Console.Clear();

            Console.WriteLine("Sorry, But You Have Entered Incorrect Details");

            System.Threading.Thread.Sleep(750);

            Console.WriteLine("Press Any Key To Try Again");

            Console.ReadKey();

        }

    }
}