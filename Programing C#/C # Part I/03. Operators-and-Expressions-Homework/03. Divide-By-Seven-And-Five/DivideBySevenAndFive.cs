/*Write a program that does the following:
Reads an integer number from the console.
Stores in a variable if the number can be divided by 7 and 5 without remainder.
Prints on the console "true NUMBER" if the number is divisible without remainder 
by 7 and 5. Otherwise prints "false NUMBER". In place of NUMBER print the value of 
the input number.*/
using System;

public class DivideBySevenAndFive
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int number = int.Parse(input);
        bool isDevidable = number % 5 == 0 && number % 7 == 0;
        string outputFormat = "{0} {1}";

        Console.WriteLine(outputFormat, isDevidable, number);
    }
}
