/// Write a program that reads from the console the radius r of a circle and prints its perimeter and area, 
/// rounded and formatted with 2 digits after the decimal point.
using System;
using System.Globalization;
using System.Threading;

public class Circle
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double radius = double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * Math.Pow(radius, 2);
        string outputFormat = "{0:0.00} {1:0.00}";
        Console.WriteLine(outputFormat, perimeter, area);
    }
}
