namespace CardGame
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();

            int[,] dp = new int[n, n];

            for (int length = 3; length <= n; length++)
            {
                for (int i = 0; i <= n - length; i++)
                {
                    //i, i + length - 1
                    for (int j = i + 1; j < i + length - 1; j++)
                    {
                        int current = dp[i, j] + dp[j, i + length - 1]
                            + numbers[j] * (numbers[i] + numbers[i + length - 1]);

                        if (dp[i, i + length - 1] < current)
                        {
                            dp[i, i + length - 1] = current;
                        }
                    }
                }
            }

            Console.WriteLine(dp[0, n - 1]);
        }
    }
}
