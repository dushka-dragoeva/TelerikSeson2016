using ConsoleWebServer.Framework.Models;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionResult
    {
        HttpResponse GetResponse();
    }
}
