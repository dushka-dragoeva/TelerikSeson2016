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
        uint number = uint.Parse(Console.ReadLine());

        uint firstBit = 0;
        uint secondBit = 0;
        uint newNumber = 0;
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

    public static uint GetBit(uint number, int position)
    {
        uint mask = 1;
        uint numberAndMask = mask << position & number;
        uint bit = numberAndMask >> position;
        return bit;
    }

    public static uint ModifyBit(uint number, int position, uint bit)
    {
        uint mask = 1;
        uint newNumber;

        if (bit == 0)
        {
            mask = 1;
            newNumber = number & ~(mask << position);
        }
        else
        {
            mask = 1;
            newNumber = number | mask << position;
        }

        return newNumber;
    }
}
