using System;
namespace DataValidation
{
    public static class ValidateData
    {
        public static void Validate(Action test, Action fail)
        {
            try
            {
                test();
            }
            catch (Exception ex)
            {
                fail();
            }


        }


        public static bool isValidInt(string input) => Int32.TryParse(input, out int result);





    }
}