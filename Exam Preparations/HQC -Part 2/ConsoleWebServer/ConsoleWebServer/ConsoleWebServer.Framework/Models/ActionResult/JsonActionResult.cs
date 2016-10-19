namespace ConsoleWebServer.Framework.Models.ActionResult
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Contracts;
    using Newtonsoft.Json;

    public class JsonActionResult : BaseAtionResult, IActionResult
    {
        public readonly object model;

        public JsonActionResult(HttpRequest request, object model) :
            base(request, model)
        {
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(model);
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(Request.ProtocolVersion, GetStatusCode(), GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
            foreach (var responseHeader in ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }
            return response;
        }
    }
}