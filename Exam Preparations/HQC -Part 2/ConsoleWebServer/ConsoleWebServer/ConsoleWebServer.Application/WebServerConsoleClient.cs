using ConsoleWebServer.Framework.Models;
using System;
using System.Text;

namespace ConsoleWebServer.Application
{
    public class WebServerConsoleClient
    {
        private readonly ResponseProvider responseProvider;

        public WebServerConsoleClient()
        {
            this.responseProvider = new ResponseProvider();
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}