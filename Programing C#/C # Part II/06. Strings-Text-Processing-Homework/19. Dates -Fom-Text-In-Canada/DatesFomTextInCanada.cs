using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

public class DatesFomTextInCanada
{
    public static void Main(string[] args)
    {
        /// Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Ca");
        /// Thread.CurrentThread.CurrentCulture =  CultureInfo.InvariantCulture;
        var text = Console.ReadLine();
        var pattern = "[0-3][0-9]\\.[01][1-9]\\.[1-9]{1,4}";

        var dates = FindAllMaches(text, pattern);
        string dateFormat = "dd.MM.yyyy";

        foreach (var item in dates)
        {
            var currentDate = DateTime.ParseExact(item, dateFormat, new CultureInfo("en-CA")).ToLongDateString();
            Console.WriteLine(currentDate);
        }
    }

    private static List<string> FindAllMaches(string text, string pattern)
    {
        var patternMatches = new List<string>();

        var regex = new Regex(pattern);

        var maches = regex.Matches(text);

        foreach (var item in maches)
        {
            patternMatches.Add(item.ToString());
        }

        return patternMatches;
    }
}
