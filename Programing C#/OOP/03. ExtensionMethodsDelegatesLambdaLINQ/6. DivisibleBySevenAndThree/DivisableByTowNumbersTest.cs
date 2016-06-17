namespace DivisibleBySevenAndThree
{
    using System;
    using Extentions;
    using Printer = Utilities.Extentions.IEnumerable;

    public class DivisableByTowNumbersTest
    {
        public static void Run()
        {
            var numbers = new long[] { 3456, 42, 865, 33, 67, 84, 49 };

            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("06. Divisible by 7 and 3");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Found with Lambda");
            Printer.PrintCollection(IntegerDevider.FindDivisibleUsingLambda(numbers, 3, 7));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Found with LINQ");
            Printer.PrintCollection(IntegerDevider.FindDivisibleUsingLinq(numbers, 3, 7));
        }
    }
}