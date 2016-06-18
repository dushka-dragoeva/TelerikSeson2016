namespace DivisibleBySevenAndThree
{
    using System;
    using Extentions;
    using Utilities.Extentions;

    public class DivisableByTowNumbersTest
    {
        public static void Run()
        {
            var numbers = new long[] { 3456, 42, 865, 33, 67, 84, 49 };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("06. Divisible by 7 and 3");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Found with Lambda");
            numbers.FindDivisibleUsingLambda(3, 7).PrintCollection();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Found with LINQ");
            numbers.FindDivisibleUsingLinq(3, 7).PrintCollection();
        }
    }
}