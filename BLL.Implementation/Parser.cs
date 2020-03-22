using System;
using System.Web;
using System.Linq;
using Bll.Contract;

namespace BLL.Implementation
{
    public class Parser : IParser<string, Url>
    {
        public Url Parse(string source)
        {
            Uri uri = new Uri(source);
            var parameters = HttpUtility.ParseQueryString(uri.Query);

            return new Url
            {
                HostName = uri.Host,
                Segments = uri.Segments.Select(s => s.Trim('/')).Where(s => !string.IsNullOrEmpty(s)).ToList(),
                Parameters = parameters.AllKeys.Select(key => new UrlParameterXML { Key = key, Value = parameters[key] }).ToList()
            };
        }
    }
}
