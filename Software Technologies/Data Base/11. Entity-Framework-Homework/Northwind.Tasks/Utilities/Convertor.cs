using System.Globalization;

namespace Northwind.Tasks.Utilities
{
    internal class Convertor
    {
        internal static string FirstLetterToUpper(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
