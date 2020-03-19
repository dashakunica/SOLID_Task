using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTask
{
    public class Url
    {
        public string HostName { get; set; }

        public List<string> Segments { get; set; }

        public List<UrlParameterXML> Parameters { get; set; }
    }
}
