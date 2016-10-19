using System;
using System.Collections.Generic;
using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.Models.ActionResult
{
    public class ActionResultWithCorsDecorator<TResult> : ActionResultDecorator
    {
        public ActionResultWithCorsDecorator(IActionResult actionResult) 
            : base(actionResult)
        {
        }

        //public ActionResultWithCorsDecorator(HttpRequest request, string corsSettings)
        //    : base(request)
        //{
        //    this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        //}

        public override void UpdateResponse(HttpResponse baseResponse)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}
