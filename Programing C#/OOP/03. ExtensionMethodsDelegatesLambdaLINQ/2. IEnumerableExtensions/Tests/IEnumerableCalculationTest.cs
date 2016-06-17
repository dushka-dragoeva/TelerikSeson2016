namespace IEnumerable.Tests
{
    using System;
    using System.Collections.Generic;
    using Extentions;

    public class IEnumerableCalculationTest
    {
        public static void Run()
        {
            var someCollection = new List<int>() { 1, -6, 16, 8, 35 };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("02. IEnumerable extentions");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Test List containing integers.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Product:\t{someCollection.Product()}");
            Console.WriteLine($"Sum:\t\t{someCollection.Sum()}");
            Console.WriteLine($"Avarage:\t{someCollection.Avarage()}");
            Console.WriteLine($"Max element:\t{someCollection.Max()}");
            Console.WriteLine($"Min element:\t{someCollection.Min()}");

            var someArray = new double[] { 1.1, -6.36, 16.78, 8.79, 35.9 };

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Test array containing float-pointing numbers.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Product:\t{someArray.Product()}");
            Console.WriteLine($"Sum:\t\t{someArray.Sum()}");
            Console.WriteLine($"Avarage:\t{someArray.Avarage()}");
            Console.WriteLine($"Max element:\t{someArray.Max()}");
            Console.WriteLine($"Min element:\t{someArray.Min()}");
        }
    }
}
