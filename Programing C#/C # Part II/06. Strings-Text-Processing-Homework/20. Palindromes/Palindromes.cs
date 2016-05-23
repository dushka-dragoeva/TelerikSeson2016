using System;
using System.Collections.Generic;

public class Palindromes
{
    public static void Main(string[] args)
    {
        var text = Console.ReadLine();

        var palindromas = FindAllPalindromes(text);
        Console.WriteLine(string.Join("\n", palindromas));
    }

    private static List<string> FindAllPalindromes(string text)
    {
        var palindromas = new List<string>();

        var words = text.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '\'', '\"', '-' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (IsPalindrom(word))
            {
                palindromas.Add(word);
            }
        }

        return palindromas;
    }

    private static bool IsPalindrom(string word)
    {
        bool isPalindrome = true;

        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                isPalindrome = false;
                break;
            }
        }

        return isPalindrome;
    }
}
