using System;

public class ThreeDigits
{
    public static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int maxNumber = Math.Max(a, b);
        maxNumber = Math.Max(maxNumber, c);
        int minNumber = Math.Min(a, b);
        minNumber = Math.Min(minNumber, c);
        double arithmeticMean = (double)(a + b + c) / 3;
        string format = "{0:F}";

        Console.WriteLine(maxNumber);
        Console.WriteLine(minNumber);
        Console.WriteLine(format, arithmeticMean);
    }
}