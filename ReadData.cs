using System;
using System.Threading;
using System.IO;

namespace ClaredonHighSchoolSkiTrip
{
    class ReadData : MenuControls
    {
        
        // Necessary for many classes to function

        protected string[,] readData(string path, int columns)
        {
            string[] readInData = new string[File.ReadAllLines(path).Length];

            int rows = readInData.Length;

            readInData = File.ReadAllLines(path);

            string[,] data = new string[rows, columns];

            string[] temp = new string[columns];
            for (int i = 0; i < rows; i++)
            {
                temp = readInData[i].Split(',');
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = temp[j];
                }
            }

            return data;
        }
    }
}