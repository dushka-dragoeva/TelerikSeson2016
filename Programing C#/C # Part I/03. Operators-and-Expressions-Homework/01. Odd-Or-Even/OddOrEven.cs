/*Write a program that reads an integer from the console, uses an expression to check
if given integer is odd or even, and prints "even NUMBER" or "odd NUMBER", where 
you should print the input number's value instead of NUMBER.*/
using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int number = int.Parse(input);
        bool isEven = number % 2 == 0;

        string evenNumber = "even";
        string oddNumber = "odd";
        var result = isEven ? evenNumber : oddNumber;
        string outputFormat = "{0} {1}";
        Console.WriteLine(outputFormat, result, number);
    }
}
