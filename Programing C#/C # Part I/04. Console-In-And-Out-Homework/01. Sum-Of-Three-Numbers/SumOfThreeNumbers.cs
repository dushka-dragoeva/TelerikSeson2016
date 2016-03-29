/// Write a program that reads 3 real numbers from the console and prints their sum.
using System;
using System.Globalization;
using System.Threading;

public class SumOfThreeNumbers
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double sum = a + b + c;
        Console.WriteLine(sum);
    }
}
