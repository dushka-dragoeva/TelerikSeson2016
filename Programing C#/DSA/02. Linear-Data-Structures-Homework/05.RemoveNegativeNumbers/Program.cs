using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativeNumbers
{
    /*05. Write a program that removes from given sequence all negative numbers.*/
    public class Program
    {
        public static void Main()
        {
            var numbers = new List<int> { 7, 13, 45, -9, 2368, -958, -3, 2, 4, 6 };
            var result = numbers.Where(x => x >= 0)
                .ToList();



            Console.WriteLine("Given sequence:");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine("Negative numbers are removed:");
            Console.WriteLine(string.Join(", ", result));
        }



    }
}
