using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var dictionary = new Dictionary<string, string>()
            {
                { ".NET", "platform for applications from Microsoft" },
                { "CLR", "managed execution environment for .NET" },
                { "namespace", "hierarchical organization of classes" }
            };

        var input = Console.ReadLine();

        Console.WriteLine(dictionary[input]);
    }
}
