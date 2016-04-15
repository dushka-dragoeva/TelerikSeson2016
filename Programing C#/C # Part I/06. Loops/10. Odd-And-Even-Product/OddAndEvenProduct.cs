/// You are given N integers (given in a single line, separated by a space).
/// Write a program that checks whether the product of the odd elements is equal to the product of the
/// even elements.Elements are counted from 1 to N, so the first element is odd, the second is even, etc.
using System;
using System.Linq;

public class OddAndEvenProduct
{
    public static void Main()
    {
        int lenght = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int[] numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        long oddProduct = 1;
        long evenProduct = 1;

        for (int i = 1; i <= numbers.Length; i = i + 2)
        {
            oddProduct *= numbers[i];
            if (i < numbers.Length - 1)
            {
                evenProduct *= numbers[i + 1];
            }
        }

        var output = oddProduct == evenProduct ? string.Format("yes {0}", oddProduct) : string.Format("no {0} {1}", oddProduct, evenProduct);
        Console.WriteLine(output);
    }
}
