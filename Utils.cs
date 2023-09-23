using System;
using System.Linq;


namespace Utils
{

    public static class ValidateData
    {
        // Method for converting type into an integer
        public static int ValidateInt<T>(this T test, Action fail)
        {
            Type ConvertTo = typeof(int);
            if (ConvertTo == null) return -1;

            foreach (var character in test.ToString())
            {
                if (!Char.IsNumber(character)) fail();
            }
            try
            {
                if (test.GetType() == typeof(string))
                {
                    if (isValidInt<string>(test.ToString()))
                    {
                        return Convert.ToInt32(test);
                    }
                    else fail();
                    return -1;
                }

                // If the test type is a double
                else if (test.GetType() == typeof(double))
                {
                    // if it can be converted to an int, then convert to an int
                    if (isValidInt<double>(Convert.ToDouble(test)))
                    {
                        return Convert.ToInt32(test);
                    }
                    else fail();
                    return -1;
                }

            }
            catch (Exception ex)
            {
                fail();
            }

            return -1;

        }




        // Method for converting type into double
        public static double ValidateDouble<T>(this T test, Action fail)
        {
            Type ConvertTo = typeof(double);

            try
            {
                if (test.GetType() == typeof(string))
                {
                    if (isValidDouble<string>(test.ToString()))
                    {
                        if (Convert.ToDouble(test) == -1)
                            fail();
                        if (Convert.ToDouble(test) > 100)
                        {
                            fail();
                        }
                        return Convert.ToDouble(test);
                    }
                    else fail();
                    return -1;
                }

                // If the test type is a double
                else if (test.GetType() == typeof(int))
                {
                    // if it can be converted to an int, then convert to an int
                    if (isValidDouble<int>(Convert.ToInt32(test)))
                    {
                        return Convert.ToDouble(test);
                    }
                    else fail();
                    return -1;
                }

            }
            catch (Exception ex)
            {
                fail();
            }

            return -1;
        }


        public static string ValidateDate(this string inp, Action fail)
        {
            if (!inp.Contains('/')) fail();
            foreach (var nums in inp.Split('/'))
            {
                foreach (var characters in nums.ToString())
                {
                    if (!Char.IsNumber(characters)) fail();
                }

                if (nums.ToString().Length > 4)
                {
                    fail();
                }

            }

            return inp;
        }


        private static bool isValidInt<T>(T input) => Int32.TryParse(input.ToString(), out int result);
        private static bool isValidDouble<T>(T input) => Double.TryParse(input.ToString(), out double result);

        private static void IsStringLetters(this string str, Action fail)
        {
            foreach (var character in str)
            {
                if (!Char.IsLetter(character))
                {
                    fail();
                }
            }
        }

        public static void IsMaxStringLength(this string str, Action fail)
        {
            if (str.Length > 20) fail();
        }
        public static void IsNumberInString(this string str, Action fail)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i])) fail();
            }
        }

        public static void ValidateString(this string str, Action fail)
        {
            str.IsMaxStringLength(fail);
            str.IsNumberInString(fail);
            str.IsStringLetters(fail);
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

        public T[] GetColumn(T[,] array, int columnNumber)
        {
            return Enumerable.Range(0, array.GetLength(0))
                .Select(x => array[x, columnNumber])
                .ToArray();
        }
    }

    public static class StringUtils
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }



}






