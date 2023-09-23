using System;
using System.IO;

namespace ClaredonHighSchoolSkiTrip
{
    class ReadData : MenuControls
    {

        // Necessary for many classes to function

        protected string[,] readData(string path, int columns)
        {
            string[,] data = null;
            try
            {
                string[] readInData = new string[File.ReadAllLines(path).Length];


                int rows = readInData.Length;

                readInData = File.ReadAllLines(path);

                data = new string[rows, columns];

                string[] temp = new string[columns];
                for (int i = 0; i < rows; i++)
                {
                    temp = readInData[i].Split(',');
                    for (int j = 0; j < columns; j++)
                    {
                        data[i, j] = temp[j];
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Could not read in from the file\nPlease Check if {path} is in use");
                if (path != "Staff.csv")
                {
                    Console.WriteLine("Please press any key to return to main menu");
                    Console.ReadKey();
                    GoToMainMenu();
                }
                Console.WriteLine($"Press any key to retry login");
                Console.ReadKey();
                var Login = new Login();
                Console.Clear();
                Login.LoginLoop();

            }
            return data;
        }
    }
}