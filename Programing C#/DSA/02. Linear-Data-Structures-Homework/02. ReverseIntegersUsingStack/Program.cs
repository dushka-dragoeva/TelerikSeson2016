using System;
using System.Collections.Generic;

namespace _02.ReverseIntegersUsingStack
{
    /*Write a program that reads N integers from the console and reverses them using a stack.
    Use the Stack<int> class.*/
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter integer numbers - one per row");
            var numbers = new Stack<int>();
            var input = Console.ReadLine();
            var currentNumber = 0;
            while (input != string.Empty)
            {
                currentNumber = int.Parse(input);

                numbers.Push(currentNumber);
                input = (Console.ReadLine());
            }

            Console.WriteLine("Reversed numbers");
            while (numbers.Count != 0)
            {
                currentNumber = numbers.Pop();
                Console.WriteLine(currentNumber);
            }
        }
    }
}
