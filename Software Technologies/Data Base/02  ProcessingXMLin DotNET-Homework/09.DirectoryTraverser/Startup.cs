using System;
using System.IO;
using System.Text;
using System.Xml;
using Utilities;

namespace DirectoryTraverser
{
    public class Startup
    {
        public static void Main()
        {
            var directoryPath = "../../../../02  ProcessingXMLin DotNET-Homework";
            var rootDirectory = new DirectoryInfo(directoryPath);
            GenerateXmlDocumentForTraversedDirectory(rootDirectory);
            Console.WriteLine(Constants.DocumentCreated);
        }

        private static void GenerateXmlDocumentForTraversedDirectory(DirectoryInfo rootDirectory)
        {
            const string PathToWrite = "../../Directories.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            var writer = new XmlTextWriter(PathToWrite, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                TraverseDirectory(writer, rootDirectory);
                writer.WriteEndDocument();
            }
        }

        private static void TraverseDirectory(XmlWriter writer, DirectoryInfo directory)
        {
            foreach (var dir in directory.GetDirectories())
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", dir.Name);
                TraverseDirectory(writer, dir);
            }

            foreach (var file in directory.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}