using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModel
{
    [Serializable]
    public class ImageXmlModel
    {

        public string ImageUrl { get; set; }

        public string FileExtension { get; set; }
    }
}
