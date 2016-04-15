/// Write a program that, for a given two longeger numbers N and x, calculates the sum 
/// S = 1 + 1!/x + 2!/x<sup>2</sup> + … + n!/x<sup>N</sup>.Use only one loop.
/// Prlong the result with 5 digits after the decimal polong.
using System;

public class CalculateFactorial
{
    public static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());
        double numberX = double.Parse(Console.ReadLine());

        double sum = 1;
        ulong factorial = 1;

        for (int i = 1; i <= numberN; i++)
        {
            factorial *= (ulong)i;
            sum += factorial / Math.Pow(numberX, i);
        }

        Console.WriteLine("{0:F5}", sum);
    }
}