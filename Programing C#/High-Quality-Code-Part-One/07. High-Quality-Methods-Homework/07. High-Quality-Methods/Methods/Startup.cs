using System;
using System.Globalization;
using System.Threading;

namespace Methods
{
    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine(Methods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.DigitToWord(5));

            Console.WriteLine(Methods.FindMaxValueInArray(5, -1, 3, 2, 14, 2, 3));

            var printer = new FormatPrinter();
            Console.WriteLine(printer.PrintWithPrecisionTowDigit(1.3));
            Console.WriteLine(printer.PrintAsPercentage(0.75));
            Console.WriteLine(printer.PrintAlignedRight(2.30));

            Console.WriteLine(Methods.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + Methods.CheckIfHorizontalLine(3, 3));
            Console.WriteLine("Vertical? " + Methods.ChekIfVertivcalLine(-1, 2.5));

            Student peter = new Student("Peter", "Ivanov");
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student("Stella", "Markova");
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine($"{peter.FirstName} older than {stella.FirstName} -> {peter.IsOlderThan(stella)}");
        }
    }
}
