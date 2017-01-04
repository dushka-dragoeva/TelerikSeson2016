namespace BinaryTrees
{
    using System;

    class Program
    {
        static long[] memo;

        static long Trees(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (memo[n] > 0)
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

            var result = factorials[n];
            foreach (var x in groups)
            {
                result /= factorials[x];
            }

            const long BASE = 1000000000;
            var res = new long[3];
            res[0] = result % BASE;
            res[1] = result / BASE % BASE;
            res[2] = result / BASE / BASE % BASE;

            var treesn = new long[2];
            treesn[0] = Trees(n) % BASE;
            treesn[1] = Trees(n) / BASE;

            var total = new long[4];
            total[0] = res[0] * treesn[0];
            total[1] = res[1] * treesn[0] + res[0] * treesn[1];
            total[2] = res[2] * treesn[0] + res[1] * treesn[1];
            total[3] = res[2] * treesn[1];

            total[1] += total[0] / BASE;
            total[0] %= BASE;
            total[2] += total[1] / BASE;
            total[1] %= BASE;
            total[3] += total[2] / BASE;
            total[2] %= BASE;

            if (total[3] != 0)
            {
                Console.WriteLine("{0}{1:000000000}{2:000000000}{3:000000000}", total[3], total[2], total[1], total[0]);
            }
            else if (total[2] != 0)
            {
                Console.WriteLine("{0}{1:000000000}{2:000000000}", total[2], total[1], total[0]);
            }
            else if (total[1] != 0)
            {
                Console.WriteLine("{0}{1:000000000}", total[1], total[0]);
            }
            else
            {
                Console.WriteLine(total[0]);
            }
        }
    }
}
