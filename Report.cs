using System.IO;
using Utils;
using System;

namespace ClaredonHighSchoolSkiTrip
{
    class ShowReport : ReportManager
    {
        public void Print()
        {
            for(int i = 1; i < data.GetLength(0); i++)
            {
                for(int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write($"{data[i,j]}|");
                }
                Console.WriteLine();
            }
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

        public void CreateReportMenu()
        {
            string[] ReportMenuOptions = File.ReadAllLines("ReportMenuOptions.csv");
            Menu menu = new Menu("Report Menu", ReportMenuOptions);
            menu.OpenMenu(ReportMenuOptions);
        }


        public void CreateReport(int index)
        {
            string path = "Students.csv";


            data = readData(path, 7);

            StandardizeLength();


            if (index == (int)ReportTypes.Generic)
                ReportType = ReportTypes.Generic;

            if (index == (int)ReportTypes.SkiKnowledge)
                ReportType = ReportTypes.SkiKnowledge;

            if (index == (int)ReportTypes.SkiTimes)
                ReportType = ReportTypes.SkiTimes;


            
        }

        private void StandardizeLength()
        {
            int[] length = new int[data.GetLength(0)];
            for(int i = 0; i <  data.GetLength(0); i++)
            {
                for(int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j].Length >= length[i])
                        length[j] = data[i, j].Length;
                }
            }

            for(int a = 0; a < data.GetLength(0); a++)
            {
                for(int b = 0; b < data.GetLength(1); b++)
                {
                    for(int c = data[a,b].Length; c < length[b]; c++)
                    {
                        data[a, b] = $"{data[a, b]} ";
                    }
                }
            }
        }
    }
}