using System;
using System.Collections.Generic;
using System.Linq;

public class NumberAsArray
{
   public static void Main()
    {
        var input = ConvertToArray(Console.ReadLine());

        var maxLenght = Math.Max(input[0], input[1]);

        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();

        var sumOfTowArrays = SumOfArrays(firstNumber, secondNumber, maxLenght);

        Console.WriteLine(string.Join(" ", sumOfTowArrays));
    }

    private static List<int> SumOfArrays(string first, string second, int length)
    {
        int[] firstNumber = new int[length];
        int[] secondNumber = new int[length];

        if (first.Length == second.Length)
        {
            firstNumber = ConvertToArray(first);
            secondNumber = ConvertToArray(second);
        }
        else if (first.Length < second.Length)
        {
            firstNumber = DeepCopy(ConvertToArray(first), length);
            secondNumber = ConvertToArray(second);
        }
        else
        {
            firstNumber = ConvertToArray(first);
            secondNumber = DeepCopy(ConvertToArray(second), length);
        }

        List<int> sum = new List<int>();

        for (int i = 0; i < length; i++)
        {
            var temp = firstNumber[i] + secondNumber[i];

            if (temp >= 10)
            {
                sum.Add(temp % 10);

                if (i < length - 1)
                {
                    firstNumber[i + 1]++;
                }
                else
                {
                    sum.Add(1);
                }
            }
            else
            {
                sum.Add(temp);
            }
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

    private static int[] DeepCopy(int[] arr, int length)
    {
        int[] copiedArr = new int[length];

        for (int i = 0; i < arr.Length; i++)
        {
            copiedArr[i] = arr[i];
        }

        return copiedArr;
    }
}
