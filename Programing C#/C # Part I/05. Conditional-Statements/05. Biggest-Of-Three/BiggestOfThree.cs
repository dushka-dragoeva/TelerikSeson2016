/// Write a program that finds the biggest of three numbers that are read from the console.
using System;
using System.Globalization;
using System.Threading;

public class BiggestOfThree
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double biggestNumber = double.MinValue;

        for (int i = 0; i < 3; i++)
        {
            double number = double.Parse(Console.ReadLine());
            if (number > biggestNumber)
            {
                biggestNumber = number;
            }
        }

        Console.WriteLine(biggestNumber);
    }
}
