/*Using loops write a program that converts a hexadecimal integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.*/

using System;

public class HexToDecimal
{
    public static void Main()
    {
        string hexNumber = Console.ReadLine().ToUpper();
        long decimalNumber = 0;

        for (int i = 0; i < hexNumber.Length; i++)
        {
            long power = hexNumber.Length - 1 - i;
            int hexFactor = 0;
            bool isDigit = int.TryParse(hexNumber[i].ToString(), out hexFactor);

            if (isDigit)
            {
                hexFactor = (int)hexNumber[i] - (int)'0';
            }
            else
            {
                hexFactor = (int)hexNumber[i] - (int)'A' + 10;
            }

            decimalNumber += hexFactor * PowerOfSixteen(power);
        }

        Console.WriteLine(decimalNumber);
    }

    public static long PowerOfSixteen(long power)
    {
        long result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= 16;
        }

        return result;
    }
}
