namespace Printer
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var printer = new BooleanPrinter();
            printer.PrintBooleanAsAString(true);
        }
    }
}
