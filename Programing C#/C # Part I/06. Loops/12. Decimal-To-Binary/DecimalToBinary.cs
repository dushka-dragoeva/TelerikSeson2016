/*Using loops write a program that converts an integer number to its binary representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.*/
using System;
using System.Text;

public class DecimalToBinary
{
    public static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        string binaryNumber = string.Empty;

        while (decimalNumber > 0)
        {
            long reminder = decimalNumber % 2;
            binaryNumber = binaryNumber.Insert(0, reminder.ToString());
            decimalNumber = decimalNumber / 2;
        }

        Console.WriteLine(binaryNumber);
    }
}
