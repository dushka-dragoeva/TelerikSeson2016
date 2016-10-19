using System;

using GreetingHelloDI.Contracts;

namespace GreetingHelloDI.Models
{
    public class ConsoleWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
