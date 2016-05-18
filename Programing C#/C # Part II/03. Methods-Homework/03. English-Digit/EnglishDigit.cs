using System;

public class EnglishDigit
{
    public static void Main()
    {
        var number = Console.ReadLine();
        Console.WriteLine(LastDigitInEnglish(number));
    }

    private static string LastDigitInEnglish(string number)
    {
        var englishWord = string.Empty;

        var lastDigit = number[number.Length - 1] - '0';
        switch (lastDigit)
        {
            case 0:
                englishWord = "zero";
                break;
            case 1:
                englishWord = "one";
                break;
            case 2:
                englishWord = "two";
                break;
            case 3:
                englishWord = "three";
                break;
            case 4:
                englishWord = "four";
                break;
            case 5:
                englishWord = "five";
                break;
            case 6:
                englishWord = "six";
                break;
            case 7:
                englishWord = "seven";
                break;
            case 8:
                englishWord = "eight";
                break;
            case 9:
                englishWord = "nine";
                break;
        }

        return englishWord;
    }
}