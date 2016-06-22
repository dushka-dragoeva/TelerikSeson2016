namespace LongestString.StringExtentions
{
    using System.Linq;

    public static class StringExtention
    {
        public static string FindLongestString(this string[] words)
        {
            var sortedWords = from word in words
                              orderby word.Length descending
                              select word;
            return sortedWords.ToArray()[0];

           ///  return words.OrderByDescending(w => w.Length).FirstOrDefault();
        }
    }
}
