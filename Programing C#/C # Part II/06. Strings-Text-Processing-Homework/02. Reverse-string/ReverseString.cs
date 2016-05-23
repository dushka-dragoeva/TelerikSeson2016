using System;
using System.Text;

public class ReverseString
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        StringBuilder reversedString = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            reversedString.Insert(0, input[i]);
        }

        Console.WriteLine(reversedString.ToString());
    }
}