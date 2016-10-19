using System.Collections.Generic;
using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.Models.ActionResult
{
    public abstract class BaseAtionResult : IActionResult
    {
        public readonly object model;

        public BaseAtionResult(HttpRequest request, object model)
        {
            this.model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public abstract HttpResponse GetResponse();
    }
}
