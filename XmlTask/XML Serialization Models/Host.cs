using System.Xml.Serialization;

namespace XmlTask
{
    public class Host
    {
        [XmlAttribute("name")]
        public string HostName { get; set; }
    }
}
