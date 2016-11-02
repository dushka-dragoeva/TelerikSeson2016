using System;
using System.Text;

namespace StudentSystem.Utilities
{
    public class RandomGenerator
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private const string NumbersAsString = "0123456789";

        private static Random Generator = new Random();

        public static int GenerateIntenger(int minValue, int maxValue)
        {
            var number = Generator.Next(minValue, maxValue + 1);
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
    }
}
