/// Write a program that creates an alphabetay containing all letters from the alphabet (a-z). 
/// Read a word from the console and print the index of each of its letters in the alphabetay.
using System;

public class Program
{
    public static int FindIndex(char[] alphabet, char letter)
    {
        int counter = 0;
        int startIndex = 0;
        int endIndex = alphabet.Length - 1;
        int midIndex = (endIndex - startIndex) / 2;
        int indexLetter = -1;

        while (true)
        {
            if (alphabet[midIndex] == letter)
            {
                indexLetter = midIndex;
                break;
            }
            else if (alphabet[midIndex] < letter)
            {
                startIndex = midIndex + 1;
                midIndex = (endIndex + startIndex) / 2;
                counter++;
            }
            else
            {
                endIndex = midIndex - 1;
                midIndex = (startIndex + endIndex) / 2;
                counter++;
            }
        }

        return indexLetter;
    }

    public static void Main(string[] args)
    {
        string input = Console.ReadLine().ToLower();

        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)(i + (int)'a');
        }

        foreach (var item in input)
        {
            Console.WriteLine(FindIndex(alphabet, item));
        }
    }
}
