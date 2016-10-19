using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Models;
using ConsoleWebServer.Framework.Models.ActionResult;

namespace ConsoleWebServer.Framework
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
        {
            this.Request = request;
        }

        public HttpRequest Request { get; private set; }

        protected IActionResult Content(object model)
        {
            return new ContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResult(this.Request, model);
        }
    } 
}