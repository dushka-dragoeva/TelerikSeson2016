using System;
using System.Globalization;
using System.Text;
using System.Threading;

public class ExtractSentences
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture =
  CultureInfo.InvariantCulture;
        var word = Console.ReadLine();
        var text = Console.ReadLine();

        Console.WriteLine(ExtratSentencesFromText(text, word));
    }

    private static string ExtratSentencesFromText(string text, string wordToFind)
    {
        var extractedText = new StringBuilder();
        wordToFind = wordToFind.ToLower();

        var allSentense = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < allSentense.Length; i++)
        {
            ////foreach (string word in allSentense[i].Split(' '))
            ////{
            ////    if (word.Trim(',', ';', ':','2',' ').ToLower() == wordToFind.ToLower())
            ////    {
            ////        extractedText.Append(allSentense[i]);
            ////        extractedText.Append('.');
            ////        break;
            ////    }
            ////}

            if (wordToFind.ToLower() == allSentense[i].ToLower())
            {
                extractedText.Append(allSentense[i]);
                extractedText.Append('.');
                break;
            }
            else if (wordToFind.Length >= allSentense[i].Length)
            {
                continue;
            }

            var nextStartIndex = allSentense[i].ToLower().IndexOf(wordToFind);

            while (nextStartIndex != -1)
            {
                var currentIndex = nextStartIndex;
                var tempStart = 0;
                var tempEnd = 0;
                char symbolBefore = '0';
                char symbolAfter = '0';

                if (currentIndex == 0)
                {
                    tempEnd = currentIndex + wordToFind.Length;
                    symbolAfter = allSentense[i][tempEnd];
                }
                else if (currentIndex + wordToFind.Length - 1 == allSentense[i].Length - 1)
                {
                    tempStart = currentIndex - 1;
                    symbolBefore = allSentense[i][tempStart];
                }
                else
                {
                    tempStart = currentIndex - 1;
                    tempEnd = currentIndex + wordToFind.Length;
                    symbolBefore = allSentense[i][tempStart];
                    symbolAfter = allSentense[i][tempEnd];
                }

                if (!char.IsLetter(symbolBefore) && !char.IsLetter(symbolAfter))
                {
                    extractedText.Append(allSentense[i]);
                    extractedText.Append('.');
                    break;
                }

                if (currentIndex + wordToFind.Length - 1 < allSentense[i].Length)
                {
                    nextStartIndex = allSentense[i].ToLower().IndexOf(wordToFind, currentIndex + 1);
                }
                else
                {
                    break;
                }
            }
        }

        return extractedText.ToString();
    }
}
