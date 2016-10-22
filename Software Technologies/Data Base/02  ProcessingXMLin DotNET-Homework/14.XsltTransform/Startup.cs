using System;
using System.Xml.Xsl;
using Utilities;

namespace XsltTransform
{
    public class Startup
    {
        public static void Main()
        {
            var xsltTransformer = new XslCompiledTransform();
            var xslPath = "../../../13.style.xslt";
            var htmlPath = "../../MusicCatalog.html";

            xsltTransformer.Load(xslPath);
            xsltTransformer.Transform(Constants.XmlPath, htmlPath);
            Console.WriteLine(Constants.DocumentCreated);
        }
    }
}