namespace Towns
{
    using System;

    public class Towns
    {
        public static void Main()
        {
            // Test with hard-coded input
            // Console.WriteLine(FindLongestPath(new[] { 1, 2, 4, 1, 5, 1 }));

            // Generate tests
            // new TestsGenerator().GenerateTests();

            // Read input
            int numberOfTowns = int.Parse(Console.ReadLine());
            var citizens = new int[numberOfTowns];
            for (int currentTown = 0; currentTown < numberOfTowns; currentTown++)
            {
                var line = Console.ReadLine();
                var lineParts = line.Split(' ');
                citizens[currentTown] = int.Parse(lineParts[0]);
            }

            var bestPath = FindLongestPath(citizens);
            Console.WriteLine(bestPath);
        }

        public static int FindLongestPath(int[] citizens)
        {
            int numberOfTowns = citizens.Length;

            // First, find the longest paths in ascending order
            var longestPathAscending = new int[numberOfTowns];
            for (int currentTown = 0; currentTown < numberOfTowns; currentTown++)
            {
                longestPathAscending[currentTown] = 1;
                for (int previousTown = 0; previousTown < currentTown; previousTown++)
                {
                    if (citizens[previousTown] < citizens[currentTown])
                    {
                        longestPathAscending[currentTown] = Math.Max(longestPathAscending[currentTown], longestPathAscending[previousTown] + 1);
                    }
                }
            }

            // Second, find the longest paths in descending order
            var longestPathDescending = new int[numberOfTowns];
            for (int currentTown = numberOfTowns - 1; currentTown >= 0; currentTown--)
            {
                longestPathDescending[currentTown] = 1;
                for (int previousTown = numberOfTowns - 1; previousTown > currentTown; previousTown--)
                {
                    if (citizens[previousTown] < citizens[currentTown])
                    {
                        longestPathDescending[currentTown] = Math.Max(longestPathDescending[currentTown], longestPathDescending[previousTown] + 1);
                    }
                }
            }

            // Third, combine paths by choosing best town to be the separator
            var bestPath = 0;
            for (int currentTown = 0; currentTown < numberOfTowns; currentTown++)
            {
                var currentPath = longestPathAscending[currentTown] + longestPathDescending[currentTown] - 1;
                bestPath = Math.Max(bestPath, currentPath);
            }

            return bestPath;
        }
    }
}
