using System;

public class StringLength
{
    public static void Main()
    {
        var text = Console.ReadLine();
        text = text.Replace(@"\", string.Empty);
        Console.WriteLine(text.PadRight(20, '*'));
    }
}