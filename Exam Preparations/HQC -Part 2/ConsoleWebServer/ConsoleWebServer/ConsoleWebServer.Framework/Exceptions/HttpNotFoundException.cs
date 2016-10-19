using System;

namespace ConsoleWebServer.Framework.Exceptions
{
    public class HttpNotFound : Exception
    {
        public const string ClassName = "HttpNotFoundException";

        public HttpNotFound(string message)
            : base(message)
        {
        }
    }
}