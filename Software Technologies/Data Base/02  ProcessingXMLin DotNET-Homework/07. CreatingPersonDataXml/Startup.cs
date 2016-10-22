using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Utilities;

namespace CreatingPersonDataXml
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(Constants.DocumentCreated);
            const string PathToRead = "../../PersonData.txt";
            var reader = new StreamReader(PathToRead);
            var people = new List<Person>();

            using (reader)
            {
                var name = reader.ReadLine();
                while (true)
                {
                    var person = new Person();
                    person.Name = name;
                    person.Address = reader.ReadLine();
                    person.PhoneNumber = reader.ReadLine();
                    people.Add(person);
                    name = reader.ReadLine();

                    if (name == null)
                    {
                        break;
                    }
                }
            }

            const string PathToWrite = "../../PersonData.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            var writer = new XmlTextWriter(PathToWrite, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                foreach (var person in people)
                {
                    WritePersonData(writer, person.Name, person.Address, person.PhoneNumber);
                }
            }
        }

        private static void WritePersonData(XmlWriter writer, string name, string address, string phoneNumber)
        {
            writer.WriteStartElement("person");
            writer.WriteElementString("name", name);
            writer.WriteElementString("address", address);
            writer.WriteElementString("phoneNumber", phoneNumber);
            writer.WriteEndElement();
        }
    }
}