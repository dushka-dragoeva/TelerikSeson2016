/* Declare two integer variables a and b and assign them with 5 and 10 and after 
that exchange their values by using some programming logic. Print the variable values
before and after the exchange.*/
using System;

public class ExchangeVariableValues
{
    public static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("{0}, {1}", a, b);

        string separator = new string('=', 10);
        Console.WriteLine(separator);

        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine("{0}, {1}", a, b);
    }
}
