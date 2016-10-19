using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.Models.ActionResult
{
    public abstract class ActionResultDecorator : IActionResult
    {
        private readonly IActionResult actionResult;

        public ActionResultDecorator(IActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public HttpResponse GetResponse()
        {
            var response = this.actionResult.GetResponse();
            this.UpdateResponse(response);
            return response;
        }

        public abstract void UpdateResponse(HttpResponse baseResponse);
    }
}
