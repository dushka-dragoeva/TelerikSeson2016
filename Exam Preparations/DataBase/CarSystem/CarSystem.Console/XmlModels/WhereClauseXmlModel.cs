using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarSystem.Console.XmlModels
{
    [Serializable]
    public class WhereClauseXmlModel
    {
        [XmlAttribute]
        public string PropertyName { get; set; }

        [XmlAttribute]
        public string Type { get; set; }
    }
}
