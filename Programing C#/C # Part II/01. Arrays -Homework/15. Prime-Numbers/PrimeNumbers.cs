using System;

public class PrimeNumbers
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        var isPrime = new byte[length + 1];
        var result = 0;

    for (int i = 2; i <= length; i++)
        {
            if (isPrime[i]==0)
            {
                result = i;

                for (int j = i * 2; j <= length; j += i)
                {
                    isPrime[j] = 1;
                }
            }
        }

        Console.WriteLine(result);
    }
}