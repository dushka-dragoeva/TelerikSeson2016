using System;

/// Write a program that reads a string from the console and prints all different 
/// letters in the string along with information how many times each letter is found.
public class LettersCount
{
    public static void Main(string[] args)
    {
        /// Console.WriteLine("Enter text:");
        /// string input = Console.ReadLine();
        string input = @" Sofia is the capital and largest city of Bulgaria. The city is located at the foot of Vitosha Mountain 
                        in the western part of the country. It occupies a strategic position at the centre of the Balkan Peninsula.
                        Sofia is the 15th largest city in the European Union with population of around 1.3 million people. 
                        Many of the major universities, cultural institutions and commercial companies of Bulgaria are concentrated in Sofia.";

        char[] letters = new char[255];

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]))
            {
                letters[input[i]]++;
            }
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (char.IsLetter((char)i) && letters[i] > 0)
            {
                Console.WriteLine("{0} - {1} times", (char)i, (int)letters[i]);
            }
        }
    }
}