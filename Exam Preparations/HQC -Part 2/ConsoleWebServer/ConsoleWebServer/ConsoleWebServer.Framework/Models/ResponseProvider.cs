namespace ConsoleWebServer.Framework.Models
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    using Action;
    using Contracts;
    using Exceptions;

    public class ResponseProvider
    {
        private HttpResponse Process(HttpRequest request)
        {
            if (request.Method.ToLower() == "options")
            {
                var routes =
                    Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                        .Select(
                            x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                        .SelectMany(
                            x =>
                            x.Methods.Select(
                                m =>
                                string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                        .ToList();

                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }
            else if (new StaticFileHandler().CanHandle(request))
            {
                return new StaticFileHandler().Handle(request);
            }
            else if (request.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    var controller = CreateController(request);
                    var actionInvoker = new ActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFound exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }
                return response;
            }
            else
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
            }
        }

        private Controller CreateController(HttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFound(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }
            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }

        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            try
            {
                var requestParser = new HttpRequest("GET", "/", "1.1");
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }
            var response = this.Process(request);
            return response;
        }
    }
}