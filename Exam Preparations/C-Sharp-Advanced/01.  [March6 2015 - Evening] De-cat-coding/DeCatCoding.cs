using System;
using System.Linq;
using System.Numerics;

public class DeCatCoding
{
    private const int BaseA = 21;
    private const int BaseB = 26;

    public static void Main()
    {
        var encoded = Console.ReadLine().Split(' ').ToArray();
        var decoded = new string[encoded.Length];

        for (int i = 0; i < encoded.Length; i++)
        {
            BigInteger currentEncoded = NumberToDecimal(21, encoded[i]);
            decoded[i] = DecimalToBaseN(currentEncoded, BaseB);
        }

        Console.WriteLine(string.Join(" ", decoded));
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
