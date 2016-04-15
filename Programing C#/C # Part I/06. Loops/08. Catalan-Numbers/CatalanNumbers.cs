/*In combinatorics, the Catalan numbers are calculated by the following formula: 
catalan-formula (2n)!/((n+1)!*n!)
Write a program to calculate the Nth Catalan number by given N*/
using System;
using System.Numerics;

public class CatalanNumbers
{
    public static void Main()
    {
        BigInteger numberN = BigInteger.Parse(Console.ReadLine());
        BigInteger firstFactorial = 1;
        BigInteger secondFactorial = 1;

        /// (2*N)!=1*2*3..*N*(N+1)..*(2*N-1)(2*N) and  N! = 1*2*3.....*K =>
        /// (2*N)!/(N+1)*N! = ( (N+1)*(N+2)..*(2*N))/(N+1)!
        for (BigInteger i = numberN + 1; i <= 2 * numberN; i++)
        {
            firstFactorial *= i;
            secondFactorial *= i - numberN + 1;
        }

        BigInteger numberOfCombinations = firstFactorial / secondFactorial;
        Console.WriteLine(numberOfCombinations);
    }
}
