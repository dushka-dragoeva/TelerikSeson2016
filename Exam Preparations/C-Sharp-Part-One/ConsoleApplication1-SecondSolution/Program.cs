using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int counter = 0;
        string input = Console.ReadLine();
        List<string> firstTenNumbers = new List<string>();
        List<string> otherNumbers = new List<string>();

        BigInteger productOfFirstTen = 1;
        BigInteger productOfOthers = 1;

        while (input != "END")
        {
            string currentNumber = input;
            if (counter % 2 == 1)
            {
                if (counter <= 10)
                {
                    firstTenNumbers.Add(currentNumber);
                }
                else
                {
                    otherNumbers.Add(currentNumber);
                }
            }

            counter++;
            input = Console.ReadLine();
        }

        if (otherNumbers.Count == 0)
        {
            foreach (var number in firstTenNumbers)
            {
                productOfFirstTen *= CalculateDigisProduct(number);
            }

            Console.WriteLine(productOfFirstTen);
        }
        else
        {
            foreach (var number in firstTenNumbers)
            {
                productOfFirstTen *= CalculateDigisProduct(number);
            }

            foreach (var number in otherNumbers)
            {
                productOfOthers *= CalculateDigisProduct(number);
            }

            Console.WriteLine(productOfFirstTen);
            Console.WriteLine(productOfOthers);
        }
    }

    public static long CalculateDigisProduct(string number)
    {
        long currentProduct = 1;
        foreach (var digit in number)
        {
            if (digit != '0')
            {
                currentProduct *= digit - '0';
            }
        }

        return currentProduct;
    }
}