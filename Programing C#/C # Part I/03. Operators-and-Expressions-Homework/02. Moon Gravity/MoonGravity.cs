/*The gravitational field of the Moon is approximately 17% of that on the Earth.
Write a program that calculates the weight of a man on the moon by a given weight W
(as a floating-point number) on the Earth.The weight W should be read from the console.*/
using System;
using System.Globalization;
using System.Threading;

public class MoonGravity
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string input = Console.ReadLine();
        double earthWeight = double.Parse(input);
        double moonGravity = 0.17;
        double moonWeigt = earthWeight * moonGravity;
        string outputFormat = "{0:0.000}";
        Console.WriteLine(outputFormat, moonWeigt);
    }
}
