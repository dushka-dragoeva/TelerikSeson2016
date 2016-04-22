using System;

public class SubsetOfSum
{
    public static void Main(string[] args)
    {
        long sum = long.Parse(Console.ReadLine());
        int length = int.Parse(Console.ReadLine());

        long[] numbers = new long[length];

        for (int i = 0; i < length; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        /// loop until (2^length )-1 => number of combination between numbers in arr
        int maxConbinations = (int)Math.Pow(2, length) - 1;
        int counter = 0;
       
        for (int i = 1; i <= maxConbinations; i++)
        {
            long currentsum = 0;
            for (int j = 0; j < length; j++)
            {
                /// take the current bit

                int mask = 1 << j;
                int bit = (mask & i) >> j;

                if (bit == 1)
                {
                    currentsum += numbers[j];
                }
            }

            if (currentsum == sum)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}
