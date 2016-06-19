namespace StartTest
{
    using System;
    using DivisibleBySevenAndThree;
    using IEnumerable.Tests;
    using LongestString;
    using StringBuilder.Test;
    using Students.Tests;
    using TimerWithDelegate;

    public class Startup
    {
        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            StringbulderExtentionTest.Run();
            IEnumerableCalculationTest.Run();
            StudentArrayTest.Run();
            DivisableByTowNumbersTest.Run();
            TimerDelegateTest.Run();
            StudentListTest.Run();
            LongestStringTest.Run();
        }
    }
}
