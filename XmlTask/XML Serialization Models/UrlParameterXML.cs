using System.Xml.Serialization;

namespace XmlTask
{
    public class UrlParameterXML
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
