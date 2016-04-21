using System;
using System.Numerics;

public class SaddyKopper
{
    public static void Main(string[] args)
    {
        string stringNumber = Console.ReadLine();
        int transformers = 0;
        BigInteger product = 1;
        BigInteger fp = 1;

        while (stringNumber.Length > 1 && transformers < 10)
        {
            product = 1;
            while (stringNumber.Length > 0)
            {
                int sum = 0;
                stringNumber = stringNumber.Substring(0, stringNumber.Length - 1);

                for (int i = 0; i < stringNumber.Length; i += 2)
                {
                    sum += stringNumber[i] - '0';
                }

                product *= sum != 0 ? sum : 1;
            }

            transformers++;
            stringNumber = product.ToString();
        }

        if (transformers < 10)
        {
            Console.WriteLine(transformers);
        }

        Console.WriteLine(stringNumber);
    }
}