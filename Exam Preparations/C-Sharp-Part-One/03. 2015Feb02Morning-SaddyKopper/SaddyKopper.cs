using System;
using System.Numerics;

public class SaddyKopper
{
    public static void Main()
    {
        string numberM = Console.ReadLine();
        SaddyKopper current = new SaddyKopper();
        BigInteger product = 1;

        int tr = 1;

        for (int i = 0; i < 10; i++)
        {
            if (numberM.Length == 1)
            {
                break;
            }

            int[] arr = new int[7];
            int a = arr.Length;

            product = current.Transformation(numberM, current);
            numberM = product.ToString();
            tr = i + 1;
        }
         
        if (tr < 10)
        {
            Console.WriteLine(tr);
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