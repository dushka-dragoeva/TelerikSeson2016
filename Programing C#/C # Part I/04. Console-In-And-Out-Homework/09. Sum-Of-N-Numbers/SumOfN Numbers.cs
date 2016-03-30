/// Write a program that enters a number N and after that enters more N numbers and calculates and 
/// prints their sum. Note: You may need to use a for-loop.
using System;
using System.Globalization;
using System.Threading;

public class SumOfNNumbers
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int length = int.Parse(Console.ReadLine());
        double number = 0;
        double sum = 0;
        for (int i = 0; i < length; i++)
        {
            number = double.Parse(Console.ReadLine());
            sum += number;
        }

        Console.WriteLine(sum);
    }
}
