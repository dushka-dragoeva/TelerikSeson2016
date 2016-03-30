/*Write a program that reads two double values from the console A and B, stores them in variables and exchanges 
 * their values if the first one is greater than the second one. Use an if-statement. As a result print the 
 * values of the variables A and B, separated by a space.*/
using System;
using System.Globalization;
using System.Threading;

public class ExchangeIfGreater
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double firstDouble = double.Parse(Console.ReadLine());
        double secondDouble = double.Parse(Console.ReadLine());

        if (firstDouble > secondDouble)
        {
            double temp = firstDouble;
            firstDouble = secondDouble;
            secondDouble = temp;
        }

        string outputFormat = "{0} {1}";
        Console.WriteLine(outputFormat, firstDouble, secondDouble);
    }
}
