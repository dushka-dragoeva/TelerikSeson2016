/// Declare a character variable and assign it with the symbol that has Unicode code 42 
/// (decimal) using the \u00XX syntax, and then print it.
using System;

public class Program
{
    public static void Main()
    {
        char charValue = (char)0x2A;
        Console.WriteLine(charValue);
    }
}
