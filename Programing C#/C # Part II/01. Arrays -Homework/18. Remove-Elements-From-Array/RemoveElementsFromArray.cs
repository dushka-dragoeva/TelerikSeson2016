using System;
using System.Linq;
using System.Collections.Generic;

public class RemoveElementsFromArray
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        int[] indexes = new int[length + 1];

        for (int i = 0; i < length; i++)
        {
            numbers[i] = (int.Parse(Console.ReadLine()));
            indexes[i] = 1;
        }

        indexes[length] = 1;

        var maxSequence = 0;
        var currentSequence = 1;

        for (int i = 0; i < length-2; i++)
        {
            for (int j = i + 1; j < length-1; j++)
            {
                
                if (numbers[i] <= numbers[j]&&numbers[j]<=numbers[j+1])
                {
                    currentSequence++;
                }

                if (j == length - 1)
                {
                    currentSequence++;
                }
            }
            indexes[i] = currentSequence;
                        currentSequence = 1;
        }



        maxSequence = indexes.OrderByDescending(x => x).ToArray()[0];
        Console.WriteLine(length - maxSequence);
    }
}