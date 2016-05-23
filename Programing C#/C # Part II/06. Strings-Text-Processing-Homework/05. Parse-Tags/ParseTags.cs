using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private const string StartTag = "<upcase>";
    private const string EndTag = "</upcase>";

    public static void Main(string[] args)
    {
        var text = Console.ReadLine();
        var indexes = FindTextIndexesBetweenTwoTags(text, StartTag, EndTag);

        var newText = text.Split(new string[] { StartTag, EndTag }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(ChangeTextBetwenTagsToUpperCase(text, indexes, StartTag, EndTag));
    }

    private static List<int> FindTextIndexesBetweenTwoTags(string text, string startTag, string endTag)
    {
        List<int> indexes = new List<int>();
        int startTagLenth = startTag.Length;
        int endTagLenght = endTag.Length;
        int nextStartTagIndex = text.IndexOf(StartTag);
        int nextEndTagIndex = 0;

        while (nextStartTagIndex != -1 && nextEndTagIndex != -1)
        {
            indexes.Add(nextStartTagIndex + startTagLenth);
            nextEndTagIndex = text.IndexOf(EndTag, nextStartTagIndex + startTagLenth - 1);
            indexes.Add(nextEndTagIndex + endTagLenght);

            if (nextEndTagIndex + endTagLenght < text.Length)
            {
                nextStartTagIndex = text.IndexOf(startTag, nextEndTagIndex + endTagLenght - 1);
            }
            else
            {
                break;
            }
        }

        return indexes;
    }

    private static string ChangeTextBetwenTagsToUpperCase(string text, List<int> indexes, string startTag, string endTag)
    {
        var parsedText = new StringBuilder();

        var startIndex = 0; // last index  of startTag 
        var endIndex = 0; // last index of endTag
        if (indexes.Count > 0)
        {
            for (int i = 0; i < indexes.Count; i += 2)
            {
                startIndex = indexes[i];
                parsedText.Append(text.Substring(endIndex, startIndex - startTag.Length - endIndex));
                endIndex = indexes[i + 1];
                var upcaseLenght = endIndex - startIndex - endTag.Length;
                parsedText.Append(text.Substring(startIndex, upcaseLenght).ToUpper());
            }

            parsedText.Append(text.Substring(indexes[indexes.Count - 1]));
        }
        else
        {
            parsedText.Append(text);
        }

        return parsedText.ToString();
    }
}