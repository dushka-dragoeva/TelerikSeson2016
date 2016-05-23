using System;
using System.Text;

public class SeriesOfLetters
{
    public static void Main()
    {
        var input = Console.ReadLine();
        Console.WriteLine(RemoveRepetingLetters(input));
    }

    private static string RemoveRepetingLetters(string text)
    {
        var compressed = new StringBuilder();

        for (int i = 1; i < text.Length; i++)
        {
            if (text[i - 1] == text[i])
            {
                continue;
            }
            else
            {
                compressed.Append(text[i - 1]);
            }
        }

        var lastIndex = text.Length - 1;
        compressed.Append(text[lastIndex]);

        return compressed.ToString();
    }

    private static string CompressLetters(string text)
    {
        var compressed = new StringBuilder();
        compressed.Append(text[0]);

        foreach (var letter in text)
        {
            var lastLetter = text[text.Length - 1];

            if (letter == lastLetter)
            {
                continue;
            }
            else
            {
                compressed.Append(letter);
            }
        }

        return compressed.ToString();
    }
}
