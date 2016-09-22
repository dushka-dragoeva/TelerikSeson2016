using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHomework.Utilities
{
    public class ExseptionsUtilities
    {
        private const string ShouldNotBeNullOrEmpty = "The {0} should not be null or empty.";
        private const string ShouldBeWithinTheRange = "The {0} should be within the range [{1}; {2}]";

        private const int MinIndexValue = 0;

        public static T[] GetSubsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentNullException("Array", string.Format(ShouldNotBeNullOrEmpty, "array"));
            }

            var maxIndexValue = arr.Length - 1;
            if (!Validator.ValidateIntegerRange(startIndex, 0, maxIndexValue))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(startIndex),
                    string.Format(ShouldBeWithinTheRange, nameof(startIndex), MinIndexValue, maxIndexValue));
            }

            var maxCountValue = arr.Length - startIndex;
            if (!Validator.ValidateIntegerRange(count, 0, maxCountValue))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                  string.Format(ShouldBeWithinTheRange, nameof(count), MinIndexValue, maxCountValue));
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (!Validator.ValidateString(str))
            {
                throw new ArgumentNullException("String", string.Format(ShouldNotBeNullOrEmpty, "string"));
            }

            var maxCountValue = str.Length;
            if (!Validator.ValidateIntegerRange(count, 0, maxCountValue))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                   string.Format(ShouldBeWithinTheRange, nameof(count), MinIndexValue, maxCountValue));
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            var minPrimeNumber = 2;
            if (!Validator.ValidateIntegerRange(number, minPrimeNumber))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(number),
                    string.Format(ShouldBeWithinTheRange, nameof(number), minPrimeNumber, int.MaxValue));
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    throw new ArgumentException(nameof(number), $"{number} is not prime!");
                }
            }
        }
    }
}
