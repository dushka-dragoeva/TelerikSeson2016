using System;
using System.Collections.Generic;

public class HexadecimalToBinary
{
    private static readonly Dictionary<char, string> HexadecimalToBin = new Dictionary<char, string>()
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };

    public static void Main()
    {
        var hexNumber = Console.ReadLine();
        Console.WriteLine(ConvertHexToBinary(hexNumber));
    }

    private static string ConvertHexToBinary(string hex)
    {
        string[] binary = new string[hex.Length];

        for (int i = 0; i < hex.Length; i++)
        {
            var key = hex[i];
            binary[i] = HexadecimalToBin[key];
        }

        string binaryNumber = string.Join(string.Empty, binary);
        var index = binaryNumber.IndexOf('1');
        if (index > 0)
        {
            binaryNumber = binaryNumber.Substring(index);
        }

        return binaryNumber;
    }
}
