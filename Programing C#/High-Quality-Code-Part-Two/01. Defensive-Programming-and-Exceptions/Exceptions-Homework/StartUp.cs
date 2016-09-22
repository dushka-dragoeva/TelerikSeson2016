using ExceptionsHomework.Tests;

namespace ExceptionsHomework
{
    public class StartUp
    {
        public static void Main()
        {
            ExamTester.Run();
            UtilitiesTester.RunSubSubsequeneTest();
            UtilitiesTester.RunExtractEndingTest();
            UtilitiesTester.RunCheckPrimeTest();
        }
    }
}