/* Write a program that, depending on the first line of the input, reads an int, double or string variable.
If the variable is int or double, the program increases it by one.If the variable is a string, the program
appends * at the end. Print the result at the console. Use switch statement. */
using System;
using System.Globalization;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string inputType = Console.ReadLine();
        string inputValue = Console.ReadLine();
        string output = string.Empty;

        switch (inputType)
        {
            case "integer":
                output = string.Format("{0}", int.Parse(inputValue) + 1);
                break;
            case "real":
                output = string.Format("{0:F2}", double.Parse(inputValue) + 1);
                break;

            case "text":
                output = string.Format("{0}*", inputValue);
                break;
        }

        Console.WriteLine(output);
    }
}
