namespace DataValidation
{
    public static class ValidateData
    {
        public static bool Validate(this int data, int min, int max)
        {
            if(data > min && data < max)
                return true;

            else return false;
        }

        public static bool Validate(this string data)
        {

            return true;
        }

        public static bool Validate(this float data)
        {

            return true;
        }
    }
}