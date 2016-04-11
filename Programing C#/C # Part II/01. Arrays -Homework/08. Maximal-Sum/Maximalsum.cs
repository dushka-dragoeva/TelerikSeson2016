/// Write a program that finds the maximal sum of consecutive elements in 
/// a given array of N numbers.
using System;

public class Maximalsum
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];

        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int currentSum = arr[0];
        int bestSum = 0;

        for (int i = 1; i < length - 1; i++)
        {
            if (arr[i ] + arr[i+1] >= currentSum)
            {
                currentSum += arr[i+1];
            }
            else
            {
                currentSum = arr[i+1];
            }
            
            if (currentSum > bestSum)
            {
                bestSum = currentSum;
            }
        }

        Console.WriteLine(bestSum);
    }
}
