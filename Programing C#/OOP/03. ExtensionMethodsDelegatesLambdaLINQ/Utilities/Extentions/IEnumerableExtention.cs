namespace Utilities.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class IEnumerableExtention
    {
        public static void PrintCollection<T>(this IEnumerable<T> numbers)
            where T : struct
        {
            Console.ForegroundColor = ConsoleColor.White;
            var result = new StringBuilder();
            result.Append("[ ");

            foreach (var num in numbers)
            {
                result.Append(num);
                result.Append(" ");
            }

            result.Append("]");

            Console.WriteLine(result);
        }
    }
}
