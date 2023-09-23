using System;
using System.Threading;
using Utils;

namespace ClaredonHighSchoolSkiTrip
{

    class Login : ReadData
    {

        private string staffPath = "Staff.csv";

        public void LoginLoop()
        {
            Login:
            if (logIntoAccount()) GoToMainMenu();
            else goto Login;
        }




        private string?[] getDetails()
        {

            /*

                uname and pword have ? to indicate nullability, as ReadLine can be null

            */

            // Ask And Store Username
            Console.WriteLine("Please Enter Your Username");
            Console.Write("> ");
            bool validReturn = true;
            string? uname = Console.ReadLine();
            uname.ValidateString(() =>
            {
                IncorrectDetails();
                validReturn = false;
            });
            if (!validReturn) return null;



            // Ask And Store Password
            Console.WriteLine("Please Enter Your Password");
            Console.Write("> ");
            string? pword = Console.ReadLine();
            pword.ValidateString(() =>
            {
                IncorrectDetails();
                validReturn = false;
            });

            string?[] details = { uname, pword };
            return details;

        }




        public bool logIntoAccount()
        {
            // Read In Staff File
            string[,] data = readData(staffPath, 4);

            string?[] enteredDetails = getDetails();

            if (enteredDetails == null) return false;


            bool breakLoop = false;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (enteredDetails[0] == data[i, 0])
                {
                    if (enteredDetails[1] == data[i, 1])
                    {
                        breakLoop = true;
                    }
                }
            }


            if (!breakLoop) { IncorrectDetails(); return false; }

            Console.WriteLine("Logging In.");
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

            Console.Clear();
        }

    }
}