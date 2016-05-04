/// Write a program that finds the length of the maximal increasing sequence in an 
using System;

public class MaximalIncreasingSequence
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
            if (arr[i] >= arr[i - 1] + 1)
            {
                var temp1 = arr[i - 1];
                var temp2 = arr[i];
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