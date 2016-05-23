using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        var url = Console.ReadLine();
        Console.WriteLine(ParseUrl(url));
    }

    private static string ParseUrl(string url)
    {
        var parsedUrl = new StringBuilder();

        var outputFormat = "[protocol] = {0}\n[server] = {1}\n[resource] = {2}";

        var endProtocolIndex = url.IndexOf("://");
        var protocol = url.Substring(0, endProtocolIndex);
        var startserverIndex = endProtocolIndex + 3;
        var endServerIndex = url.IndexOf("/", endProtocolIndex + 3);
        var server = url.Substring(startserverIndex, endServerIndex - startserverIndex);
        var resourse = url.Substring(endServerIndex);

        parsedUrl.AppendFormat(outputFormat, protocol, server, resourse);

        return parsedUrl.ToString();
    }
}