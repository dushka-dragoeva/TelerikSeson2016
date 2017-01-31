namespace Election
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Election
    {
        public static void Main()
        {
            //// new TestsGenerator().GenerateTests();

            //// CompareSolutions();

            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var nums = new int[n];
            for (var i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            var count = BitwiseCombinationsSolution(nums, k);

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

        private static BigInteger BitwiseCombinationsSolution(IList<int> nums, int k)
        {
            var count = new BigInteger(0);
            for (var combination = 0; combination < (1 << nums.Count); combination++)
            {
                var toTakeNumber = Convert.ToString(combination, 2).PadLeft(nums.Count, '0');
                var sum = 0;
                for (var i = 0; i < nums.Count; i++)
                {
                    // Next line can be replaced with bitwise operators but this solution will still be exponentially slower
                    if (toTakeNumber[i] == '1')
                    {
                        sum += nums[i];
                    }
                }

                if (sum >= k)
                {
                    count++;
#if DEBUG
                    for (var i = 0; i < nums.Count; i++)
                    {
                        if (toTakeNumber[i] == '1')
                        {
                            // Console.Write((char)('A' + i));
                        }
                    }

                   // Console.WriteLine();
#endif
                }
            }

            return count;
        }

        private static void CompareSolutions()
        {
            var tests = new[]
                            {
                                new Tuple<int[], int>(new[] { 10, 4, 2 }, 4),
                                new Tuple<int[], int>(new[] { 84, 39, 38, 23, 19, 15, 11, 11 }, 121),
                                new Tuple<int[], int>(new[] { 5, 5, 5, 5 }, 10),
                                new Tuple<int[], int>(new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 11),
                                new Tuple<int[], int>(Enumerable.Range(1, 4).ToArray(), 1),
                                new Tuple<int[], int>(Enumerable.Range(1, 9).ToArray(), 1),
                                new Tuple<int[], int>(Enumerable.Range(1, 17).ToArray(), 1),
                                new Tuple<int[], int>(Enumerable.Range(1, 19).ToArray(), 1),
                                new Tuple<int[], int>(Enumerable.Range(1, 21).ToArray(), 10),
                                new Tuple<int[], int>(Enumerable.Range(1, 22).ToArray(), 20),
                                new Tuple<int[], int>(Enumerable.Range(100, 15).ToArray(), 1000)
                            };

            for (int i = 0; i < tests.Length; i++)
            {
                var test = tests[i];
                var solutionDynamicProgramming = DynamicProgrammingSolution(test.Item1, test.Item2);
                var solutionBruteForce = BitwiseCombinationsSolution(test.Item1, test.Item2);
                if (solutionDynamicProgramming != solutionBruteForce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine("Test ¹{0}: DP: {1}; BruteForce: {2}", i, solutionDynamicProgramming, solutionBruteForce);
            }
        }
    }
}
