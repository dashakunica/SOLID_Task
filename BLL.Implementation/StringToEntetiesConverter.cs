using System;
using System.Collections.Generic;
using System.Text;
using Bll.Contract;

namespace BLL.Implementation
{
    public class StringToEntetiesConverter : IConverter<string, UrlXML>
    {
        private readonly ILogger logger;
        private readonly IParser<string, Url> parser;
        private readonly IValidator<string> validator;

        public StringToEntetiesConverter(ILogger logger, IParser<string, Url> parser, IValidator<string> validator)
        {
            this.logger = logger;
            this.parser = parser;
            this.validator = validator;
        }

        public IEnumerable<UrlXML> Convert(IEnumerable<string> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Urls urls = new Urls
            {
                UrlAdresses = new List<UrlXML>()
            };

            foreach (var line in source)
            {
                if (!this.validator.IsValid(line))
                {
                    this.logger.Log($"Not valid url: {line}");
                }
                else
                {
                    var parsedLine = parser.Parse(line);
                    var urlModel = UrlToUrlModel(parsedLine);
                    yield return urlModel;
                }
            }
        }

        private UrlXML UrlToUrlModel(Url url)
        {
            UrlXML result = new UrlXML
            {
                Host = new Host
                {
                    HostName = url.HostName,
                },

                Parameters = new Parameters
                {
                    Params = new List<UrlParameterXML>(),
                },

                Uri = new Segments
                {
                    Names = new List<string>(),
                },
            };

            url.Parameters.ForEach(x => result.Parameters.Params.Add(new UrlParameterXML { Key = x.Key, Value = x.Value }));
            url.Segments.ForEach(x => result.Uri.Names.Add(x));

            return result;
        }

    }
}
