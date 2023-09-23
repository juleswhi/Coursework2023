using System;
using System.IO;
using Utils;

namespace ClaredonHighSchoolSkiTrip
{
    class ShowReport
    {
        public void Print(string[,] data, int sortedColumn)
        {
            Console.Clear();
            for (int i = 0; i < data.GetLength(1); i++)
            {
                Console.Write($"{data[0, i]}|");
            }

            Console.WriteLine();
            Console.WriteLine();



            for (int i = 1; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {

                    if (j == sortedColumn)
                    {
                        // If Ski Times
                        if (sortedColumn == 5)
                        {
                            if (i > (data.GetLength(1) / 1.5))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else Console.ForegroundColor = ConsoleColor.Green;




                        }

                        if (sortedColumn == 6)
                        {
                            // Grades
                            if ("A" == data[i, j].RemoveWhitespace()) Console.ForegroundColor = ConsoleColor.Green;
                            else if ("B" == data[i, j].RemoveWhitespace()) Console.ForegroundColor = ConsoleColor.Yellow;
                            else if ("C" == data[i, j].RemoveWhitespace()) Console.ForegroundColor = ConsoleColor.Red;

                            // Groups

                            if ("Advanced" == data[i, j].RemoveWhitespace()) Console.ForegroundColor = ConsoleColor.Green;
                            else if ("Intermediate" == data[i, j].RemoveWhitespace()) Console.ForegroundColor = ConsoleColor.Yellow;
                            else if ("Beginner" == data[i, j].RemoveWhitespace()) Console.ForegroundColor = ConsoleColor.Red;

                        }
                    }
                    Console.Write($"{data[i, j]}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Return");
            Console.ReadKey();
        }
    }


    class ReportManager : ReadData
    {

        protected string?[,] data;

        private ReportTypes ReportType;

        enum ReportTypes
        {
            Generic = 0,
            SkiKnowledge = 1,
            SkiTimes = 2
        }
        private static string createAscii()
        {
            string[] ascii = new string[8];
            string finalAscii = "";
            ascii[0] = @"  _____                       _     __  __                  ";
            ascii[1] = @" |  __ \                     | |   |  \/  |                 ";
            ascii[2] = @" | |__) |___ _ __   ___  _ __| |_  | \  / | ___ _ __  _   _ ";
            ascii[3] = @" |  _  // _ \ '_ \ / _ \| '__| __| | |\/| |/ _ \ '_ \| | | |";
            ascii[4] = @" | | \ \  __/ |_) | (_) | |  | |_  | |  | |  __/ | | | |_| |";
            ascii[5] = @" |_|  \_\___| .__/ \___/|_|   \__| |_|  |_|\___|_| |_|\__,_|";
            ascii[6] = @"            | |                                             ";
            ascii[7] = @"            |_|                                             ";

            for (int i = 0; i < ascii.Length; i++)
            {
                finalAscii = finalAscii + "\n" + ascii[i];
            }

            return finalAscii;
        }

        public void CreateReportMenu()
        {
            string[] ReportMenuOptions = File.ReadAllLines("ReportMenuOptions.csv");
            Menu menu = new Menu("Report Menu", ReportMenuOptions, createAscii());
            menu.OpenMenu(ReportMenuOptions);
        }


        public void CreateReport(int index)
        {

            int sortedColumn = -1;
            // Sort Report
            string path = "Students.csv";

            data = readData(path, 7);

            switch (index)
            {
                case (int)ReportTypes.Generic: ReportType = ReportTypes.Generic; sortedColumn = 6; break;
                case (int)ReportTypes.SkiKnowledge: ReportType = ReportTypes.SkiKnowledge; sortedColumn = 5; break;
                case (int)ReportTypes.SkiTimes: ReportType = ReportTypes.SkiTimes; sortedColumn = 6; break;
            }

            string[,] sortedArray;

            if (ReportType == ReportTypes.SkiKnowledge)
            {
                sortedArray = BubbleSort(data, sortedColumn);
            }
            if (ReportType == ReportTypes.SkiTimes)
            {
                sortedArray = group(data, sortedColumn);
            }

            else sortedArray = data;

            ShowReport report = new ShowReport();

            StandardizeLength();
            if (!(data is null)) report.Print(sortedArray, sortedColumn);
            else
            {
                Console.WriteLine("Data Is Null");
                Console.ReadKey();
            }

            CreateReportMenu();

        }

        private void StandardizeLength()
        {
            for (int i = 0; i < data.GetLength(1); i++)
            {
                // Length is 0 as default
                int length = 0;
                // Loop through the array and find what the longest length is out of column
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    if (data[j, i].Length > length) length = data[j, i].Length;
                }

                // add spaces until length is equal of longest length
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    while (data[j, i].Length < length)
                    {
                        data[j, i] = data[j, i] + " ";
                    }

                }
            }
        }



        public string[,] group(string[,] data, int column)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                switch (data[i, column].RemoveWhitespace())
                {
                    case "A":
                        data[i, column] = "1";
                        break;
                    case "B":
                        data[i, column] = "2";
                        break;
                    default:
                        data[i, column] = "3";
                        break;
                }
            }


            string[,] resData = BubbleSort(data, column);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                switch (resData[i, column].RemoveWhitespace())
                {
                    case "1":
                        resData[i, column] = "Advanced";
                        break;
                    case "2":
                        resData[i, column] = "Intermediate";
                        break;
                    default:
                        resData[i, column] = "Beginner";
                        break;
                }
            }


            return resData;
        }

        public string[,] BubbleSort(string[,] array, int column)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == "?")
                    {
                        array[i, j] = "10000";
                    }
                }
            }

            // Sorts Through Data and orders it

            ArrayUtils<string> arrayUtils = new ArrayUtils<string>();

            string[] tempArray = new string[array.GetLength(1)];

            for (int i = 1; i < array.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < array.GetLength(0) - 1; j++)
                {
                    if (Convert.ToInt32(array[j, column]) > Convert.ToInt32(array[j + 1, column]))
                    {
                        tempArray = arrayUtils.GetRow(array, j + 1);
                        for (int l = 0; l < array.GetLength(1); l++)
                        {
                            array[j + 1, l] = array[j, l];
                        }
                        for (int m = 0; m < array.GetLength(1); m++)
                        {
                            array[j, m] = tempArray[m];
                        }
                    }
                }
            }



            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == "10000")
                    {
                        array[i, j] = "?";
                    }
                }
            }

            return array;
        }
    }
}