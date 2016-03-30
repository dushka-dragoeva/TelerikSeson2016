/// Write a program that finds the biggest of 5 numbers that are read from the console, 
/// using only 5 if statements.
using System;
using System.Globalization;
using System.Threading;

public class BiggestOfFive
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double biggestNumber = double.MinValue;

            for (int i = 0; i < 5; i++)
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
