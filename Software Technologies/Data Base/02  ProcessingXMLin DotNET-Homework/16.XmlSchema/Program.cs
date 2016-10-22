using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XmlSchema
{
    public class Program
    {
        public static void Main()
        {
            var schema = new XmlSchemaSet();
            var xsdPath = "../../../16.MusicCatalog.xsd";
            var validXmlPath = "../../../01.MusicCatalog.xml";
            var invalidXmlPath = "../../../16.InvalidMusicCatalog.xml";

            schema.Add(string.Empty, xsdPath);
            XDocument correctDocument = XDocument.Load(validXmlPath);
            XDocument incorrectDocument = XDocument.Load(invalidXmlPath);

            ValidateXML(schema, correctDocument);
            ValidateXML(schema, incorrectDocument);
        }

        private static void ValidateXML(XmlSchemaSet schema, XDocument correctDocument)
        {
            Console.WriteLine("Validating...");
            bool hasError = false;

            correctDocument.Validate(
                schema,
                (o, e) =>
                {
                    Console.WriteLine(e.Message);
                    hasError = true;
                });

            Console.WriteLine("XML document {0}", hasError ? "is not valid" : "is valid");
            Console.WriteLine();
        }
    }
}
