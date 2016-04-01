/// Write a program that safely compares two floating-point numbers (double) with 
/// precision eps = 0.000001.
using System;
using System.Globalization;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        /// Compare the absolute value of the difference between tow numbers 
        /// with the value for precision
        bool areEqual = Math.Abs(firstNumber - secondNumber) < eps;
        Console.WriteLine(areEqual.ToString().ToLower());
    }
}
