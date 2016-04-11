/// Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.
using System;

public class MaximalSequence
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[] arr = new int[length];
        arr[0] = int.Parse(Console.ReadLine());
        int maxSequence = 0;
        int currentSequence = 1;

        for (int i = 1; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            if (arr[i] == arr[i - 1])
            {
                currentSequence += 1;
                maxSequence = Math.Max(maxSequence, currentSequence);
            }
            else
            {
                currentSequence = 1;
            }
        }

        Console.WriteLine(maxSequence);
    }
}
