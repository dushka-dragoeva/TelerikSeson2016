using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarSystem.Console.XmlModels
{
    public class CarOutputXmlModel
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlAttribute]
        public string Manufacturer { get; set; }

        [XmlAttribute]
        public string Model { get; set; }

        [XmlAttribute]
        public int Year { get; set; }

        [XmlAttribute]
        public decimal Price { get; set; }

        public string TransmissionType { get; set; }

        public  DealerXmlModel Dealer { get; set; }
    }
}

