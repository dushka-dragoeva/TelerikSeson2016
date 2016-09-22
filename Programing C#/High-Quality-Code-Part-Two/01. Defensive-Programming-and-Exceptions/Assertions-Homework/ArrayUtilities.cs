using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AssertionsHomework
{
    internal class ArrayUtilities
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value)
            where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(IsSorted(arr), "Array should be sorted");
            Debug.Assert(value != null, "Searching value is null.");
            Debug.Assert(IndexIsInRange(arr, startIndex), "Invalid startIndex value.");
            Debug.Assert(IndexIsInRange(arr, endIndex), "Invalid endIndex value.");
            Debug.Assert(startIndex <= endIndex, "Start Index is greater than end index.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            Debug.Assert(!HasValue(arr, value), "The array contains searched value, but method returns -1.");
            return -1;
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
           where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 1, "Array should have at least 2 elements.");
            Debug.Assert(IndexIsInRange(arr, startIndex), "Invalid startIndex value.");
            Debug.Assert(IndexIsInRange(arr, endIndex), "Invalid endIndex value.");
            Debug.Assert(startIndex <= endIndex, "Start Index is greater than end index.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            var expected = FindMinElementIndexUsingLinq(arr, startIndex, endIndex);
            Debug.Assert(expected == minElementIndex, $"Expected: {expected}, but was: {minElementIndex} ");
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static bool IndexIsInRange<T>(T[] arr, int index)
             where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");

            var isInRange = 0 <= index && index <= arr.Length;
            return isInRange;
        }

        private static bool IsSorted<T>(IEnumerable<T> list)
            where T : IComparable<T>
        {
            if (list.Count() > 0)
            {
                var y = list.First();

                return list.Skip(1).All(x =>
                {
                    bool b = y.CompareTo(x) < 0;
                    y = x;

                    return b;
                });
            }
            else
            {
                return true;
            }
        }

        private static bool HasValue<T>(IEnumerable<T> list, T value)
            where T : IComparable<T>
        {
            return list.Any(x => x.Equals(value));
        }

        private static int FindMinElementIndexUsingLinq<T>(T[] arr, int startIndex, int endIndex)
           where T : IComparable<T>
        {
            var partialArr = new T[endIndex - startIndex + 1];
            for (int i = 0; i < partialArr.Length; i++)
            {
                partialArr[i] = arr[startIndex + i];
            }

            var minValue = partialArr.Min();
            var minValueIndex = Array.IndexOf(partialArr, minValue) + startIndex;

            return minValueIndex;
        }
    }
}
