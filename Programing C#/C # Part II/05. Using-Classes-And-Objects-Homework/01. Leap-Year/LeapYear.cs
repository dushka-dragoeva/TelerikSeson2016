using System;

public class LeapYear
{
    public static void Main(string[] args)
    {
        int year = int.Parse(Console.ReadLine());
        var output = DateTime.IsLeapYear(year) ? "Leap" : "Common";

        Console.WriteLine(output);
    }
}