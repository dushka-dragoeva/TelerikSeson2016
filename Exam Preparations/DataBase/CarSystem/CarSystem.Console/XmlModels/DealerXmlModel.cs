using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarSystem.Console.XmlModels
{
    public class DealerXmlModel
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArrayItem(ElementName = "City")]
        public List<string> Cities { get; set; }
    }
}
