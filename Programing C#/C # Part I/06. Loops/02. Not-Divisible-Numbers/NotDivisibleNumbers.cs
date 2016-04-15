/// Write a program that reads from the console a positive integer N 
/// and prints all the numbers from 1 to N 
/// not divisible by 3 or 7, on a single line, separated by a space.
using System;

public class NotDivisibleNumbers
{
    public static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());
        bool isDivisible = true;

        for (int i = 1; i <= numberN; i++)
        {
            if (i % 3 != 0)
            {
                isDivisible = false;
                
                if (i % 7 != 0)
                {
                    isDivisible = false;
                    Console.Write("{0} ", i);
                }
            }
        }
    }
}