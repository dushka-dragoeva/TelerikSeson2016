namespace Replace2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReplaceTags
    {
        private const string OpenTagBegining = "<a";
        private const string OpenTagEnd = ">";
        private const string CloseTag = "</a>";
        private const int CloseTagLength = 4;
        private const string HrefAtribute = "href=\"";
        private const int HrefAtributeLength = 6;
        private const string DoubleQuotes = "\"";

        public static void Main(string[] args)
        {
            var htmlDocument = Console.ReadLine();
            /// var htmlDocument = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

            var indexes = FindAnchorTagsIndexes(htmlDocument);

            var parsedHtml = new StringBuilder();

            for (int i = 0; i < indexes.Count - 4; i += 5)
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

                var urlNameStart = indexes[i + 3] + 1;
                var urlNameLength = indexes[i + 4] - urlNameStart;
                var urlName = htmlDocument.Substring(urlNameStart, urlNameLength);
                parsedHtml.AppendFormat("[{0}]", urlName);

                int urlStart = indexes[i + 1] + HrefAtributeLength;
                int urlEnd = indexes[i + 2];
                int urlLength = urlEnd - urlStart;
                var url = htmlDocument.Substring(urlStart, urlLength);
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
        /// 0. Start index of open tag
        /// 1. Index of open " of url
        /// 2. End index of open a tag 
        /// 3. Index of close " of url
        /// 4. start index of close tag
        /// </returns>
        private static List<int> FindAnchorTagsIndexes(string html)
        {
            var indexes = new List<int>();

            var nextOpenTagStart = html.IndexOf(OpenTagBegining);
            var nextHrefStart = 0;
            var nextCloseDoubleQуоtes = 0;
            var nextOpenTagEnd = 0;
            var nextCloseTagStart = 0;

            while (nextOpenTagStart != -1)
            {
                indexes.Add(nextOpenTagStart);

                nextHrefStart = html.IndexOf(HrefAtribute, nextOpenTagStart + 1);
                indexes.Add(nextHrefStart);

                nextCloseDoubleQуоtes = html.IndexOf(DoubleQuotes, nextHrefStart + HrefAtributeLength + 1);
                indexes.Add(nextCloseDoubleQуоtes);

                nextOpenTagEnd = html.IndexOf(OpenTagEnd, nextCloseDoubleQуоtes);
                indexes.Add(nextOpenTagEnd);

                nextCloseTagStart = html.IndexOf(CloseTag, nextOpenTagEnd);
                indexes.Add(nextCloseTagStart);

                nextOpenTagStart = html.IndexOf(OpenTagBegining, nextCloseTagStart + CloseTagLength);
            }

            return indexes;
        }
    }
}
