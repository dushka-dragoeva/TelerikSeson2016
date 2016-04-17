using System;
using System.Numerics;

public class ConsoleApp
{
    public static void Main()
    {
        int counter = 0;
        string input = Console.ReadLine();

        BigInteger productOfFirstTen = 1;
        BigInteger productOfOthers = 1;

        while (input != "END")
        {
            string currentNumber = input;
            long currentProduct = 1;

            if (counter % 2 == 1)
            {
                foreach (var digit in input)
                {
                    if (digit != '0')
                    {
                        currentProduct *= digit - '0';
                    }
                }
            }

            counter++;

            if (counter <= 10)
            {
                productOfFirstTen *= currentProduct;
            }
            else if (counter > 10)
            {
                productOfOthers *= currentProduct;
            }

            input = Console.ReadLine();
        }

        if (counter < 10)
        {
            Console.WriteLine(productOfFirstTen);
        }
        else
        {
            Console.WriteLine(productOfFirstTen);
            Console.WriteLine(productOfOthers);
        }
    }
}
