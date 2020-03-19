using System.Xml.Serialization;
using System.Collections.Generic;

namespace XmlTask
{
    public class Segments
    {
        [XmlElement("segment")]
        public List<string> Names { get; set; }
    }
}
