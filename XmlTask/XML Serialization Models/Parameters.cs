using System.Xml.Serialization;
using System.Collections.Generic;

namespace XmlTask
{
    public class Parameters
    {
        [XmlElement("parameter")]
        public List<UrlParameterXML> Params { get; set; }
    }
}
