/// Write a program that enters from the console a positive integer n and prints all the numbers from 1 to N 
/// inclusive, on a single line, separated by a whitespace
using System;

public class NumbersFromOneToN
{
    public static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numberN; i++)
        {
            if (i != numberN)
            {
                Console.Write("{0} ", i);
            }
            else
            {
                Console.Write(i);
            }
        }
    }
}