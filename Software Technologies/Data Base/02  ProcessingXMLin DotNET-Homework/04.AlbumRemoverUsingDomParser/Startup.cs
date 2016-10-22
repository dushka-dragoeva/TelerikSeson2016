using System;
using System.Xml;

namespace AlbumRemoverUsingDomParser
{
    public class Startup
    {
        public static void Main()
        {
            const string ReadPath = "../../MusicCatalog.xml";
            const string SavePath = "../../UpdatedCatalog.xml";
            const decimal Price = 20m;
            XmlDocument document = new XmlDocument();
            document.Load(ReadPath);
            var catalog = document.DocumentElement;
            DeleteAllAlbumsWithGivenPrice(catalog, Price);
            document.Save(SavePath);
            Console.WriteLine("Saved in UpdatedCatalog.xml");
        }

        private static void DeleteAllAlbumsWithGivenPrice(XmlElement rootNode, decimal maxPrice)
        {
            var counter = 0;
            foreach (XmlElement album in rootNode.SelectNodes("album"))
            {
                decimal currentPrice = decimal.Parse(album["price"].InnerText);
                if (currentPrice > maxPrice)
                {
                    rootNode.RemoveChild(album);
                    counter++;
                }
            }

            Console.WriteLine($"{counter} albums are deleted.");
        }
    }
}