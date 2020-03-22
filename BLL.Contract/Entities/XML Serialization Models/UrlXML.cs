using System.Xml.Serialization;

namespace Bll.Contract
{
    public class UrlXML
    {
        [XmlElement("host")]
        public Host Host { get; set; }

        /// <summary>
        /// Gets or sets url segments.
        /// </summary>
        [XmlElement("uri")]
        public Segments Uri { get; set; }

        /// <summary>
        /// Gets or sets url parameters.
        /// </summary>
        [XmlElement("parameters")]
        public Parameters Parameters { get; set; }
    }
}
