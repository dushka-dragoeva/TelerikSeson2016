using System;

public class SayHello
{
    public static void Main(string[] args)
    {
        var name = Console.ReadLine();
        Greet(name);
    }

    private static void Greet(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}
