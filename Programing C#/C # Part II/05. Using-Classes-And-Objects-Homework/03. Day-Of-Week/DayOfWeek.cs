using System;

public class DayOfWeek
{
    public static void Main(string[] args)
    {
        var today = DateTime.Now.DayOfWeek;
        Console.WriteLine(today);
    }
}