/// Write a program that enters 3 real numbers and prints them sorted in descending order.
/// Use nested if statements.
using System;
using System.Globalization;
using System.Threading;

public class SortThreeNumbers
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());

        double temp = 0;

        if (firstNumber < secondNumber && secondNumber > thirdNumber)
        {
            temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;

            if (secondNumber < thirdNumber)
            {
                temp = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = temp;
            }
        }
        else if (firstNumber < thirdNumber)
        {
            temp = firstNumber;
            firstNumber = thirdNumber;
            thirdNumber = temp;
            if (secondNumber < thirdNumber)
            {
                temp = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = temp;
            }
        }
        else if (secondNumber < thirdNumber)
        {
            temp = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = temp;
        }

        string outputFormat = "{0} {1} {2}";
        Console.WriteLine(outputFormat, firstNumber, secondNumber, thirdNumber);
    }
}
