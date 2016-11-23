using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOccurenceInArray
{
    /*Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
     * how many times each of them occurs.

        Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        2 → 2 times
        3 → 4 times
        4 → 3 times*/
    public class Program
    {
       public static void Main()
        {
            var arr = new int []{ 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var result =  FindNumberOccuranceInSequence(arr);

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} times");
            }
        }

        private static SortedDictionary<int, int> FindNumberOccuranceInSequence(IList<int> numbers)
        {
            var result = new SortedDictionary<int, int>();
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