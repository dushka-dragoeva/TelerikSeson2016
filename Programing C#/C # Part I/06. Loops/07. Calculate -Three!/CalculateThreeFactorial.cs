/*In combinatorics, the number of ways to choose N different members out of a group of N 
different elements (also known as the number of combinations) is calculated by the following 
formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard 
deck of 52 cards. Your task is to write a program that calculates N! / (K! * (N - K)!) for 
given N and K.
Try to use only two loops.*/
using System;
using System.Numerics;

public class CalculateThreeFactorial
{
    public static void Main()
    {
        BigInteger numberN = BigInteger.Parse(Console.ReadLine());
        BigInteger numberK = BigInteger.Parse(Console.ReadLine());
        BigInteger firstFactorial = 1;
        BigInteger secondFactorial = 1;

        for (BigInteger i = numberK + 1; i <= numberN; i++)
        {
            firstFactorial *= i;
            secondFactorial *= i - numberK;
        }

        BigInteger numberOfCombinations = firstFactorial / secondFactorial;
        Console.WriteLine(numberOfCombinations);
    }
}
