/*Using loops write a program that converts a binary integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.*/

using System;

public class BinaryToDecimal
{
    public static void Main()
    {
        var binaryNumber = Console.ReadLine();
        long decimalNumber = 0;
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            long power = binaryNumber.Length - 1 - i;
            if (binaryNumber[i] == '1')
            {
                decimalNumber += PowerOfTow(power);
            }
        }

        Console.WriteLine(decimalNumber);
    }

    public static long PowerOfTow(long power)
    {
        long result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= 2;
        }

        return result;
    }
}
