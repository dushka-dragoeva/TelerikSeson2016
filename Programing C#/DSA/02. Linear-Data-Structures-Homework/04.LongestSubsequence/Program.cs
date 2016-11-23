using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    /*Write a method that finds the longest subsequence of equal numbers in given List and returns the 
     * result as new List<int>.*/
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = ReadInput();
            var subsequence = FindLongestSubsequenceOfEqualNumbers(numbers);
            Console.WriteLine("Longest subsequence of equal numbers:");
            Console.WriteLine(string.Join(", ", subsequence));
        }

        private static List<int> FindLongestSubsequenceOfEqualNumbers(List<int> numbers)
        {
            var counter = 0;
            var currentCounter = 1;
            var currentNumber = numbers[0];

            for (int i = 0; i < numbers.Count - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    currentCounter++;
                }
                else if (currentCounter > counter)
                {
                    counter = currentCounter;
                    currentNumber = numbers[i];
                    currentCounter = 1;
                }
                else
                {
                    currentCounter = 1;
                }
            }

            var result = new List<int>(Enumerable.Repeat(currentNumber, counter));
            return result;
        }

        private static List<int> ReadInput()
        {
            Console.WriteLine("Please enter positive integer numbers - one per row");
            var numbers = new List<int>();
            var input = Console.ReadLine();
            var currentNumber = 0;

            while (input != string.Empty)
            {
                currentNumber = int.Parse(input);
                numbers.Add(currentNumber);
                input = (Console.ReadLine());
            }

            return numbers;
        }
    }
}
