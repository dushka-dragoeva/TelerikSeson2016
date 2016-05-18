using System;
using System.Linq;

public class FirstLargerThanNeighbours
{
    public static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var index = FirstLrgerThanNeighbours(arr);

        Console.WriteLine(index);
    }

    private static int FirstLrgerThanNeighbours(int[] numbers)
    {
        var index = -1;

        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
            {
                index = i;
                break;
            }
        }

        return index;
    }
}