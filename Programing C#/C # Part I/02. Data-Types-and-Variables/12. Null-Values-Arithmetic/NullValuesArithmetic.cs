/*Create a program that assigns null values to an integer and to a double variable.
Try to print these variables at the console.
Try to add some number or the null literal to these variables and print the result.*/

using System;

public class NullValuesArithmetic
{
    public static void Main()
    {
        int? nullableInteger = null;
        double? nullableDouble = null;
        string formatResult = "{0}, {1}";
        Console.WriteLine(formatResult, nullableInteger, nullableDouble);

        nullableInteger += 5;
        nullableDouble += 5.5;
        Console.WriteLine(formatResult, nullableInteger, nullableDouble);
    }
}
