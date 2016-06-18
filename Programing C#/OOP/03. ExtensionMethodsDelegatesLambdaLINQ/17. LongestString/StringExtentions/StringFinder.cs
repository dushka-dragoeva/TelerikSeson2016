namespace LongestString.StringExtentions
{
    using System.Linq;

    public static class StringFinder
    {
        public static string FindLongestString(this string[] words)
        {
            return words.OrderByDescending(w => w.Length).FirstOrDefault();
        }
    }
}
