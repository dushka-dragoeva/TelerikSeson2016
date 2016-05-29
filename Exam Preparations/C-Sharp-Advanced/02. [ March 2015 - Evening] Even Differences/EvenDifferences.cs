using System;
using System.Linq;

public class EvenDifferences
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        long evenDiffrencesSum = 0;

        for (int i = 1; i < input.Length; i++)
        {
           long abcoluteDifference = Math.Abs(input[i] - input[i - 1]);
            if (abcoluteDifference % 2 == 0)
            {
                i++;
                evenDiffrencesSum += abcoluteDifference;
            }
        }

        Console.WriteLine(evenDiffrencesSum);
    }
}
