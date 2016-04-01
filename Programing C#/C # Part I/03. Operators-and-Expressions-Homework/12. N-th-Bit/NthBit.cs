/// Write a program that reads from the console two integer numbers P and N and prints on the console 
/// the value of P's N-th bit.
using System;

public class NthBit
{
    public static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());

        uint mask = 1;

        var output = ((mask << position & number) == 0) ? "0" : "1";
        Console.WriteLine(output);
    }
}
