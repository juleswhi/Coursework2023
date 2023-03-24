using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataValidation;

namespace ClaredonHighSchoolSkiTrip
{
    class AddDetails : ReadData
    {
        protected string path { get; set; }
        protected void AddToFile(string[] data)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < data.GetLength(0); i++) sw.Write($"{data[i]},");
                sw.WriteLine();
            }
        }


        private Random rand = new Random();
        private int getRandom() => rand.Next(100, 999);
        protected string createUsername(string fname, string sname) => $"{fname[0]}{sname}{getRandom()}";

        protected string input(string str)
        {
            Console.Clear();
            Console.WriteLine($"Please Enter Student's {str}:");
            return Console.ReadLine();
        }
    }



    class AddStudentDetails : AddDetails
    {


        public AddStudentDetails(string path) => this.path = path;


        public void addSlopeTime(string studentName)
        {

            // UGLY CODE
            Console.WriteLine("Would you like to see student usernames?");
            if(Console.ReadLine().ToLower().Contains('y'))
            {
                // Print out student details
            }


            string[,] studentData = readData("students.csv", 7);
            string username = "";
            string enteredUname;
            if (studentName == null) enteredUname = input("User Name");
            else enteredUname = studentName;




            for (int i = 0; i < studentData.GetLength(0); i++)
            {
                if (studentData[i, 0].ToLower() == enteredUname.ToLower()) username = studentData[i, 0];
            }
            if (username.ToLower() != enteredUname.ToLower()) { Console.WriteLine("You have entered an invalid username"); System.Threading.Thread.Sleep(1500); addSlopeTime(studentName); }
            int[] time = new int[5];
            for (int j = 0; j < 5; j++)
            {
                // use of (int) cast the data type to make sure that bit number of int is the same as the time array
                time[j] = Convert.ToInt32(input($"Time {j + 1}"));
            }
            int averageTime = 0;
            for (int a = 0; a < 5; a++) averageTime += time[a];
            averageTime = averageTime / 5;
            string[] finalArr = { username, $"{time[0]}", $"{time[1]}", $"{time[2]}", $"{time[3]}", $"{time[4]}", $"{averageTime}" };
            string Oldpath = this.path;
            this.path = "slopeTimes.csv";
            AddToFile(finalArr);
            this.path = Oldpath;
            Console.Clear();
            Console.WriteLine("Your Details Have Been Added");
            System.Threading.Thread.Sleep(1250);
            GoToMainMenu();
        }





        public void addStudent()
        {
            // Input Data
            string fname = input("First Name");
            string sname = input("Surname");
            string dob = input("Date of Birth D/M/Y");
            string year = input("School Year");
            string averagetime = "0";
            string SkillGroup = "C";


            // Create A Username using data and automatically set average ski slope time to 0
            string username = createUsername(fname, sname);
            string[] data = { username, fname, sname, dob, year, averagetime, SkillGroup };
            Console.Clear();
            AddToFile(data);
            Console.WriteLine($"Added Student, {username}");
            System.Threading.Thread.Sleep(750);
            Console.WriteLine("Press [S]");
            Console.WriteLine("Press Any Other Key To Return To Main Menu");
            Console.ReadKey();

            string[] detailMenuOptions = { "Add Slope Details", "Return To Main Menu" };
            var detailMenu = new Menu("User Options", detailMenuOptions);
            detailMenu.OpenMenu(detailMenuOptions);

            // TODO : ADD USER TO FILE SO CAN EASILY READ IN MENU METHOD


            // Add Slope Details
            addSlopeTime(username);

            // Main Menu
            GoToMainMenu();
        }
    }

}