/// Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
using System;

public class PrintLongSequence
{
    public static void Main()
    {
        /// for-loop,we will iterate all numbers from 2 to 1001 including
        /// i -  variable Integer type, which manage the loop
        ///each iteration i is increasing with 1 (i++)
        for (int i = 2; i <= 1001; i++)
        {
            /// variable result we will use to print current number
            int result = i;
            /// % - division with remainder, returns the value of the remainder, 
            /// if it is equal 1 that means the number is odd - change sign of i

            if (result % 2 == 1)
            {
                result = -i;
            }

            Console.WriteLine(result);
        }
    }
}
