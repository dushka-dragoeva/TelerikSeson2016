using System;
using System.Collections.Generic;
using System.Text;

public class BinaryToHexadecimal
{
    private static readonly Dictionary<string, char> BinToHex = new Dictionary<string, char>()
        {
            { "0000", '0' },
            { "0001", '1' },
            { "0010", '2' },
            { "0011", '3' },
            { "0100", '4' },
            { "0101", '5' },
            { "0110", '6' },
            { "0111", '7' },
            { "1000", '8' },
            { "1001", '9' },
            { "1010", 'A' },
            { "1011", 'B' },
            { "1100", 'C' },
            { "1101", 'D' },
            { "1110", 'E' },
            { "1111", 'F' }
        };

    public static void Main()
    {
        var hexNumber = Console.ReadLine();
        Console.WriteLine(ConvertBinaryToHex(hexNumber));
    }

    private static string ConvertBinaryToHex(string binary)
    {
        var missingZero = 4 - (binary.Length % 4);

        if (missingZero > 0)
        {
            for (int i = 0; i < missingZero; i++)
            {
                binary = binary.Insert(0, "0");
            }
        }

        StringBuilder hexNumber = new StringBuilder();
        for (int i = 0; i < binary.Length; i += 4)
        {
            var key = binary.Substring(i, 4);
            hexNumber.Append(BinToHex[key]);
        }

        var result = hexNumber.ToString().TrimStart(new char[] { '0' });
        return result;
    }
}
