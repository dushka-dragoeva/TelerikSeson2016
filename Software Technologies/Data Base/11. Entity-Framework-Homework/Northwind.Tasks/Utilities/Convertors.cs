using System.Globalization;

namespace Northwind.Tasks.Utilities
{
    public class Convertors
    {
        public static string FirstLetterToUpper(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
