using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModel
{
    [Serializable]
    public class MessageXmlModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}
