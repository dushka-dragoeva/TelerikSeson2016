using System;
using System.Linq;
using System.Numerics;

public class CalculationProblem
{
    private const int Base = 23;

    public static void Main(string[] args)
    {
        var codedNumbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        BigInteger sum = 0;

        foreach (var number in codedNumbers)
        {
            sum += NumberToDecimal(Base, number);
        }

        var encoded = DecimalToBaseN(sum, Base);
        Console.WriteLine("{0} = {1}", encoded, sum);
    }

    private static BigInteger NumberToDecimal(byte baseA, string num)
    {
        BigInteger decimalNumber = 0;

        for (int i = 0; i < num.Length; i++)
        {
            int digit = 0;
            int position = num.Length - i - 1;

            digit = num[i] - 'a';
            decimalNumber = digit + (decimalNumber * baseA);
        }

        return decimalNumber;
    }

    private static string DecimalToBaseN(BigInteger decValue, int outputBase)
    {
        string result = string.Empty;

        do
        {
            BigInteger reminder = decValue % outputBase;
            char digitToChar = (char)(reminder + 'a');

            ///  digit = num[i] - 'a';
            result = digitToChar + result;
            decValue /= outputBase;
        }
        while (decValue > 0);

        return result;
    }
}
