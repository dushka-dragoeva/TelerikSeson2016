﻿namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            var webSever = new WebServerConsoleClient();
            webSever.Start();
        }
    }
}