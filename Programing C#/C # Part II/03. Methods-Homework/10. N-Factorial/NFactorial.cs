using System;
using System.Numerics;

public class NFactorial
{
    public static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());
        var array = ConvertToArray(number);
        BigInteger factorial = CalculateFactorial(array);
        Console.WriteLine(factorial);
    }

    private static BigInteger CalculateFactorial(int[] number)
    {
        BigInteger factorial = 1;
        for (int i = 0; i < number.Length; i++)
        {
            factorial *= number[i];
        }

        return factorial;
    }

    private static int[] ConvertToArray(int number)
    {
        int[] numberAsArray = new int[number];

        for (int i = 0; i < number; i++)
        {
            numberAsArray[i] = i + 1;
        }

        return numberAsArray;
    }
}