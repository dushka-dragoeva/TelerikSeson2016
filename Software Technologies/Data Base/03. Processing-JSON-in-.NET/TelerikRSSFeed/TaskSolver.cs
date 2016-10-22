using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using TelerikRSSFeed.Models;

namespace TelerikRSSFeed
{
    public class TaskSolver
    {
        public static void DownloadRss(string url, string xmlFilename)
        {
            var myWebClient = new WebClient { Encoding = Encoding.UTF8 };
            myWebClient.DownloadFile(url, xmlFilename);
        }

        public static string ParseXmlToJson(string xmlFilename)
        {
            var xml = File.ReadAllText(xmlFilename);
            var doc = XDocument.Parse(xml);
            var jsonFromXml = JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.Indented);
            return jsonFromXml;
        }

        public static IEnumerable<JToken> GetAllviedoTitles(JObject jasnObject)
        {
            var titles = jasnObject["feed"]["entry"]
             .Select(entry => entry["title"]);
            return titles;
        }

        public static IEnumerable<Video> GetAllVideos(JObject jsonObject)
        {
            var videos = jsonObject["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));

            return videos;
        }

        public static string GenerateHtml(IEnumerable<Video> videos)
        {
            var html = new StringBuilder();
            html.AppendLine(
                @"<!DOCTYPE html>
    <html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
        <head>
        <style>
            div {float:left;
            width: 420px;
            height: 450px; 
            padding: 10px; 
            margin:5px; 
            background-color:#9F3FFF;
            border-radius:10px;
        }
       iframe {width: 420px ;
                height: 345px;
                    }
            </style>
        </head>
        <body>");
            foreach (var video in videos)
            {
                html.AppendFormat(
                        @"<div>
            <iframe src =""http://www.youtube.com/embed/{1}?autoplay=0""frameborder =""0"" allowfullscreen>
            </iframe>
            <h3>{2}</h3>
            <a href=""{0}"">Go to YouTube</a>
        </div>
        ",
                video.Link.Href,
                video.Id,
                video.Title);
            }

            html.AppendLine(
       @"</body>
     </html>");
            return html.ToString();
        }
    }
}
