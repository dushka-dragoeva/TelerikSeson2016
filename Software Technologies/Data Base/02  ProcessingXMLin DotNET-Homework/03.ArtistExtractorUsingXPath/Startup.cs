using System.Collections;
using System.Xml;

using Utilities;

namespace ArtistExtractorUsingXPath
{
    public class Program
    {
        public static void Main()
        {
            const string ArtistXPath = "/catalog/album/artist";
            XmlDocument document = new XmlDocument();
            document.Load(Constants.XmlPath);
            var catalog = document.DocumentElement;
            Hashtable autors = ExtractAllUniqueValuesByXPath(catalog, ArtistXPath);
            HashTablePrinter.Print(autors);
        }

        private static Hashtable ExtractAllUniqueValuesByXPath(XmlElement rootNode, string quiryXPath)
        {
            var uniqueValues = new Hashtable();
            var allNodes = rootNode.SelectNodes(quiryXPath);

            foreach (XmlNode node in allNodes)
            {
                var currentKey = node.InnerText;

                if (uniqueValues.ContainsKey(currentKey))
                {
                    uniqueValues[currentKey] = (int)uniqueValues[currentKey] + 1;
                }
                else
                {
                    uniqueValues[currentKey] = 1;
                }
            }

            return uniqueValues;
        }
    }
}
