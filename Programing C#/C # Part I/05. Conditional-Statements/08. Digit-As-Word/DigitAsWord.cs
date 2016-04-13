/// Write a program that read a digit (0-9) from the console, and depending on the input, shows the digit as
/// a word (in English).Print "not a digit" in case of invalid input. Use a switch statement.
using System;
using System.Globalization;
using System.Threading;

public class DigitAsWord
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string input = Console.ReadLine();
        string digitAsWord = string.Empty;

        switch (input)
        {
            case "0": digitAsWord = "zero";
                break;
            case "1": digitAsWord = "one";
                break;
            case "2": digitAsWord = "two";
                break;
            case "3": digitAsWord = "three";
                break;
            case "4": digitAsWord = "four";
                break;
            case "5": digitAsWord = "five";
                break;
            case "6": digitAsWord = "six";
                break;
            case "7": digitAsWord = "seven";
                break;
            case "8": digitAsWord = "eight";
                break;
            case "9": digitAsWord = "nine";
                break;
            default: digitAsWord = "not a digit";
                break;
        }

        Console.WriteLine(digitAsWord);
    }
}
