using System;
using System.Globalization;
using System.Threading;

public class FormatNumber
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        var number = int.Parse(Console.ReadLine());

        var decimalNumberFormat = "{0,15:D}\n";
        var hexadecimalNumerFormat = "{0,15:X}\n";
        var percentageNumerFormat = "{0,15:P}\n";
        var scientificNumerFormat = "{0,15:E}\n";

        Console.WriteLine(string.Format(decimalNumberFormat + hexadecimalNumerFormat + percentageNumerFormat + scientificNumerFormat, number));
    }
}
