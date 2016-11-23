using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SortIntegersIncreasing
{
    /*03. Write a program that reads a sequence of integers (List<int>) ending with an empty 
        * line and sorts them in an increasing order.*/
    public class Program
    {
        public static void Main()
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

            var sortedNumbers = numbers
                .OrderBy(x => x);

            Console.WriteLine("Sorted numbers:");
            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
