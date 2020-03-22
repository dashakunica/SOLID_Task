using System.Xml.Serialization;
using System.Collections.Generic;

namespace Bll.Contract
{
    public class Segments
    {
        [XmlElement("segment")]
        public List<string> Names { get; set; }
    }
}
