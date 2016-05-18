using System;
using System.Collections.Generic;
using System.Linq;

public class AddingPolynomial
{
    public static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        var first = Console.ReadLine();
        var second = Console.ReadLine();

        var sum = SumOfArrays(first, second, length);

        Console.WriteLine(string.Join(" ", sum));
    }

    private static List<int> SumOfArrays(string first, string second, int length)
    {
        int[] firstNumber = ConvertToArray(first);
        int[] secondNumber = ConvertToArray(second);

        List<int> sum = new List<int>();

        for (int i = 0; i < length; i++)
        {
            var temp = firstNumber[i] + secondNumber[i];
            sum.Add(temp);
        }

        return sum;
    }

    private static int[] ConvertToArray(string number)
    {
        int[] num = number
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        return num;
    }
}