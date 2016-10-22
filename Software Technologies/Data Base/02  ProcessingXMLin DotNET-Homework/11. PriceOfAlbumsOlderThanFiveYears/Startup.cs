using System;
using System.Xml;
using Utilities;

namespace PriceOfAlbumsOlderThanFiveYears
{
    public class Startup
    {
        public static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Constants.XmlPath);
            var catalog = document.DocumentElement;
            var priceQueryXPath = "/catalog/album[year<2011]/price";
            var allPrices = catalog.SelectNodes(priceQueryXPath);

            foreach (XmlElement price in allPrices)
            {
                Console.WriteLine(price.InnerText);
            }
        }
    }
}
