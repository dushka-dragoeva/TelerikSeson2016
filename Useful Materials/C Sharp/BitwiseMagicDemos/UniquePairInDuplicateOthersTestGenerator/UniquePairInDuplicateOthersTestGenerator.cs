using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePairInDuplicateOthersTestGenerator
{
    static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> generatedForDuplicates = new HashSet<int>();

            Random random = new Random();

            int uniqueA = random.Next(int.MinValue, int.MaxValue);
            int uniqueB = random.Next(int.MinValue, int.MaxValue);

            int duplicateEntitiesCount = int.Parse(args[0]);

            for (int i = 0; i < duplicateEntitiesCount; i++)
            {
                int number = random.Next(int.MinValue, int.MaxValue);
                if(uniqueA != number && uniqueB != number && !generatedForDuplicates.Contains(number))
                {
                    generatedForDuplicates.Add(number);
                }
            }

            List<string> testData = new List<string>();
            testData.Add(uniqueA.ToString());
            testData.Add(uniqueB.ToString());
            foreach (var value in generatedForDuplicates)
            {
                testData.Add(value.ToString());
                testData.Add(value.ToString());
            }

            testData.Shuffle();
            testData.Shuffle();
            testData.Shuffle();

            testData.Add("end");

            System.IO.File.WriteAllText("testFor" + ((duplicateEntitiesCount * 2) + 2) + "in.txt", String.Join(System.Environment.NewLine, testData));
            System.IO.File.WriteAllText("testFor" + ((duplicateEntitiesCount * 2) + 2) + "out.txt", uniqueA + System.Environment.NewLine + uniqueB);
        }
    }
}
