using System;

public class BinaryDigitsCount
{
   public static void Main(string[] args)
    {
        long bit = long.Parse(Console.ReadLine());
        long length = long.Parse(Console.ReadLine());
        long counter = 0;

        for (long i = 0; i < length; i++)
        {
            counter = 0;
            long currentNumber = long.Parse(Console.ReadLine());
            int currentLength = Convert.ToString(currentNumber, 2).Length;

            for (int p = 0; p < currentLength; p++)
            {
                long mask = (long)1 << p;
                long currentBit = (mask & currentNumber) >> p;

                if (currentBit == bit)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}