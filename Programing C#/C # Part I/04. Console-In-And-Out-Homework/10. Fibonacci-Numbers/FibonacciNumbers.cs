/// Write a program that reads a number N and prints on the console the first N members of the Fibonacci sequence
/// (at a single line, separated by comma and space - ", ") : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
using System;

public class FibonacciNumbers
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int current;
        int previous = 1;
        int beforePrevious = 0;
       
        for (int i = 0; i < length; i++)
        {
            if (i == 0)
            {
                current = beforePrevious;
            }
            else if (i == 1)
            {
                current = previous;
            }
            else
            {
                current = beforePrevious + previous;
                beforePrevious = previous;
                previous = current;
            }

            Console.WriteLine(current);
        }
    }
}