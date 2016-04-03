/* Write a program that calculates with how many zeroes the factorial of a given number N has at its end.
Your program should work well for very big numbers, e.g. N = 100000.*/
using System;
using System.Numerics;

public class TralingZeroInNFactorial
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        var result = factorial.ToString().ToCharArray();
        Array.Reverse(result);

        int counter = 0;

        foreach (var item in result)
        {
            if (item == '0')
            {
                counter++;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(counter);
    }
}
