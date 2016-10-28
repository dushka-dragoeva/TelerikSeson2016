using System.Text.RegularExpressions;

namespace Decorator.Utilities
{
    public class StringUtilities
    {
        public static string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }
}
