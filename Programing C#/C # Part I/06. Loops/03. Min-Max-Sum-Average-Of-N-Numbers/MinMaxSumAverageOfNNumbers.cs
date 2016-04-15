/*Write a program that reads from the console a sequence of N integer numbers and returns the minimal, 
the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
The input starts by the number N (alone in a line) followed by N lines, each holding an integer number.
The output is like in the examples below.*/
using System;
using System.Globalization;
using System.Threading;

public class MinMaxSumAverageOfNNumbers
{
    public static void Main()
    {
       Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int length = int.Parse(Console.ReadLine());

        double minNumber = int.MaxValue;
        double maxNumber = int.MinValue;
        double number = 0;
        double sum = 0;

        for (int i = 0; i < length; i++)
        {
            number = double.Parse(Console.ReadLine());

            if (number < minNumber)
            {
                minNumber = number;
            }

            if (number > maxNumber)
            {
                maxNumber = number;
            }

            sum += number;
        }

        Console.WriteLine("min={0:F2}", minNumber);
        Console.WriteLine("max={0:F2}", maxNumber);
        Console.WriteLine("sum={0:F2}", sum);

        double avarage = sum / length;
        Console.WriteLine("avg={0:F2}", avarage);
    }
}
