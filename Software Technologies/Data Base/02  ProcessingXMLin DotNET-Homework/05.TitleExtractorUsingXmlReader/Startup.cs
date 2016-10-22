using System;
using System.Xml;
using Utilities;

namespace TitleExtractorUsingXmlReader
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Song titles in the catalog:");
            ReadAllSongTitles(Constants.XmlPath);
        }

        private static void ReadAllSongTitles(string pathToRead)
        {
            var reader = XmlReader.Create(pathToRead);
            using (reader)
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
