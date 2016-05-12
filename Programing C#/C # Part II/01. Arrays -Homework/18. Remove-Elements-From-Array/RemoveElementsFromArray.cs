using System;
using System.Collections.Generic;

public class RemoveElementsFromArray
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();

        AddNumbersToList(n, numbers);
        int[] subsetLength = new int[numbers.Count];

        //// Define each number as subsequence.
        for (int i = 0; i < numbers.Count; i++)
        {
            subsetLength[i] = 1;
        }

        int maxSubset = 1;

        //// Compare current number with the numbers before.
        for (int i = 1; i < numbers.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] >= numbers[j] && subsetLength[i] <= subsetLength[j] + 1)
                {
                    subsetLength[i] = subsetLength[j] + 1;
                    //// Update max increasing subsequence.
                    maxSubset=Math.Max(maxSubset,subsetLength[i]);
                }
            }
        }

        //// Print numbers to remove as a result.
        int numbersToRemove = n - maxSubset;
        Console.WriteLine(numbersToRemove);
    }

    private static void AddNumbersToList(int n, List<int> numbers)
    {
        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            numbers.Add(currentNumber);
        }
    }
}