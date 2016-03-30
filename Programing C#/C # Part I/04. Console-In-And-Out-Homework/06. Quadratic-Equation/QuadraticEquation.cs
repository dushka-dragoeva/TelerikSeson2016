/// Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 
/// and solves it (prints its real roots).
using System;
using System.Globalization;
using System.Threading;

public class QuadraticEquation
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        string output = string.Empty;

        double discriminant = (b * b) - (4 * a * c);
        if (discriminant < 0)
        {
            output = "no real roots";
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            output = string.Format("{0:F2}", root);
        }
        else
        {
            double firstRoot = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double secondRoot = (-b - Math.Sqrt(discriminant)) / (2 * a);
            string formatedOutput = "{0:F2}\n{1:F2}";

            output = firstRoot < secondRoot ?
               string.Format(formatedOutput, firstRoot, secondRoot) :
               string.Format(formatedOutput, secondRoot, firstRoot);
        }

        Console.WriteLine(output);
    }
}
