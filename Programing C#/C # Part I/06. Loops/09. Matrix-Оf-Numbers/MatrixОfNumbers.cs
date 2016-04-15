/*Write a program that reads from the console a positive integer number N and prints a matrix like in 
the examples below.Use two nested loops.
Input	Output
2	    1 2
        2 3
_____________________
3	    1 2 3
        2 3 4
        3 4 5
______________________
4	    1 2 3 4
        2 3 4 5
        3 4 5 6
        4 5 6 7
Challenge: achieve the same effect without nested loops*/
using System;

public class MatrixОfNumbers
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int rows = number;
        int cols = number;

        for (int i = 0; i < number; i++)
        {
            for (int j = 1; j <= number; j++)
            {
                if (i + j < 10)
                {
                    Console.Write("{0,-2}", i + j);
                }
                else
                {
                    Console.Write("{0,-3}", i + j);
                }
            }
            Console.WriteLine();
        }
    }
}