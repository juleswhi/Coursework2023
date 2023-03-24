using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Utils;

namespace ClaredonHighSchoolSkiTrip
{
    class Menu : CalculateMenu
    {

        // This class is responsible for management of Menu System
        protected string menuname { get; set; }
        protected string[] options { get; set; }

        // Constructor calls GetOptions, which chooses the functionality of the Menu
        public Menu(string menuname, string[] options) { this.menuname = menuname; this.options = options; }

        public void OpenMenu(string[] options)
        {
            
            DisplayMenu display = new DisplayMenu(menuname, options);
            int i = display.RunMenu();
            GetOptions(menuname, options, i);
            
        }
    }







    class CalculateMenu : ReadData
    {

        // This class is for calculating what menu options should do

        protected int index;

        protected void GetOptions(string menuname, string[] options, int i)
        {

            if (menuname == "Main Menu") MainMenuOptions(options, i);
            if (menuname == "User Options") UserOptions(options, i);
            if (menuname == "Report Menu") ReportMenuOptions(options, i);
            
        }

        private void MainMenuOptions(string[] options, int i)
        {
            // Instantiate Classes
            AddStudentDetails student = new AddStudentDetails("Students.csv");
            Quiz quiz = new Quiz();
            ReportManager reportManager = new ReportManager();


            if (options[i] == "Reports") reportManager.CreateReportMenu();
            if (options[i] == "Add Student") student.addStudent();
            if (options[i] == "Add Slope Time") student.addSlopeTime(null);
            if (options[i] == "Ski Quiz") quiz.StartQuiz();
            if (options[i] == "Exit") Environment.Exit(0);
        }

        private void UserOptions(string[] options, int i)
        {
            
        }

        private void ReportMenuOptions(string[] options, int i)
        {

            ReportManager reportManager = new ReportManager();

            if (options[i] == "Generic") reportManager.CreateReport(0);
            if (options[i] == "Ski Knowledge") reportManager.CreateReport(1);
            if (options[i] == "Ski Times") reportManager.CreateReport(2);
            if (options[i] == "Main Menu") GoToMainMenu();

        }
    }









    class DisplayMenu
    {

        private string menuname;
        private string[] options;
        private int index;

        public DisplayMenu(string menuname, string[] options)
        {
            this.menuname = menuname;
            this.options = options;
        }

        /*

            Display Options and RunMenu work hand in hand

            Display Options is responsilbe for printing to screen

            whilst RunMenu is repsonsible to calculating what is selected

        */

        public void displayoptions(string[] options, string menuname)
        {
            Console.Clear();
            Console.WriteLine($"[{menuname}]");
            char prefix = '<'; // Indicates what is selected
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i] == options[index]) Console.WriteLine($"{">"}{options[i]}{prefix}");
                else Console.WriteLine($"{options[i]}");
            }
        }

        public int RunMenu()
        {

            // index is representitive of what option is selected, arrow key inversely increments index
            index = 0;
            ConsoleKeyInfo ck;
            displayoptions(options, menuname);
            do
            {
                ck = Console.ReadKey(false);
                if (ck.Key == ConsoleKey.UpArrow) index--;
                else if (ck.Key == ConsoleKey.DownArrow) index++;
                if (index < 0) index = options.Length - 1;
                if (index >= options.Length) index = 0;
                displayoptions(options, menuname);

            } while (ck.Key != ConsoleKey.Enter);

            return index;
        }
    }
}