/// Write a program that gets two numbers from the console and prints the greater of them.
using System;
using System.Globalization;
using System.Threading;

public class NumbersComparer
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        var greaterNumber = firstNumber > secondNumber ? firstNumber : secondNumber;
        Console.WriteLine(greaterNumber);
    }
}
