using System;
using System.Collections.Generic;

namespace CombinationWithoutDuplications
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Number Of Elements = ");
            var numberOfElements = int.Parse(Console.ReadLine());
            Console.Write("Number Of Combinations = ");
            var numberOfCombinations = int.Parse(Console.ReadLine());
            var combinations = new int[numberOfCombinations];

            var result = new List<string>();
            result.PutCombinations(1, numberOfElements, combinations, 0);
            Console.WriteLine(string.Join(", ", result));
        }

        private static void PutCombinations(this IList<string> output, int startNumer, int endNumber, int[] placeholder, int index)
        {
            if (index == placeholder.Length)
            {
                output.Add(string.Format("({0})", string.Join(" ", placeholder)));
                return;
            }

            for (var number = startNumer; number <= endNumber; number++)
            {
                placeholder[index] = number;
                output.PutCombinations(number+1, endNumber, placeholder, index + 1);
            }

        }
    }
}
