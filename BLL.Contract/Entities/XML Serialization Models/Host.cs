using System.Xml.Serialization;

namespace Bll.Contract
{
    public class Host
    {
        [XmlAttribute("name")]
        public string HostName { get; set; }
    }
}
