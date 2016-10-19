using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.Models.ActionResult
{
    public class ActionResultWithoutCachingDecorator : ActionResultDecorator
    {
        public ActionResultWithoutCachingDecorator(IActionResult actionResult)
        : base(actionResult)
        {
        }

        public override void UpdateResponse(HttpResponse baseResponse)
        {
            baseResponse.AddHeader("Cache-Control", "private, max-age=0, no-cache");
        }
    }
}
