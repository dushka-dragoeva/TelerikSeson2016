using System;
using System.Linq;

public class ReverseNumber
{
    public static void Main()
    {
        var number = Console.ReadLine();
        Console.WriteLine(GetReversedNumber(number));
    }

    private static string GetReversedNumber(string number)
    {
        var reversedNumber = number.ToCharArray();
        Array.Reverse(reversedNumber);
        return new string(reversedNumber);
    }
}