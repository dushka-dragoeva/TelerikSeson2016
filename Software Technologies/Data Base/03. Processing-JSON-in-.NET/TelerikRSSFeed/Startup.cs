using System;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TelerikRSSFeed
{
    public class Startup
    {
        private const string XmlUrl = " https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
        private const string XmlFile = "../../rssFeed.xml";
        private const string HtmlFile = "../../rssFeed.html";

        public static void Main()
        {
            TaskSolver.DownloadRss(XmlUrl, XmlFile);

            var json = TaskSolver.ParseXmlToJson(XmlFile);

            var jsonToObject = JObject.Parse(json);

            var titles = TaskSolver.GetAllviedoTitles(jsonToObject);
            Console.WriteLine(string.Join(Environment.NewLine, titles));

            var videos = TaskSolver.GetAllVideos(jsonToObject);

            var html = TaskSolver.GenerateHtml(videos);
            File.WriteAllText(HtmlFile, html, Encoding.UTF8);
        }
    }
}
