/* Write a program that compares two char arrays lexicographically (letter by letter)
    Print < if the first array is lexicographically smaller
    Print > if the second array is lexicographically smaller
    Print = if the arrays are equal*/
using System;

public class CompareCharArrays
{
    public static void Main()
    {
        string arrA = Console.ReadLine();
        string arrB = Console.ReadLine();

        bool areEqual = true;
        string result = string.Empty;

        var length = Math.Min(arrA.Length, arrB.Length);

        {
            for (int i = 0; i < length; i++)
            {
                if (arrA[i] != arrB[i])
                {
                    areEqual = false;
                    result = (arrA[i] < arrB[i]) ? "<" : ">";
                    break;
                }
                else
                {
                    if (arrA.Length != arrB.Length)
                    {
                        areEqual = false;
                        result = (arrA.Length < arrB.Length) ? "<" : ">";
                    }
                }
            }
        }

        Console.WriteLine(areEqual ? "=" : result);
    }
}
