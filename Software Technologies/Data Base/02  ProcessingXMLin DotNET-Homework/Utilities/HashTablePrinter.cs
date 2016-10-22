using System;
using System.Collections;

namespace Utilities
{
    public class HashTablePrinter
    {
        public static void Print(Hashtable dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                Console.WriteLine($"{entry.Key}, {entry.Value}");
            }
        }
    }
}