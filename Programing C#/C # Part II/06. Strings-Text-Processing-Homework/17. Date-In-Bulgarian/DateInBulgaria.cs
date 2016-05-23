using System;
using System.Globalization;
using System.Threading;

public class DateInBulgaria
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.WriteLine("Enter date in format d.MM.yyyy H:mm:ss");

        var input = "1.03.2016 12:20:33";  /// Console.ReadLine();
        var dateFormat = "d.MM.yyyy H:mm:ss";
        DateTime date = DateTime.ParseExact(input, dateFormat, new CultureInfo("bg-BG"));
        date.AddHours(6);
        date.AddMinutes(30);
        Console.WriteLine("{0} {1}", date, date.DayOfWeek);
    }
}
