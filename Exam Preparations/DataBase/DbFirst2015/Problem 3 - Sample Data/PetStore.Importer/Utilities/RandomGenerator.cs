using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Importer.Utilities
{
    public class RandomGenerator
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private const string NumbersAsString = "0123456789";

        private static Random generator = new Random();

        //public RandomGenerator()
        //{
        //    generator = new Random();
        //}

        public static int GenerateIntenger(int minValue, int maxValue)
        {
            var number = generator.Next(minValue, maxValue + 1);
            return number;
        }

        public static string GenerateString(int minLength, int maxLength)
        {
            var sb = new StringBuilder();

            int alphabetLength = EnglishAlphabet.Length;
            int stringLength = GenerateIntenger(minLength, maxLength);

            for (int i = 0; i < stringLength; i++)
            {
                int letterIndex = GenerateIntenger(0, alphabetLength - 1);
                char letter = EnglishAlphabet[letterIndex];
                sb.Append(letter);
            }

            return sb.ToString();
        }

        public static string GenerateNumberAsString(int minLength, int maxLength)
        {
            var sb = new StringBuilder();

            int numbersLength = NumbersAsString.Length;
            int stringLength = GenerateIntenger(minLength, maxLength);

            for (int i = 0; i < stringLength; i++)
            {
                int letterIndex = GenerateIntenger(0, numbersLength - 1);
                char letter = NumbersAsString[letterIndex];
                sb.Append(letter);
            }

            return sb.ToString();
        }

        public static DateTime GenarateDateInPast()
        {
            return DateTime.UtcNow.AddDays(-new Random().Next(90));

        }

        public static DateTime GenarateDateIFuture()
        {
            return DateTime.UtcNow.AddDays(new Random().Next(90));

        }

        public static DateTime RandomDateTime(DateTime? after = null, DateTime? before = null)
        {
            var afterValue = after ?? new DateTime(2010, 1, 1, 0, 0, 0);
            var beforeValue = before ?? DateTime.Now.AddDays(-60);

            var second = GenerateIntenger(afterValue.Second, beforeValue.Second);
            var minute = GenerateIntenger(afterValue.Minute, beforeValue.Minute);
            var hour = GenerateIntenger(afterValue.Hour, beforeValue.Hour);
            var day = GenerateIntenger(afterValue.Day, beforeValue.Day);
            var month = GenerateIntenger(afterValue.Month, beforeValue.Month);
            var year = GenerateIntenger(afterValue.Year, beforeValue.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
