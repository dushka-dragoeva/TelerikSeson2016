/// Write a program that reads two integer arrays of size N from the console and compares them element by element.
using System;

public class CompareArrays
{
    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());

        int[] arrA = new int[length];
        int[] arrB = new int[length];

        bool isEqual = false;

        for (int i = 0; i < 2 * length; i++)
        {
            if (i < length)
            {
                arrA[i] = int.Parse(Console.ReadLine());
            }
            else
            {
                arrB[i - length] = int.Parse(Console.ReadLine());
                if (arrB[i - length] == arrA[i - length])
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                }
            }
        }

        var result = isEqual ? "Equal" : "Not equal";
        Console.WriteLine(result);
    }
}
