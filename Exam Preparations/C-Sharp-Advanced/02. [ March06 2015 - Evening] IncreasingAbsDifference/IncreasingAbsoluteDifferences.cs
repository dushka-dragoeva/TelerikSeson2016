using System;
using System.Linq;

public class IncreasingAbsoluteDifferences
{
    /// 1.Read input
    /// 2. For Every sequence do:
    /// 2.1 Calculate sequence of abs diff
    /// 2.1 Check if they are increasing
    /// 3. Output
    public static void Main()
    {
        var rows = int.Parse(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            var sequences = Console.ReadLine()
           .Split(' ')
           .Select(long.Parse)
           .ToArray();

            long last = sequences[i];
            bool isEncreasing = true;

            for (int j = 2; j < sequences.Length; j++)
            {
                var lastAbsDiff = Math.Abs(sequences[j - 1] - sequences[j - 2]);
                var currAbsDiff = Math.Abs(sequences[j] - sequences[j - 1]);

                if (lastAbsDiff > currAbsDiff)
                {
                    isEncreasing = false;
                }
            }

            Console.WriteLine(isEncreasing);
        }
    }
}
