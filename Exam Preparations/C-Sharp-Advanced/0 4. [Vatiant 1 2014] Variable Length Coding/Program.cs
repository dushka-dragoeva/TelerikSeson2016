using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var binarNumbers = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Select(x => Convert.ToString(x, 2).ToString().PadLeft(8, '0'))
           .ToArray();

        var binaryString = string.Join(string.Empty, binarNumbers);

        int length = int.Parse(Console.ReadLine());

        var codes = new Dictionary<byte, char>();

        for (int i = 0; i < length; i++)
        {
            var currentCode = Console.ReadLine();

            var key = byte.Parse(currentCode.Substring(1));
            codes[key] = currentCode.Substring(0, 1)[0];
        }

        //// Replace zeros of string with space
        var text = binaryString.Replace('0', ' ')
            .Trim()
            .Split(' ')
            .Select(x => x.Length)
            .ToArray();

        var encodedText = new StringBuilder();

        foreach (var item in text)
        {
            var key = (byte)item;
            encodedText.Append(codes[key]);
        }

        Console.WriteLine(encodedText);
    }
}
