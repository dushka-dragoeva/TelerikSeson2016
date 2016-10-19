using System.Net;

using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.Models.ActionResult
{
    public class ContentActionResult : BaseAtionResult, IActionResult
    {
        public ContentActionResult(HttpRequest request, object model)
            : base(request, model)
        {
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), "text/plain; charset=utf-8");
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}