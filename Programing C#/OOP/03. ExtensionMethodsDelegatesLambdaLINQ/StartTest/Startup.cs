namespace StartTest
{
    using DivisibleBySevenAndThree;
    using IEnumerable.Tests;
    using StringBuilder.Test;
    using Students.Tests;

    public class Startup
    {
        public static void Main()
        {
            StringbulderExtentionTest.Run();
            IEnumerableCalculationTest.Run();
            DivisableByTowNumbersTest.Run();

            // StudentArrayTest.Run();
            // StudentListTest.Run();
        }
    }
}
