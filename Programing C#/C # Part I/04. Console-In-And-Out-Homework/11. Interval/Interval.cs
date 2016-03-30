/// Write a program that reads two positive integer numbers N and M and prints how many numbers exist between 
/// them such that the reminder of the division by 5 is 0
using System;

public class Interval
{
    public static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());
        int numberM = int.Parse(Console.ReadLine());
        int counter = 0;

        for (int i = numberN + 1; i < numberM; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}
