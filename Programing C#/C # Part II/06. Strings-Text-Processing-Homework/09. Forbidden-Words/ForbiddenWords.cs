using System;

public class ForbiddenWords
{
    public static void Main(string[] args)
    {
        var text = Console.ReadLine();
        var forbiddenWords = Console.ReadLine().Split(' ');
        Console.WriteLine(ReplaceForbiddenWords(text, forbiddenWords));
    }

    private static string ReplaceForbiddenWords(string text, string[] forbiddenWords)
    {
        foreach (var word in forbiddenWords)
        {
            text = text.Replace(word, new string('*', word.Length));
        }

        return text;
    }
}
