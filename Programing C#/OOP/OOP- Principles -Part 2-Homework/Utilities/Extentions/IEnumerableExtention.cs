namespace Utilities.Extentions
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtention
    {
        public static void PrintCollection<T>(this IEnumerable<T> collection)
        {
            Console.WriteLine(string.Join("\n", collection));
        }
    }
}
