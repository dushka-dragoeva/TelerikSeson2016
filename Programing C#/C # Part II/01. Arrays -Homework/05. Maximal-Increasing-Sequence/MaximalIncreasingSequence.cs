/// Write a program that finds the length of the maximal increasing sequence in an 
/// array of N integers.
using System;

public class MaximalIncreasingSequence
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        long [] arr = new long[length];

        for (int i = 0; i < length; i++)
        {
            arr[i] = long.Parse(Console.ReadLine());
        }

        int maxSequence = 0;
        int currentSequence = 1;
        long startSequenceNumber = arr[0];

        for (int i = 1; i < length; i++)
        {
           ;
            if (arr[i] > startSequenceNumber )
            {
                currentSequence ++;
            }
            else
            {
                maxSequence = Math.Max(maxSequence, currentSequence);
                currentSequence = 1;
                startSequenceNumber = arr[i];
            }
        }

        if (currentSequence > maxSequence)
        {
            maxSequence = currentSequence;
        }

        Console.WriteLine(maxSequence);
    }
}
