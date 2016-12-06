using System;

namespace FindNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var numberOfStrings =int.Parse( input[0]);
            var positionToFind = int.Parse(input[1]);
            var stringArray = Console.ReadLine().Split(' ');
            RecursiveQuickSort(stringArray, 0, numberOfStrings - 1);
            Console.WriteLine(stringArray[positionToFind]);
        }

        private static void RecursiveQuickSort(string[]  collection, int left, int right)
        {
            var pivot = collection[(left + right) / 2];

            var i = left;
            var j = right;

            while (i <= j)
            {
                while (string.CompareOrdinal( collection[i], pivot) < 0)
                {
                    i++;
                }

                while (string.CompareOrdinal( collection[j], pivot) > 0)
                {
                    j--;
                }

                if (i > j)
                {
                    continue;
                }

                var temp = collection[i];
                collection[i] = collection[j];
                collection[j] = temp;

                i++;
                j--;
            }

            if (left < j)
            {
                RecursiveQuickSort(collection, left, j);
            }

            if (i < right)
            {
                RecursiveQuickSort(collection, i, right);
            }
        }
    }
}
