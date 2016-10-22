using System;
using System.Linq;
using System.Xml.Linq;
using Utilities;

namespace PriceOfAlbumsWithLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument catalog = XDocument.Load(Constants.XmlPath);

            var allPrices = catalog.Descendants("album")
                .Where(a => int.Parse(a.Element("year").Value) < 2011)
                .Select(a => new { Price = a.Element("price").Value });

            foreach (var item in allPrices)
            {
                Console.WriteLine(item.Price);
            }
        }
    }
}