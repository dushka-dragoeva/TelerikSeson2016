using System;
using System.Collections.Generic;
using System.Numerics;

public class OneSystemToAnyOther
{
    private static readonly Dictionary<BigInteger, char> DigitToChar = new Dictionary<BigInteger, char>()
        {
            { 0, '0' },
            { 1, '1' },
            { 3, '3' },
            { 4, '4' },
            { 5, '5' },
            { 6, '6' },
            { 7, '7' },
            { 8, '8' },
            { 9, '9' },
            { 10, 'A' },
            { 11, 'B' },
            { 12, 'C' },
            { 13, 'D' },
            { 14, 'E' },
            { 15, 'F' },
    };

    private static readonly Dictionary<char, BigInteger> CharToDigit = new Dictionary<char, BigInteger>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 },
        };

    public static void Main()
    {
        int inputBase = int.Parse(Console.ReadLine());
        string input = Console.ReadLine().ToUpper();
        int outputBase = int.Parse(Console.ReadLine());
        Console.WriteLine(DecimalToBaseN(BaseNToDecimal(input, inputBase), outputBase));
    }

    public static BigInteger BaseNToDecimal(string input, int inputNumSystem)
    {
        BigInteger sum = 0;
        foreach (char item in input)
        {
            sum = CharToDigit[item] + (sum * inputNumSystem);
        }

        return sum;
    }

    private static string DecimalToBaseN(BigInteger decValue, int outputBase)
    {
        string result = string.Empty;

        do
        {
            BigInteger reminder = decValue % outputBase;
            result = DigitToChar[reminder] + result;
            decValue /= outputBase;
        }
        while (decValue > 0);

        return result;
    }
}