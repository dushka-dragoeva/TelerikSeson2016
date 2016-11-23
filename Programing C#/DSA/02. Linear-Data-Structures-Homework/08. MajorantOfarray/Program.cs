using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MajorantOfarray
{
    /*08. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

        Write a program to find the majorant of given array (if exists).
        Example:
        {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3*/
    public class Program
    {
        public static void Main()
        {
            var arr = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var minMajorantValue = arr.Length / 2 + 1;
            var majoriant = 0;
            var numberOccurances = FindNumberOccuranceInSequence(arr);

            foreach (var pair in numberOccurances)
            {
                if (pair.Value >= minMajorantValue)
                {
                    majoriant = pair.Key;
                    break;
                }
            }

            var result = majoriant > 0 ? $"The majoriant is  {majoriant}" : "This ara=ray hasn't majoriant";
            Console.WriteLine(result);
        }

        private static Dictionary<int, int> FindNumberOccuranceInSequence(IList<int> numbers)
        {
            var result = new Dictionary<int, int>();
            var key = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                key = numbers[i];
                if (result.Keys.Contains(key))
                {
                    result[key]++;
                }
                else
                {
                    result.Add(key, 1);
                }
            }

            return result;
        }
    }
}
