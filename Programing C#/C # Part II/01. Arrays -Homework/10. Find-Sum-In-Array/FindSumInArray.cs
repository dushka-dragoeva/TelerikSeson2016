using System;
using System.Linq;

public class FindSumInArray
{
    public static void Main(string[] args)
    {
        string input = "4, 3, 1, 4, 2, 5, 8";
        int sum = 55;
        int startIndex = 0;
        int endIndex = 0;
        int counter = 0;
        bool isSumExist = false;

        int[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int tempSum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            tempSum += arr[i];

            if (tempSum < sum)
            {
                counter++;
            }
            else if (tempSum > sum)
            {
                tempSum = 0;
                endIndex = i;
                startIndex = endIndex - counter;
                i = startIndex;
                counter = 0;
            }
            else if (tempSum == sum)
            {
                endIndex = i;
                startIndex = endIndex - counter;
                isSumExist = true;
                break;
            }
        }

        if (isSumExist)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write(arr[i]);
                if (i < endIndex)
                {
                    Console.Write(',');
                }
            }
        }
        else
        {
            Console.WriteLine("Sum doesn't exist.");
        }
    }
}