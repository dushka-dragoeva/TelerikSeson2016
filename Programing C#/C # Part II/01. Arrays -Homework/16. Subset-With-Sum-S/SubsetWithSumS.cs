using System;

public class SubsetWithSumS
{
    public static void Main()
    {
        int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6 };
        var sum = 2;
        var isSumExist = false;
        var length = arr.Length;
        ///  var counter = 0; // number of subsets

        /// loop until (2^length )-1 => number of combination between numbers in arr
        int maxConbinations = (int)Math.Pow(2, length) - 1;

        for (int i = 1; i <= maxConbinations; i++)
        {
            long currentsum = 0;
            for (int j = 0; j < length; j++)
            {
                /// take the current bit

                int mask = 1 << j;
                int bit = (mask & i) >> j;

                if (bit == 1)
                {
                    currentsum += arr[j];
                }
            }

            if (currentsum == sum)
            {
                /// counter++;
                isSumExist = true;
                break;
            }
        }

        /// Console.WriteLine(counter);
        var output = isSumExist ? "yes" : "no";
        Console.WriteLine(output);
    }
}