using System;
using System.Text;

namespace EMS.Core.Application.Utils
{
    public static class RandomValuesGenerator
    {
        // Generate a random password of a given length (optional)  
        public static string RandomPassword(int size = 8)
        {
            if (size < 4)
                throw new Exception("Minimum password size should be 4");

            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(1, false));//capital letter character
            builder.Append(RandomString(size - 3, true));//lower case chars
            builder.Append(RandomNumber(1000, 9999));//number
            builder.Append('!');//non alphanumeric char
            return builder.ToString();
        }

        // Generate a random number between two numbers    
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
