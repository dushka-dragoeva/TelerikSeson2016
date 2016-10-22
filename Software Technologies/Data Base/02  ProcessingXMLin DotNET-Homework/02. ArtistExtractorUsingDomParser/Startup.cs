using System;
using System.Collections;
using System.Xml;

using Utilities;

namespace ArtistExtractorUsingDomParser
{
    public class Program
    {
        public static void Main()
        {
            const string Artist = "artist";
            XmlDocument document = new XmlDocument();
            document.Load(Constants.XmlPath);
            var catalog = document.DocumentElement;
            Hashtable autors = ExtractAllUniqueValuesByTagName(catalog, Artist);
            HashTablePrinter.Print(autors);
        }

        private static Hashtable ExtractAllUniqueValuesByTagName(XmlElement rootNode, string tagName)
        {
            var uniqueValues = new Hashtable();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentKey = node[tagName].InnerText;

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
