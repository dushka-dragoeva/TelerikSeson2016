using System;

public class Program
{
    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];

        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        QuicSortAlgorithm(arr, 0, length - 1);

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }

    public static void QuicSortAlgorithm(int[] arr, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int pivotIndex = (left + right) / 2;
        int leftIndex = left;
        int rightindex = right;
        int pivot = arr[pivotIndex];

        while (leftIndex <= rightindex)
        {
            while (arr[leftIndex].CompareTo(pivot) < 0)
            {
                leftIndex++;
            }
            while (arr[rightindex].CompareTo(pivot) > 0)
            {
                rightindex++;
            }
            if (leftIndex <= rightindex)
            {
                int temp = arr[leftIndex];
                arr[leftIndex] = arr[rightindex];
                arr[rightindex] = temp;
                leftIndex++;
                rightindex--;
            }

            if (left < rightindex)
            {
                QuicSortAlgorithm(arr, left, rightindex);
            }
            else
            {
                QuicSortAlgorithm(arr, right, leftIndex);
            }
        }

    }
}


