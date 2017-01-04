namespace Towns
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class TestsGenerator
    {
        public const string FileNamesFormat = "test.{0:000}.in.txt";
        public const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const int MaxCitizens = 1000000000;
        public const int MaxTowns = 1000;
        private static readonly Random Rand = new Random();

        public void GenerateTests()
        {
            this.CreateTest(new[] { MaxCitizens }, 1);
            this.CreateTest(new[] { 1, 10, 2, 3, 2, 1 }, 2);
            this.CreateTest(new[] { 1, 2, 1, 2, 3, 2, 1, 2, 1 }, 3);
            this.CreateTest(new[] { 1, 2, 4, 5, 1, 6, 1 }, 4);
            this.CreateTest(new[] { 4, 5, 65, 34, 786, 45678, 987, 543, 2, 6, 98, 580, 4326, 754, 54, 2, 1, 3, 5, 6, 8, 765, 43, 3, 54 }, 5);
            this.CreateTest(new[] { 1, 2, 18, 17, 24, 23, 223, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1420, 21, 22, 23, 21, 20, 199, 8, 7, 6, 5, 4, 3, 2, 1, 15, 16, 17, 18, 19, 16, 15, 14, 13, 12, 11, 10, 24, 25 }, 6);
            this.CreateTest(new[] { 7510, 6422, 2526, 20508, 9622, 5816, 28686, 6539, 2441, 3424, 31446, 10808, 19634, 19348, 29552, 18435, 30916, 25160, 23764, 2199, 12553, 31408, 16950, 30181, 5380, 15955, 20176, 22225, 13910, 1377, 4833, 28714, 9694, 16198, 6646, 20960, 23588, 18815, 13928, 1137, 248, 10412, 9766, 10917, 22102, 22503, 29876, 27515, 19085, 8789 }, 7);
            this.CreateTest(new[] { 4, 5, 65, 34, 786, 45678, 987, 543, 2, 6, 98, 560, 4326, 754, 54, 2, 1, 3, 5, 6, 8, 765, 43, 3, 54, 4, 5, 65, 34, 786, 45678, 987, 543, 2, 6, 98, 580, 4326, 754, 54, 2, 1, 3, 5, 6, 8, 765, 43, 3, 54 }, 8);
            this.CreateTest(Enumerable.Range(1, (int)(MaxTowns * 0.1)).Select(x => Rand.Next(1, MaxCitizens)), 9);
            this.CreateTest(Enumerable.Range(1, (int)(MaxTowns * 0.2)).Select(x => Rand.Next(1, MaxCitizens)), 10);
            this.CreateTest(Enumerable.Range(1, (int)(MaxTowns * 0.4)).Select(x => Rand.Next(1, MaxCitizens)), 11);
            this.CreateTest(Enumerable.Range(1, (int)(MaxTowns * 0.6)).Select(x => Rand.Next(1, MaxCitizens)), 12);
            this.CreateTest(Enumerable.Range(1, (int)(MaxTowns * 0.8)).Select(x => Rand.Next(1, MaxCitizens)), 13);
            this.CreateTest(Enumerable.Range(1, (int)(MaxTowns * 0.9)).Select(x => Rand.Next(1, MaxCitizens)), 14);
            this.CreateTest(Enumerable.Range(1, MaxTowns).Select(x => Rand.Next(1, MaxCitizens)), 15);
            this.CreateTest(Enumerable.Range(1, MaxTowns).Select(x => Rand.Next(1, MaxCitizens)), 16);
            this.CreateTest(Enumerable.Range(1, MaxTowns).ToList(), 17);
            this.CreateTest(Enumerable.Range(1, MaxTowns).ToList().Shuffle(Rand), 18);
            this.CreateTest(Enumerable.Range(1, MaxTowns).ToList().Shuffle(Rand), 19);
            this.CreateTest(Enumerable.Range(1, MaxTowns).Select(x => x * (MaxCitizens / MaxTowns)).ToList().Shuffle(Rand), 20);
        }

        private void CreateTest(IEnumerable<int> citizensCount, int testNumber)
        {
            var numberOfCitizens = citizensCount.Count();

            using (var sw = new StreamWriter(string.Format(FileNamesFormat, testNumber)))
            {
                sw.WriteLine(numberOfCitizens);
                var uniqueNames = new HashSet<string> { string.Empty };
                foreach (var citizens in citizensCount)
                {
                    string name = string.Empty;
                    while (uniqueNames.Contains(name))
                    {
                        name = this.GetRandomString(1, 20);
                    }

                    uniqueNames.Add(name);
                    sw.WriteLine("{0} {1}", citizens, name);
                }
            }

            Console.WriteLine("Test {0} is ready! {1} citizens.", testNumber, numberOfCitizens);
        }

        private string GetRandomString(int minLength, int maxLength)
        {
            var len = Rand.Next(minLength, maxLength + 1);
            var sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(AllowedChars[Rand.Next(0, AllowedChars.Length)]);
            }

            return sb.ToString();
        }
    }

    public static class Extensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list, Random randomGenerator)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int swapIndex = randomGenerator.Next(list.Count);
                T currentElement = list[i];
                list[i] = list[swapIndex];
                list[swapIndex] = currentElement;
            }

            return list;
        }
    }
}
