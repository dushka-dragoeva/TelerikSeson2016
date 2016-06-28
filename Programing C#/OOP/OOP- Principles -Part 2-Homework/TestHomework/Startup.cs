namespace TestHomework
{
    using BankAccounts;
    using RangeExceptions;
    using Shapes;

    public class Startup
    {
        public static void Main()
        {
            ShapeTest.Run();
            BankAccountTest.Run();
            InvalidRangeExceptionTest.Run();
        }
    }
}
