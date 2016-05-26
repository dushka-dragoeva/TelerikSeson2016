using System;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().ToUpper();
        Console.WriteLine(ConvertToDecimal(input, 16));
    }

    private static long ConvertToDecimal(string number, int systemBase)
    {
        long decimalNumber = 0;

        for (int i = 0; i < number.Length; i++)
        {
            long coeficient = number[i] - '0';
            if (coeficient >= 10)
            {
                coeficient = (number[i] - 'A') + 10;
            }

            long power = number.Length - 1 - i;

            decimalNumber += coeficient * Power(systemBase, power);
        }

        return decimalNumber;
    }

    private static long Power(long systemBase, long power)
    {
        long number = 1;

        for (int i = 0; i < power; i++)
        {
            number *= systemBase;
        }

        return number;
    }
}
