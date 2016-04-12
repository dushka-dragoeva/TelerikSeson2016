using System;

public class FrequentNumber
{
    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];

        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);
        int maxCounter = 1;
        int tempCounter = 1;
        int mostFrequentNumber = 0;

        for (int i = 0; i < length - 1; i++)
        {
            if (arr[i] == arr[i + 1])
            {
                tempCounter++;
            }
            else
            {
                if (tempCounter > maxCounter)
                {
                    maxCounter = tempCounter;
                    mostFrequentNumber = arr[i];
                    tempCounter = 1;
                }
                else
                {
                    tempCounter = 1;
                }
            }
        }

        string outputFormat = "{0} ({1} times)";
        Console.WriteLine(outputFormat, mostFrequentNumber, maxCounter);
    }
}