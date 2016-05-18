////Write methods to calculate minimum, maximum, average, sum and product 
////of given set of integer numbers. Use variable number of arguments. 
////Write a program that reads 5 elements and prints their minimum, maximum, average, sum and product.

using System;
using System.Collections.Generic;
using System.Linq;

public class IntegerCalculations
{
    public static void Main()
    {
        var arr = ConvertToArray(Console.ReadLine());

        Console.WriteLine(GetMinNumber(arr));
        Console.WriteLine(GetMaxNumber(arr));
        Console.WriteLine("{0:F2}", GetAvarage(arr));
        Console.WriteLine(CalculateSum(arr));
        Console.WriteLine(CalculateProduct(arr));
    }

    private static double GetAvarage(int[] arr)
    {
        double avarage = 0;
        avarage = CalculateSum(arr) / (double)arr.Length;

        return avarage;
    }

    private static long CalculateProduct(int[] arr)
    {
        long product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    private static long CalculateSum(int[] arr)
    {
        long sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static int GetMaxNumber(int[] arr)
    {
        int max = int.MinValue;

        Array.Sort(arr);
        max = arr[arr.Length - 1];
        return max;
    }

    private static int GetMinNumber(int[] arr)
    {
        int min = int.MaxValue;

        Array.Sort(arr);
        min = arr[0];
        return min;
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