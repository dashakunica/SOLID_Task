using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Bll.Contract;

namespace BLL.Implementation
{
    public class ToXDocumentConverter
    {
        private readonly ILogger logger;
        private readonly IParser<string, Url> parser;
        private readonly IValidator<string> validator;

        public ToXDocumentConverter(ILogger logger, IParser<string, Url> parser, IValidator<string> validator)
        {
            this.logger = logger;
            this.parser = parser;
            this.validator = validator;
        }

        public XDocument Convert(IEnumerable<string> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            List<XElement> elements = new List<XElement>();
            foreach (var line in source)
            {
                if (!this.validator.IsValid(line))
                {
                    this.logger.Log($"Not valid url: {line}");
                }
                else
                {
                    var url = parser.Parse(line);
                    elements.Add(UrlToXElement(url));
                }
            }

            XDocument document = new XDocument();
            document.Add(new XElement("urlAddresses", elements));

            return document;
        }

        private XElement UrlToXElement(Url url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var host = new XElement("host", new XAttribute("name", url.HostName));

            XElement uri = null;
            if (url.Segments.Count > 0)
            {
                uri = new XElement("uri");
                url.Segments.ForEach(s => uri.Add(new XElement("segment", s)));
            }

            XElement parameters = null;
            if (url.Parameters.Count > 0)
            {
                parameters = new XElement("parameters");
                url.Parameters.ForEach(
                    p => parameters.Add(new XElement("parameter",
                        new XAttribute("key", p.Key ?? string.Empty),
                        new XAttribute("value", p.Value ?? string.Empty))));
            }


            return new XElement("urlAddress", host, uri, parameters);
        }
    }
}
