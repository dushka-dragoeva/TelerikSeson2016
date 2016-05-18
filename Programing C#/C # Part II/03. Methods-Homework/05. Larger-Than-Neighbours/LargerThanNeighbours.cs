using System;
using System.Linq;

public class LargerThanNeighbours
{
    public static void Main(string[] args)
    {
        var length = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var counter = CountBiggerThanNeighbours(arr);

        Console.WriteLine(counter);
    }

    private static int CountBiggerThanNeighbours(int[] numbers)
    {
        var counter = 0;

        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
            {
                counter++;
            }
        }

        return counter;
    }
}