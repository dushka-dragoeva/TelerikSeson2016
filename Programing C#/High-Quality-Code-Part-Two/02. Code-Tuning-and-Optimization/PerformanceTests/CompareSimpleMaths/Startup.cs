namespace CompareSimpleMaths
{
    using System;
    using System.Text;

    public class Startup
    {
        private const int ValueIntToTest = 1;
        private const long ValueLongToTest = 1L;
        private const float ValueFloatToTest = 1.0F;
        private const double ValueDoubleToTest = 1.0;
        private const decimal ValueDecimalToTest = 1.0M;

        public static void Main()
        {
            DrawLineOnConsole("ADD TESTS");
            TestMethods.TestOperation(ValueIntToTest, Operations.Add);
            TestMethods.TestOperation(ValueLongToTest, Operations.Add);
            TestMethods.TestOperation(ValueFloatToTest, Operations.Add);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Add);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Add);

            DrawLineOnConsole("SUBSTRACT TESTS");
            TestMethods.TestOperation(ValueIntToTest, Operations.Substaction);
            TestMethods.TestOperation(ValueLongToTest, Operations.Substaction);
            TestMethods.TestOperation(ValueFloatToTest, Operations.Substaction);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Substaction);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Substaction);

            DrawLineOnConsole("DIVIDE TESTS");
            TestMethods.TestOperation(ValueIntToTest, Operations.Division);
            TestMethods.TestOperation(ValueLongToTest, Operations.Division);
            TestMethods.TestOperation(ValueFloatToTest, Operations.Division);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Division);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Division);

            DrawLineOnConsole("MULTIPLY TESTS");
            TestMethods.TestOperation(ValueIntToTest, Operations.Multiply);
            TestMethods.TestOperation(ValueLongToTest, Operations.Multiply);
            TestMethods.TestOperation(ValueFloatToTest, Operations.Multiply);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Multiply);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Multiply);

            DrawLineOnConsole("INCREMENT TESTS");
            TestMethods.TestOperation(ValueIntToTest, Operations.Increment);
            TestMethods.TestOperation(ValueLongToTest, Operations.Increment);
            TestMethods.TestOperation(ValueFloatToTest, Operations.Increment);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Increment);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Increment);
        }

        public static void DrawLineOnConsole(string text)
        {
            var result = new StringBuilder();
            result.AppendFormat(new string('*', 20));
            result.Append(" " + text + " ");
            result.AppendFormat(new string('*', 20));
            Console.WriteLine(result);
        }
    }
}
