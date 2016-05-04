/// Write a program that reads two integer arrays of size N from the console and compares them element by element.
using System;
using  System.Numerics;
public class CompareArrays
{
    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());

        BigInteger[] arrA = new BigInteger[length];
        BigInteger[] arrB = new BigInteger[length];

        bool isEqual = false;

        for (int i = 0; i < 2 * length; i++)
        {
            if (i < length)
            {
                arrA[i] = BigInteger.Parse(Console.ReadLine());
            }
            else
            {
                arrB[i - length] = BigInteger.Parse(Console.ReadLine());
                if (arrB[i - length] == arrA[i - length])
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                    break;
                }
            }
        }

        var result = isEqual ? "Equal" : "Not equal";
        Console.WriteLine(result);
    }
}
