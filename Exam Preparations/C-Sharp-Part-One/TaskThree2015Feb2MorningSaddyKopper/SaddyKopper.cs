using System;
using System.Linq;
using System.Numerics;

public class SaddyKopper
{

    public BigInteger Transformation(BigInteger number, SaddyKopper curr)
    {
        BigInteger product = 1;
        int sum = 0;
        BigInteger num = number / 10;


        for (int i = 0; i < number.ToString().Length - 1; i++)
        {
            sum = curr.SumOfDigitsAtEvenPosition(num);
            product *= sum;
            num = num / 10;
        //  sum = 0;
        }

        return product;
    }

    public int SumOfDigitsAtEvenPosition(BigInteger number)
    {
        int sum = 0;
        int[] numberAsArray = Array.ConvertAll(number.ToString().ToArray(), x => (int)x - 48);

        for (int i = 0; i < numberAsArray.Length; i=i+2)
        {

            sum += numberAsArray[i];
            //  if (i % 2 == 0)
            //  {
            //      sum += numberAsArray[i];
            // }
        }

        return sum;
    }
    public static void Main()
    {
        BigInteger numberM = BigInteger.Parse(Console.ReadLine());

        SaddyKopper current = new SaddyKopper();
        BigInteger product = 1;

        int transformers = 0;


        while (numberM.ToString().Length > 1 && transformers < 10)
        {
            product = current.Transformation(numberM, current);
            numberM = product;
            transformers++;
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
}



