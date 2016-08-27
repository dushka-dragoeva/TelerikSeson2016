using System;

namespace Printer
{
    internal class BooleanPrinter
    {
        internal void PrintBooleanAsAString(bool value)
        {
            string booleanString = value.ToString();
            Console.WriteLine(booleanString);
        }
    }
}
