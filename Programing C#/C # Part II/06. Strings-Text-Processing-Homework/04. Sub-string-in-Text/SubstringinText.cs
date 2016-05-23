using System;
using System.Text.RegularExpressions;

public class SubstringinText
{
    public static void Main()
    {
        var substring = Console.ReadLine().ToLower();
        var text = Console.ReadLine().ToLower();

       // Console.WriteLine(GetSubstringOccurenceCount(text, substring));
        Console.WriteLine(GetSubstringCount(text, substring));
    }
    
    private static int GetSubstringOccurenceCount(string text, string substring)
    {
        return Regex
            .Matches(text, substring, RegexOptions.IgnoreCase)
            .Count;
    }
    
    private static int GetSubstringCount(string text, string substring)
    {
        int counter = 0;
        int nextIndex = text.IndexOf(substring);

        while (nextIndex != -1)
        {
            nextIndex = text.IndexOf(substring, nextIndex + 1);
            counter++;
        }

        return counter;
    }
}