using System;
using System.Collections.Generic;
using System.Text;
using Bll.Contract;

namespace BLL.Implementaion2
{
    public class StringToEntetiesConverter : IConverter<string, TradeProcess>
    {
        private readonly ILogger logger;
        private readonly IParser<string, TradeProcess> parser;
        private readonly IValidator<string> validator;

        public StringToEntetiesConverter(ILogger logger, IParser<string, TradeProcess> parser, IValidator<string> validator)
        {
            this.logger = logger;
            this.parser = parser;
            this.validator = validator;
        }

        public IEnumerable<TradeProcess> Convert(IEnumerable<string> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var line in source)
            {
                if (!this.validator.IsValid(line))
                {
                    this.logger.Log($"Not valid trade: {line}. Type of trade should contains 6 symbol.");
                }
                else
                {
                    var parsedLine = parser.Parse(line);
                    yield return parsedLine;
                }
            }
        }
    }
}
