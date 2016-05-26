using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EvenDifferences
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList<int>();

        var evenDiffrencesSum = 0;

        for (int i = 1; i < input.Count-1; i++)
        {
            var abcoluteDifference = Math.Abs(input[i] - input[i - 1]);
            var step = 0;
            if (abcoluteDifference % 2 == 0)
            {
                step = 2;
                evenDiffrencesSum += abcoluteDifference;
            }
            else
            {
                step = 1;
            }
            if (i + step < input.Count)
            {
                Move(ref input, step, i);
            }
            else
            {
                continue;
            }
           Console.WriteLine(abcoluteDifference);
           Console.WriteLine(string.Join(", ", input));
        }

        Console.WriteLine(evenDiffrencesSum);
    }

    private static void Move(ref List<int> numbers, int step, int index)
    {
        var current = numbers[index];
        numbers.Remove(numbers[index]);
        numbers.Insert(index + step, current);
    }
}
