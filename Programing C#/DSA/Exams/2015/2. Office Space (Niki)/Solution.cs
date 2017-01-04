namespace OfficeSpace
{
    using System;
    using System.Linq;

    public static class Program
    {
        private static int[] maxPathFrom;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var time = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var adjacencyMatrix = new bool[n, n]; // 0-based matrix to represent the graph
            for (var i = 0; i < n; i++)
            {
                var requirements = Console.ReadLine().Split(' ').Select(int.Parse);
                if (requirements.First() != 0)
                {
                    foreach (var requirement in requirements)
                    {
                        adjacencyMatrix[requirement - 1, i] = true;
                    }
                }
            }

            var minTime = FindMinTime(n, time, adjacencyMatrix);
            Console.WriteLine(minTime);
        }

        private static int FindMinTime(int n, int[] time, bool[,] adjacencyMatrix)
        {
            maxPathFrom = new int[n];
            var loopFound = false;

            var maxPath = 0;
            for (var i = 0; i < n; i++)
            {
                maxPath = Math.Max(Dfs(i, time, adjacencyMatrix, new bool[n], ref loopFound), maxPath);
                if (loopFound)
                {
                    return -1;
                }
            }

            return maxPath;
        }

        private static int Dfs(int node, int[] time, bool[,] adjacencyMatrix, bool[] visited, ref bool loopFound)
        {
            if (visited[node])
            {
                loopFound = true;
                return 0;
            }

            if (!visited[node] && maxPathFrom[node] > 0)
            {
                return maxPathFrom[node];
            }

            visited[node] = true;
            maxPathFrom[node] = time[node];
            for (var v = 0; v < time.Length; v++)
            {
                if (adjacencyMatrix[v, node])
                {
                    maxPathFrom[node] = Math.Max(
                        maxPathFrom[node],
                        Dfs(v, time, adjacencyMatrix, visited, ref loopFound) + time[node]);
                }
            }

            visited[node] = false;
            return maxPathFrom[node];
        }
    }
}
