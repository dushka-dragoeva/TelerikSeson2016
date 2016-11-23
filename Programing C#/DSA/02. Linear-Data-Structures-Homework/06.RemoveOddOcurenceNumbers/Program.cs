using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOcurenceNumbers
{
    /*06. Write a program that removes from given sequence all numbers that occur odd number of times.
        Example:
        {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}*/
    public class Program
    {
        public static void Main()
        {
            var numbers = new int [] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine(string.Join(" ", RemoveNumbersThatOccureOddTimes(numbers)));
        }

        private static List<int> RemoveNumbersThatOccureOddTimes(IList<int> numbers)
        {
            var result = new List<int>();
            var numberOccurance = FindNumberOccuranceInSequence(numbers);

            foreach (var number in numbers)
            {
                if (numberOccurance[number] % 2 == 0)
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private static Dictionary<int, int> FindNumberOccuranceInSequence(IList<int> numbers)
        {
            var result = new Dictionary<int, int>();
            var key = 0;
            for (int i = 0; i < numbers.Count ; i++)
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
