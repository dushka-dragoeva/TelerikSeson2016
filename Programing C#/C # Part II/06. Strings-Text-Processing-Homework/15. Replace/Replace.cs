using System;
using System.Collections.Generic;
using System.Text;
/*<p>Please visit <a href="http://academy.telerik.com">our site</a> 
 * to choose a training course. Also visit <a href="www.devbg.org">our 
 * forum</a> to discuss the courses.</p>;
 * 
 * <p>Please visit [our site]
 * (http://academy.telerik.com) 
 * 
 * to choose a training course. Also visit [our forum](www.devbg.org) 
 * to discuss the courses.</p>
*/
public class Replace
{
    private const string OpenTagBegining = "<a href=";
    private const int OpenTagBeginLength = 9;
    private const string OpenTagEnd = ">";
    private const int OpenTagEndLength = 2;
    private const string CloseTag = "</a>";
    private const int CloseTagLength = 4;

    public static void Main(string[] args)
    {
        var htmlDocument = Console.ReadLine();
        //// var htmlDocument = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a>";

        var indexes = FindAnchorTagsIndexes(htmlDocument);
        var parsedHtml = new StringBuilder();

        for (int i = 0; i < indexes.Count; i += 3)
        {
            if (i == 0)
            {
                parsedHtml.Append(htmlDocument.Substring(0, indexes[i]));
            }
            else if (i < indexes.Count - 1)
            {
                int startTextIndex = indexes[i - 1] + CloseTagLength;
                int endTextIndex = indexes[i];

                parsedHtml.Append(htmlDocument.Substring(startTextIndex, endTextIndex - startTextIndex));
            }

            var urlName = htmlDocument.Substring(indexes[i + 1] + 1, indexes[i + 2] - indexes[i + 1] - 1);
            parsedHtml.AppendFormat("[{0}]", urlName);

            int startUrlIndex = indexes[i] + OpenTagBeginLength;
            int endIUrlndex = indexes[i + 1];
            int urlLength = endIUrlndex - startUrlIndex - 1;
            var url = htmlDocument.Substring(startUrlIndex, urlLength);
            parsedHtml.AppendFormat("({0})", url);
        }

        int lastCloseTagEndIndex = indexes[indexes.Count - 1] + CloseTagLength - 1;
        if (lastCloseTagEndIndex < htmlDocument.Length)
        {
            parsedHtml.Append(htmlDocument.Substring(lastCloseTagEndIndex + 1));
        }

        Console.WriteLine(parsedHtml);
    }

    /// <summary>
    /// A method that finds indexes of anchor tag
    /// </summary>
    /// <param name="html">text html for parsing </param>
    /// <returns>List of indexes - 
    /// 1. start index of open tag
    /// 2. end index of open tag
    /// 3. start index of close tag
    /// </returns>
    private static List<int> FindAnchorTagsIndexes(string html)
    {
        var indexes = new List<int>();

        var nextOpenTagStart = html.IndexOf(OpenTagBegining);
        var nextOpenTagEnd = html.IndexOf(OpenTagEnd, nextOpenTagStart);
        var nextCloseTagStart = html.IndexOf(CloseTag);

        while (nextOpenTagStart != -1 && nextOpenTagEnd != -1)
        {
            indexes.Add(nextOpenTagStart);
            indexes.Add(nextOpenTagEnd);

            nextCloseTagStart = html.IndexOf(CloseTag, nextOpenTagEnd);
            indexes.Add(nextCloseTagStart);

            nextOpenTagStart = html.IndexOf(OpenTagBegining, nextCloseTagStart + 1);
            if (nextOpenTagStart != -1)
            {
                nextOpenTagEnd = html.IndexOf(OpenTagEnd, nextOpenTagStart);
            }
        }

        return indexes;
    }
}
