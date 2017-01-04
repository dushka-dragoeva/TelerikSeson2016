using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModel
{
    [Serializable]
    [XmlType("Friendship")]
    public class FriendshipXmlModel
    {
        [XmlAttribute]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public UserXmlModel FirstUser { get; set; }

        public UserXmlModel SecondUser { get; set; }

        [XmlArrayItem(ElementName = "Message")]
        public List<MessageXmlModel> Messages { get; set; }
    }
}
