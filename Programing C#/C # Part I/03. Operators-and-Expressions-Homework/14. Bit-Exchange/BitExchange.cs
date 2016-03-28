/// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit 
/// unsigned integer(read from the console).
using System;

public class BitExchange
{
    public const int FirstStartPosition = 3;
    public const int SecondStartPosition = 24;
    public const int Length = 3;

    public static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        long firstBit = 0;
        long secondBit = 0;
        long newNumber = 0;
        newNumber = number;
        for (int i = 0; i < Length; i++)
        {
            firstBit = GetBit(number, FirstStartPosition + i);
            secondBit = GetBit(number, SecondStartPosition + i);
            newNumber = ModifyBit(newNumber, FirstStartPosition + i, secondBit);
            newNumber = ModifyBit(newNumber, SecondStartPosition + i, firstBit);
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
