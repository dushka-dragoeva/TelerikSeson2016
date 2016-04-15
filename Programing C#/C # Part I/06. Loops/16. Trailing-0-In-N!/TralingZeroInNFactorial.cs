/* Write a program that calculates with how many zeroes the factorial of a given number N has at its end.
Your program should work well for very big numbers, e.g. N = 100000.*/
using System;
using System.Numerics;
using System.Text.RegularExpressions;

public class TralingZeroInNFactorial
{
    public static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }


        var result = factorial.ToString();
        int zeroLength = 0;
        if (result.Substring(result.Length - 1) == "0")
        {
            int startIndex = (result.Length - 1) / 2;
            int endIndex = result.Length - 1;

            string zeros = result.Substring(startIndex);
            while (true)
            {
                if (startIndex == 0)
                {
                    break;
                }

                if (zeros.Substring(0, 1) == " 0" && zeros.Substring(endIndex) == "0")
                {
                    result = result.Substring(0, startIndex - 1);
                    zeroLength += zeros.Length;
                    endIndex = startIndex - 1;
                    startIndex = (startIndex - 1) / 2;

                }

                else
                {
                    zeros = result.Substring(startIndex / 2);
                    startIndex = (endIndex - startIndex - 1) / 2;
                    endIndex = result.Length;

                }
            }

        }



        ////Regex reg = / 0 +$/;
        //  var index = result.IndexOf('1');



        int counter = 0;

        //  for (int i = result.Length - 1; i >= 0; i--)
        //  {
        //      if (result[i] == '0')
        //      {
        //          counter++;
        //      }
        //      else
        //      {
        //          break;
        //      }
        //  }

        Console.WriteLine(zeroLength);
    }
}
