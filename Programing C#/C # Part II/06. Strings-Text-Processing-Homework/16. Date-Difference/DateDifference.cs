using System;

public class DateDifference
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first date in format dd.mm.yyyy");
        Console.WriteLine("Enter second date in format dd.mm.yyyy");

        var firstInput = "12.03.2016";  /// Console.ReadLine();
        DateTime firstDate = DateTime.Parse(firstInput);
        var secondInput = "12.05.2014"; /// Console.ReadLine();
        DateTime secondDate = DateTime.Parse(secondInput);

        var diffrence = (firstDate - secondDate).TotalDays;

        Console.WriteLine(diffrence);
    }
}
