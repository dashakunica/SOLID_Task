using System.Xml.Serialization;
using System.Collections.Generic;


namespace XmlTask
{
    [XmlRoot("urlAddresses")]
    public class Urls
    {
        [XmlElement("urlAddress")]
        public List<UrlXML> UrlAdresses { get; set; }
    }
}
