using System;
using System.Collections.Generic;
using System.Linq;

public class EnterNumbers
{
    public static void Main()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        PrintIfSorted(0, 100, numbers);
    }

    private static void PrintIfSorted(int start, int end, IList<int> numbers)
    {
        try
        {
            if (!IsSorted(numbers) || numbers.Any(x => x < start) || numbers.Any(x => x > end))
            {
                throw new ArgumentException();
            }

            Console.WriteLine("1 < " + string.Join(" < ", numbers) + " < 100");
        }
        catch (Exception)
        {
            Console.WriteLine("Exception");
        }
    }

    private static bool IsSorted<T>(IList<T> numbers)
        where T : IComparable
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i - 1].CompareTo(numbers[i]) != -1)
            {
                return false;
            }
        }

        return true;
    }
}
