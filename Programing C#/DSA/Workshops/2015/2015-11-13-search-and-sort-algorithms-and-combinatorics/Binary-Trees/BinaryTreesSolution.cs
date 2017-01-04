namespace BinaryTrees
{
    using System;
    using System.Numerics;

    class Program
    {
        static long[] memo;
        static long Trees(int n)
        {
            if(n == 0)
            {
                return 1;
            }

            if(memo[n] > 0)
            {
                return memo[n];
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Trees(i) * Trees(n - 1 - i);
            }

            memo[n] = result;
            return result;
        }

        static void Main(string[] args)
        {
            memo = new long[32];

            var input = Console.ReadLine();
            var groups = new int[26];

            foreach (var ball in input)
            {
                groups[ball - 'A']++;
            }

            int n = input.Length;

            var factorials = new long[n + 1];
            factorials[0] = 1;
            for (int i = 0; i < n; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

            long result = factorials[n];
            foreach (var x in groups)
            {
                result /= factorials[x];
            }

            BigInteger total = result;
            total *= Trees(n);
            Console.WriteLine(total);
        }
    }
}
