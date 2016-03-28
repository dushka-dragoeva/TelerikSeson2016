/// Write a program first reads 3 numbers n, p, q and k and than swaps bits {p, p+1, …, p+k-1} 
/// with bits {q, q+1, …, q+k-1} of n. Print the resulting integer on the console.
using System;

public class BitSwap
{
    public static void Main()
    {
        long numberN = long.Parse(Console.ReadLine());
        int firstStartPositionP = int.Parse(Console.ReadLine());
        int secondStartPositionQ = int.Parse(Console.ReadLine());
        int lengthK = int.Parse(Console.ReadLine());

        long firstBit = 0;
        long secondBit = 0;
        long newNumber = 0;
        newNumber = numberN;
        for (int i = 0; i < lengthK; i++)
        {
            firstBit = GetBit(numberN, firstStartPositionP + i);
            secondBit = GetBit(numberN, secondStartPositionQ + i);
            newNumber = ModifyBit(newNumber, firstStartPositionP + i, secondBit);
            newNumber = ModifyBit(newNumber, secondStartPositionQ + i, firstBit);
        }

        Console.WriteLine(newNumber);
    }

    public static long GetBit(long number, int position)
    {
        long mask = 1 << position;
        long numberAndMask = number & mask;
        long bit = numberAndMask >> position;
        return bit;
    }

    public static long ModifyBit(long number, int position, long bit)
    {
        long mask;
        long newNumber;

        if (bit == 0)
        {
            mask = ~(1 << position);
            newNumber = number & mask;
        }
        else
        {
            mask = 1 << position;
            newNumber = number | mask;
        }

        return newNumber;
    }
}
