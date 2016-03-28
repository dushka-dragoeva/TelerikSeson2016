/*Write an expression that calculates trapezoid's area by given sides a and b and height h.
The three values should be read from the console in the order shown below. All three value will be 
floating-point numbers.*/
using System;
using System.Globalization;
using System.Threading;

public class Trapezoids
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double area = (a + b) * h / 2;
        Console.WriteLine("{0:0.0000000}", area);
    }
}
