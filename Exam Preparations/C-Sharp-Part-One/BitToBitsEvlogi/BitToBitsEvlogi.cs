using System;

public class BitsToBitsEvlogi
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int maxZeros = 0;
        int maxOnes = 0;
        int currentZeros = 0;
        int currentOnes = 0;
        int lastBit = 5;
        int bit = -1;

        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            for (int p = 29; p >= 0; p--)
            {
                int mask = 1 << p;
                bit = (mask & currentNumber) >> p;

                if (bit == 1)
                {
                    if (lastBit == 1)
                    {
                        currentOnes++;
                    }
                    else
                    {
                        currentOnes = 1;
                    }

                    maxOnes = Math.Max(maxOnes, currentOnes);
                }
                else
                {
                    if (lastBit == 0)
                    {
                        currentZeros++;
                        maxZeros = Math.Max(maxZeros, currentZeros);
                    }
                    else
                    {
                        currentZeros = 1;
                    }

                    maxZeros = Math.Max(maxZeros, currentZeros);
                }

                lastBit = bit;
            }
        }

        Console.WriteLine(maxZeros);
        Console.WriteLine(maxOnes);
    }
}