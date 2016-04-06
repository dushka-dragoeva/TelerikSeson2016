using System;
using System.Numerics;

public class SaddyKopper
{
    public static void Main()
    {
        string numberM = Console.ReadLine();
        SaddyKopper current = new SaddyKopper();
        BigInteger product = 1;

        int transformers = 1;

        for (int i = 0; i < 10; i++)
        {
            if (numberM.Length == 1)
            {
                break;
            }

            product = current.Transformation(numberM, current);
            numberM = product.ToString();
            transformers = i + 1;
        }

        if (transformers < 10)
        {
            Console.WriteLine(transformers);
            Console.WriteLine(numberM);
        }
        else
        {
            Console.WriteLine(numberM);
        }
    }

    public BigInteger Transformation(string number, SaddyKopper curr)
    {
        BigInteger product = 1;
        int sum = 0;
        string num = number.Substring(0, number.Length - 1);

        for (int i = 0; i < number.ToString().Length - 1; i++)
        {
            sum = curr.SumOfDigitsAtEvenPosition(num);
            product *= sum;
            num = number.Substring(0, num.Length - 1);
        }

        return product;
    }

    public int SumOfDigitsAtEvenPosition(string number)
    {
        int sum = 0;

        for (int i = 0; i < number.Length; i = i + 2)
        {
            sum += (int)number[i] - 48;
        }

        return sum;
    }   
}