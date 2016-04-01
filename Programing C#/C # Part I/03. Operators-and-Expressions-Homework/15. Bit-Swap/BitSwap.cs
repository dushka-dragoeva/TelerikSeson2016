/// Write a program first reads 3 numbers n, p, q and k and than swaps bits {p, p+1, …, p+k-1} 
/// with bits {q, q+1, …, q+k-1} of n. Print the resulting integer on the console.
using System;

public class BitSwap
{
    public static void Main()
    {
        uint numberN = uint.Parse(Console.ReadLine());
        int firstStartPositionP = int.Parse(Console.ReadLine());
        int secondStartPositionQ = int.Parse(Console.ReadLine());
        int lengthK = int.Parse(Console.ReadLine());

        uint firstBit = 0;
        uint secondBit = 0;
        uint newNumber = 0;
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

    public static uint GetBit(uint number, int position)
    {
        uint mask = 1;
        uint numberAndMask = number & mask << position;
        uint bit = numberAndMask >> position;
        return bit;
    }

    public static uint ModifyBit(uint number, int position, uint bit)
    {
        uint mask =1;
        uint newNumber;

        if (bit == 0)
        {
            newNumber = number & ~(mask << position);
        }
        else
        {
            newNumber = number | mask << position;
        }

        return newNumber;
    }
}
