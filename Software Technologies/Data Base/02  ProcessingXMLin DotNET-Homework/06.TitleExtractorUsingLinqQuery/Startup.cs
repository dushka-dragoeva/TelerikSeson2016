using System;
using System.Linq;
using System.Xml.Linq;
using Utilities;

namespace TitleExtractorUsingLinqQuery
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Song titles in the catalog:");
            XDocument catalog = XDocument.Load(Constants.XmlPath);

            var songs = catalog.Descendants("song")
                .Select(s => new { Title = s.Element("title").Value });

            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}
