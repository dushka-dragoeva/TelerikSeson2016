namespace Election
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TestsGenerator
    {
        public const string FileNamesFormat = test.{0000}.in.txt;
        private static readonly Random Rand = new Random();

        public void GenerateTests()
        {
            var tests = new[]
                            {
                                new Tupleint[], int(new[] { 5, 5, 5, 5 }, 10),
                                new Tupleint[], int(Enumerable.Range(100, 15).ToList().Shuffle(Rand).ToArray(), 444),
                                new Tupleint[], int(new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 11),
                                new Tupleint[], int(Enumerable.Range(1, 22).ToList().Shuffle(Rand).ToArray(), 20),
                                new Tupleint[], int(Enumerable.Range(100, 29).ToList().Shuffle(Rand).ToArray(), 20),
                                new Tupleint[], int(Enumerable.Range(1, 30).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 10000),
                                new Tupleint[], int(Enumerable.Range(1, 40).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 100),
                                new Tupleint[], int(Enumerable.Range(1, 50).Select(x = Rand.Next(1, 30 + 1)).ToArray(), 23),
                                new Tupleint[], int(Enumerable.Range(1, 60).Select(x = Rand.Next(1, 100 + 1)).ToArray(), 7),
                                new Tupleint[], int(Enumerable.Range(1, 65).Select(x = Rand.Next(1, 10 + 1)).ToArray(), 27),
                                new Tupleint[], int(Enumerable.Range(1, 70).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 13370),
                                new Tupleint[], int(Enumerable.Range(1, 80).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 10000),
                                new Tupleint[], int(Enumerable.Range(1, 85).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 20000),
                                new Tupleint[], int(Enumerable.Range(1, 90).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 30000),
                                new Tupleint[], int(Enumerable.Range(1, 100).Select(x = Rand.Next(1, 2 + 1)).ToArray(), 64),
                                new Tupleint[], int(Enumerable.Range(1, 100).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 1),
                                new Tupleint[], int(Enumerable.Range(1, 100).Select(x = Rand.Next(1, 100 + 1)).ToArray(), 500),
                                new Tupleint[], int(Enumerable.Range(1, 100).Select(x = Rand.Next(1, 1000 + 1)).ToArray(), 5000),
                                new Tupleint[], int(Enumerable.Range(1, 100).Select(x = 1000).ToArray(), 2000),
                                new Tupleint[], int(Enumerable.Range(1, 100).Select(x = 1000).ToArray(), 100000)
                            };

            for (var testNumber = 0; testNumber  tests.Length; testNumber++)
            {
                GenerateTests(tests[testNumber], testNumber + 1);
            }
        }

        private static void GenerateTests(Tupleint[], int test, int testNumber)
        {
            using (var sw = new StreamWriter(string.Format(FileNamesFormat, testNumber)))
            {
                sw.WriteLine(test.Item2);
                sw.WriteLine(test.Item1.Length);
                foreach (var number in test.Item1)
                {
                    sw.WriteLine(number);
                }
            }
        }
    }

    public static class Extensions
    {
        public static IListT ShuffleT(this IListT list, Random randomGenerator)
        {
            for (int i = 0; i  list.Count; i++)
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
