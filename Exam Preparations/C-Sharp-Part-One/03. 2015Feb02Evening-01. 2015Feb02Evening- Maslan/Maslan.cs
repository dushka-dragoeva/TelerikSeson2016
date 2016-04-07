using System;
using System.Numerics;

public class Maslan
{
    public static void Main()
    {
        string number = Console.ReadLine();

        int sum = 0;
        BigInteger product = 1;
        int transformers = 0;
        bool isFullTransformed = false;
        string num = number.Substring(0, number.Length - 1);
        string result = string.Empty;

        for (int i = 0; i < 10; i++)
        {
            product = 1;

            while (num.Length > 0)
            {
                for (int j = 0; j < num.Length - 1; j += 2)
                {
                    sum += (int)num[j + 1] - (int)'0';
                }

                if (sum != 0)
                {
                    product *= sum;
                    sum = 0;
                }

                num = num.Substring(0, num.Length - 1);
            }

            result = product.ToString();
            transformers++;
            if (result.Length == 1)
            {
                isFullTransformed = true;
                break;
            }

            num = result.Substring(0, result.Length - 1);
        }

        if (isFullTransformed)
        {
            Console.WriteLine(transformers);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine(product);
        }
    }
}
