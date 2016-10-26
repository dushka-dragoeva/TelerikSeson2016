using System;

namespace Singleton
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
