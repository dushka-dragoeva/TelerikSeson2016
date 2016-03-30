/// Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
using System;
using System.Globalization;
using System.Threading;

public class MultiplicationSign
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        
        bool isPossitive = true;
        char productSign = '?';

        for (int i = 0; i < 3; i++)
        {
            double number = double.Parse(Console.ReadLine());

            if (number != 0)
            {
                if (number < 0)
                {
                    isPossitive = !isPossitive;
                }

                productSign = isPossitive ? '+' : '-';
            }
            else
            {
                productSign = '0';
                break;
            }
        }

        Console.WriteLine(productSign);
    }
}
