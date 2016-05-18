using System;
using System.Linq;

public class AppearanceCount
{
    public static void Main(string[] args)
    {
        var length = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var numberToFind = int.Parse(Console.ReadLine());

        var counter = CountNumber(length, arr, numberToFind);

        Console.WriteLine(counter);
    }

    private static int CountNumber(int arrLength, int[] numbers, int x)
    {
        var counter = 0;

        for (int i = 0; i < arrLength; i++)
        {
            if (numbers[i] == x)
            {
                counter++;
            }
        }

        return counter;
    }
}