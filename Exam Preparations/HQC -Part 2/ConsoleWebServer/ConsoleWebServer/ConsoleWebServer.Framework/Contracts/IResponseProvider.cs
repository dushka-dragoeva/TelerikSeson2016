using ConsoleWebServer.Framework.Models;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    } 
}