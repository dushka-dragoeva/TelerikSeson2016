using System;
using System.Text;
using System.Xml;
using Utilities;

namespace CreatingAlbumXml
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(Constants.DocumentCreated);
            const string PathToWrite = "../../Albums.xml";
            CreateAlbumsXml(Constants.XmlPath, PathToWrite);
        }

        private static void CreateAlbumsXml(string pathToRead, string pathToWrite)
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            var writer = new XmlTextWriter(pathToWrite, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                writer.WriteAttributeString("name", "My catalog");

                var reader = XmlReader.Create(pathToRead);

                using (reader)
                {
                    writer.WriteStartElement("album");
                    while (reader.Read())
                    {
                        Album album = new Album();
                        writer.WriteStartElement("album");
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                        {
                            writer.WriteStartElement("album");
                            album.Name = reader.ReadElementString();
                            writer.WriteElementString("name", album.Name);
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "authors"))
                        {
                            album.Author = reader.ReadElementString();
                            writer.WriteElementString("author", album.Name);
                        }
                    }

                    writer.WriteEndElement();
                }
            }
        }
    }
}
