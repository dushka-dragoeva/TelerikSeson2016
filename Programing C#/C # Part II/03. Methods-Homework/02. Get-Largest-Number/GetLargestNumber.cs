using System;
using System.Linq;

public class GetLargestNumber
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var maxNumber = GetMax(numbers[0], numbers[1]);
        maxNumber = GetMax(maxNumber, numbers[2]);

        Console.WriteLine(maxNumber);
    }

    private static int GetMax(int first, int second)
    {
        if (first >= second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
}
