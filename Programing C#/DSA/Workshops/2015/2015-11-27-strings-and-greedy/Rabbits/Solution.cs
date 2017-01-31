namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        public static void Main()
        {
            var answers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            answers.RemoveAt(answers.Count - 1);

            var rabbits = CountRabbits(answers);

            Console.WriteLine(rabbits);
        }

        private static int CountRabbits(IEnumerable<int> answers)
        {
            var counts = new Dictionary<int, int>();
            foreach (var answer in answers)
            {
                if (!counts.ContainsKey(answer))
                {
                    counts.Add(answer, 0);
                }

                counts[answer]++;
            }

            var rabbits = 0;

            foreach (var count in counts)
            {
                var groupSize = count.Key + 1;
                var minGroupsCount = Math.Ceiling((decimal)count.Value / groupSize);
                rabbits += (int)minGroupsCount * groupSize;
            }

            return rabbits;
        }
    }
}
