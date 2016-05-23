using System;
using System.Collections.Generic;

/// Write a program that reads a string from the console and lists all different 
/// words in the string along with information how many times each word is found.
public class WordsCount
{
    public static void Main()
    {
        /// Console.WriteLine("Enter text:");
        /// string input = Console.ReadLine();
        string input = "Sofia is the capital and largest city of Bulgaria. The city is located at the foot of Vitosha Mountain. Sofia, Sofia,";

        string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

        var dictunary = new SortedDictionary<string, int>();
        foreach (var word in words)
        {
            if (dictunary.ContainsKey(word))
            {
                dictunary[word]++;
            }
            else
            {
                dictunary.Add(word, 1);
            }
        }

        foreach (var word in dictunary)
        {
            Console.WriteLine("{0} - {1} times", word.Key, word.Value);
        }
    }
}