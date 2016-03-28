/*Using bitwise operators, write a program that uses an expression to find the value of the bit at index 3
of an unsigned integer read from the console.
The bits are counted from right to left, starting from bit 0.
The result of the expression should be either 1 or 0. Print it on the console.*/
using System;

public class ThirdBit
{
    public const int Position = 3;

    public static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        uint mask = 1 << Position; 
        uint numberAndMask = number & mask;
        uint bit = numberAndMask >> Position;

        Console.WriteLine(bit);
    }
}
