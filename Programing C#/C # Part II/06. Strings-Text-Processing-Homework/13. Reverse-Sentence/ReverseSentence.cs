using System;
using System.Linq;

public class ReverseSentence
{
    private static readonly char[] Punctuation = new char[]
       {
                '.',
                ',',
                '!',
                '?',
                ':',
                ';',
       };

    public static void Main(string[] args)
    {
        var sentence = Console.ReadLine();
        Console.WriteLine(ReverseWords(sentence));
    }

    private static string ReverseWords(string sentence)
    {
        var words = sentence.Split(' ');

        for (int i = 0; i < (words.Length / 2); i++)
        {
            var firsttWord = words[i];
            char firsttWordLastChar = firsttWord[firsttWord.Length - 1];
            var secondWord = words[words.Length - 1 - i];
            char secondWordLastChar = secondWord[secondWord.Length - 1];

            if (IsLastCharPunctuation(firsttWord) && IsLastCharPunctuation(secondWord))
            {
                firsttWord = firsttWord.Substring(0, firsttWord.Length - 1) + secondWordLastChar;
                secondWord = secondWord.Substring(0, secondWord.Length - 1) + firsttWordLastChar;
            }
            else if (IsLastCharPunctuation(firsttWord))
            {
                firsttWord = firsttWord.Substring(0, firsttWord.Length - 1);
                secondWord = secondWord + firsttWordLastChar;
            }
            else if (IsLastCharPunctuation(secondWord))
            {
                firsttWord = firsttWord + secondWordLastChar;
                secondWord = secondWord.Substring(0, secondWord.Length - 1);
            }

            words[i] = secondWord;
            words[words.Length - 1 - i] = firsttWord;
        }

        var reversedSentence = string.Join(" ", words);

        return reversedSentence;
    }

    private static bool IsLastCharPunctuation(string word)
    {
        bool isPunctuation = false;
        var lastChar = word[word.Length - 1];

        if (Punctuation.Contains(lastChar))
        {
            isPunctuation = true;
        }

        return isPunctuation;
    }
}
