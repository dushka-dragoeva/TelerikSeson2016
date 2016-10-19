using System;
using ConsoleWebServer.Framework.Models.Action;

namespace ConsoleWebServer.Framework.Exeptions
{
    public class ParserException : Exception
    {
        public ParserException(string message, ActionDescriptor request = null)
            : base(message)
        {
        }
    }
}
