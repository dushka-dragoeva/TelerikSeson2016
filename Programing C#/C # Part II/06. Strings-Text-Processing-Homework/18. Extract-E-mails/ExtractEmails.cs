using System;
using System.Text.RegularExpressions;

public class ExtractEmails
{
    public static void Main(string[] args)
    {
        var text = Console.ReadLine();
        var pattern = "([A-Za-z0-9._-]+@[A-Za-z0-9_-]+.[A-Za-z0-9]{2,5})";
        var regex = new Regex(pattern);

        var emails = regex.Matches(text);

        foreach (var item in emails)
        {
            Console.WriteLine(item);
        }
    }
}
