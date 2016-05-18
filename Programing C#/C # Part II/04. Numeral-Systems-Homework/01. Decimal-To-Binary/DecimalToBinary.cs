using System;
using System.Text;

public class DecimalToBinary
{
    public static void Main(string[] args)
    {
        var num = long.Parse(Console.ReadLine());
        var result = ConvertToBynary(num);
        Console.WriteLine(result);
    }

    private static string ConvertToBynary(long number)
    {
        StringBuilder binary = new StringBuilder();
        while (number > 0)
        {
            var digit = number % 2;
            binary.Insert(0, digit);
            number = number / 2;
        }

        return binary.ToString();
    }
}