using System.Xml.Serialization;
using System.Collections.Generic;


namespace Bll.Contract
{
    [XmlRoot("urlAddresses")]
    public class Urls
    {
        [XmlElement("urlAddress")]
        public List<UrlXML> UrlAdresses { get; set; }
    }
}
