namespace Election
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Election
    {
        public static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var nums = new int[n];
            for (var i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            var count = DynamicProgrammingSolution(nums, k);

            Console.WriteLine(count);
        }

        private static BigInteger DynamicProgrammingSolution(IEnumerable<int> nums, int k)
        {
            var combinations = new BigInteger[(100 * 1000) + 1];
            var maxSum = 0;
            
            // Base case
            combinations[0] = 1;

            // Find all combinations
            foreach (var num in nums)
            {
                for (var j = maxSum; j >= 0; j--)
                {
                    if (combinations[j] > 0)
                    {
                        combinations[j + num] += combinations[j];
                        maxSum = Math.Max(maxSum, j + num);
                    }
                }
            }

            // Sum all combinations with k or more seats
            var numberOfSolutions = new BigInteger(0);
            for (var i = k; i <= maxSum; i++)
            {
                numberOfSolutions += combinations[i];
            }

            return numberOfSolutions;
        }
    }
}
