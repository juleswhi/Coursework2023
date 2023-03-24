using System;
using System.Linq;


namespace Utils
{
    public static class Loops
    {
        // Extension method, this keyword means method is called like Int.Loop
        public static void Loop(this int count, Action action)
        {
            for(int i = 0; i < count; i++)
            {
                action();
            }
        }
        public static void Here(this string here)
        {

            Console.WriteLine($"You are at {here}");
            System.Threading.Thread.Sleep(1000);
            
        }
    }

    public class ArrayUtils<T>
    {
        public T[] GetRow(T[,] array, int rowNumber)
        {
            return Enumerable.Range(0, array.GetLength(1))
                .Select(x => array[rowNumber, x])
                .ToArray();
        }
    }
}



    


