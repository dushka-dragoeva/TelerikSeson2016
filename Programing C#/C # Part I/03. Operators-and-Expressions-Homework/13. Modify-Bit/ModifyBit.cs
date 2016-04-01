/*We are given an integer number N(read from the console), a bit value v(read from the console as well) 
(v = 0 or 1) and a position P(read from the console). Write a sequence of operators (a few lines of C# 
code) that modifies N to hold the value v at the position P from the binary representation of N while 
preserving all other bits in N. Print the resulting number on the console.*/
using System;

public class ModifyBit
{
    public static void Main()
    {
        uint numberN = uint.Parse(Console.ReadLine());
        int positionP = int.Parse(Console.ReadLine());
        byte bitValueV = byte.Parse(Console.ReadLine());
        uint mask = 1;
        uint numberAndMask;

        if (bitValueV == 0)
        {
            numberAndMask = ~(mask << positionP) & numberN;
        }
        else
        {
            numberAndMask = numberN | mask << positionP; 
        }

        Console.WriteLine(numberAndMask);
    }
}