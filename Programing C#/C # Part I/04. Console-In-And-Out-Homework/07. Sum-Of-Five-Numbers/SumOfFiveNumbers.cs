/// Write a program that reads 5 integer numbers from the console and prints their sum.
using System;

public class SumOfFiveNumbers
{
    public static void Main()
    {
        int number;
        int sum = 0;

        for (int i = 0; i < 5; i++)
        {
            number = int.Parse(Console.ReadLine());
            sum += number;
        }

        Console.WriteLine(sum);
    }
}
