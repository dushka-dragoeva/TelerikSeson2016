using System;
using System.IO;
using System.Xml.Linq;
using Utilities;

namespace DirectoryTraverserUsingLinqToXml
{
    public class Startup
    {
        public static void Main()
        {
            var directoryPath = "../../../../02  ProcessingXMLin DotNET-Homework";
            var rootDirectory = new DirectoryInfo(directoryPath);
            string rootString = "root";

            XElement directoryTree = new XElement(rootString);
            directoryTree.Add(TraverseDirectory(rootDirectory));
            var pathToWrite = "../../DirectoriesWithLinqToXml.xml";
            directoryTree.Save(pathToWrite);
            Console.WriteLine(Constants.DocumentCreated);
        }

        private static XElement TraverseDirectory(DirectoryInfo directory)
        {
            string dirString = "dir";
            string nameString = "name";
            var dirElement = new XElement(dirString, new XAttribute(nameString, directory.Name));

            foreach (var dir in directory.GetDirectories())
            {
                dirElement.Add(TraverseDirectory(dir));
            }

            string fileString = "file";

            foreach (var file in directory.GetFiles())
            {
                dirElement.Add(new XElement(fileString, new XAttribute(nameString, file.Name)));
            }

            return dirElement;
        }
    }
}