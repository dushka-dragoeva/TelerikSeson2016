using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModel
{
    [Serializable]
    [XmlType("Post")]
    public class PostXmlModel
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}
