using System;
using System.Collections.Generic;

using ExceptionsHomework.Utilities;

namespace ExceptionsHomework.Tests
{
    public class UtilitiesTester
    {
        public static void RunSubSubsequeneTest()
        {
            try
            {
                var substr = ExseptionsUtilities.GetSubsequence("Hello!".ToCharArray(), 2, 7);
                Console.WriteLine(substr);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var testData = new Dictionary<int[], int[]>();
            testData.Add(new int[] { -1, 3, 2, 1 }, new int[] { 0, 2 });
            testData.Add(new int[] { -1, 3, 2, 1 }, new int[] { 0, 4 });
            testData.Add(new int[] { -1, 3, 2, 1 }, new int[] { 0, 0 });

            foreach (var item in testData)
            {
                try
                {
                    var subarr = ExseptionsUtilities.GetSubsequence(item.Key, item.Value[0], item.Value[1]);
                    Console.WriteLine(string.Join(" ", subarr));
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void RunExtractEndingTest()
        {
            var testData = new Dictionary<string, int>()
            {
                { "I love C#", 2 },
                { "Nakov", 4 },
                { "beer", 4 },
                { "Hi", 100 }
            };

            foreach (var data in testData)
            {
                try
                {
                    Console.WriteLine(ExseptionsUtilities.ExtractEnding(data.Key, data.Value));
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void RunCheckPrimeTest()
        {
            int[] numbers = { 23, 33 };

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    ExseptionsUtilities.CheckPrime(numbers[i]);
                    Console.WriteLine($"{numbers[i]} is prime.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
