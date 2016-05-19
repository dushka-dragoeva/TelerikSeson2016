using System;
using System.Linq;

public class SumIntegers
{
    public static void Main(string[] args)
    {
        var numbers = ReadInput(Console.ReadLine());
        var sum = CalculateSum(numbers);
        Console.WriteLine(sum);
    }

    private static int CalculateSum(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    private static int[] ReadInput(string input)
    {
        int[] integers = input.Split(' ').Select(int.Parse).ToArray();
        return integers;
    }
}
