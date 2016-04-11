/*Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
Use the Selection sort algorithm: Find the smallest element, move it at the first position, 
find the smallest from the rest, move it at the second position, etc.*/

using System;

public class SelectionSort
{
    public static void Swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];
        int minIndex = 0;

        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < length - 1; i++)
        {
            minIndex = i;

            for (int j = i + 1; j < length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                var temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            Console.WriteLine(arr[i]);
            if (i == length - 2)
            {
                Console.WriteLine(arr[i + 1]);
            }
        }
    }
}