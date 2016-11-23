using System;
using System.Collections.Generic;

namespace SumAndAverageOfSequence
{
    /*01. Write a program that reads from the console a sequence of positive integer numbers.
    The sequence ends when empty line is entered.
    Calculate and print the sum and average of the elements of the sequence.
    Keep the sequence in List<int>.*/
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter positive integer numbers - one per row");
            var numbers = new List<int>();
            var input = Console.ReadLine();
            var currentNumber = 0;
            var sum = 0;

            while (input != string.Empty)
            {
                currentNumber = int.Parse(input);
                sum += currentNumber;
                numbers.Add(currentNumber);
                input = (Console.ReadLine());
            }

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Avarage: {(double)sum / numbers.Count}");
        }
    }
}
