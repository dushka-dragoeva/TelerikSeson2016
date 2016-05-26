using System;
using System.Linq;
using System.Text;

public class ExtractSentences
{
    public static void Main(string[] args)
    {
        var word = Console.ReadLine();
        var text = Console.ReadLine();
        Console.WriteLine(ExtratSentencesFromText(text, word));
    }

    private static string ExtratSentencesFromText(string text, string wordToFind)
    {
        var extractedText = new StringBuilder();

        var allSentense = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();
        for (int i = 0; i < allSentense.Length; i++)
        {
            if (FindWordInSentance(allSentense[i], wordToFind))
            {
                extractedText.Append(allSentense[i]);
                extractedText.Append('.');

                if (i < allSentense.Length)
                {
                    extractedText.Append(" ");
                }
            }
        }

        return extractedText.ToString().Trim();
    }

    private static bool FindWordInSentance(string sentance, string word)
    {
        bool isFind = false;
        var nextIndexOfWord = sentance.IndexOf(word);

        var lastIndex = sentance.Length - word.Length;

        while (nextIndexOfWord > -1)
        {
            if (nextIndexOfWord != 0 &&
              ((char.IsLetter(sentance[nextIndexOfWord - 1])) ||
               (sentance[nextIndexOfWord - 1] == '-')))
            {
                nextIndexOfWord = sentance.IndexOf(word, nextIndexOfWord + 1);
            }
            else if (nextIndexOfWord < lastIndex &&
                ((char.IsLetter(sentance[nextIndexOfWord + word.Length]) ||
                (sentance[nextIndexOfWord + word.Length] == '-'))))
            {
                nextIndexOfWord = sentance.IndexOf(word, nextIndexOfWord + 1);
            }
            else
            {
                isFind = true;
                break;
            }
        }

        return isFind;
    }
}