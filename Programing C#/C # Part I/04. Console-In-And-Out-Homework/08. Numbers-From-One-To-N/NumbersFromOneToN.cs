/// Write a program that reads an integer number N from the console and prints all the numbers in 
/// the interval [1, n], each on a single line.
using System;

public class NumbersFromOneToN
{
    public static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numberN; i++)
        {
            Console.WriteLine(i);
        }
    }
}
