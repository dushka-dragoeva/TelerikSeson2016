using System;
using System.Collections.Generic;

namespace CompareSortAlorithms
{
    public static class SortAlgorithm
    {
        public static void ExecuteInsertionSort<T>(IList<T> collection)
             where T : IComparable
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (collection[j - 1].CompareTo(collection[j]) > 0)
                    {
                        var oldValue = collection[j - 1];
                        collection[j - 1] = collection[j];
                        collection[j] = oldValue;
                    }
                }
            }
        }

        public static void ExecuteSelectionSort<T>(IList<T> collection)
           where T : IComparable
        {
            var minIndex = 0;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var oldValue = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = oldValue;
                }
            }
        }

        public static void ExecuteQuicSortAlgorithm<T>(IList<T> collection, int left, int right)
           where T : IComparable
        {
            int pivotIndex = (left + right) / 2;
            int leftIndex = left;
            int rightindex = right;
            var pivot = collection[pivotIndex];

            while (leftIndex <= rightindex)
            {
                while (collection[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                }

                while (collection[rightindex].CompareTo(pivot) > 0)
                {
                    rightindex--;
                }

                if (leftIndex <= rightindex)
                {
                    var temp = collection[leftIndex];
                    collection[leftIndex] = collection[rightindex];
                    collection[rightindex] = temp;
                    leftIndex++;
                    rightindex--;
                }

                if (left < rightindex)
                {
                    ExecuteQuicSortAlgorithm(collection, left, rightindex);
                }

                if (leftIndex < right)
                {
                    ExecuteQuicSortAlgorithm(collection, leftIndex, right);
                }
            }
        }
    }
}
