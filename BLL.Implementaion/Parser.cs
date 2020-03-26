using System;
using Bll.Contract;

namespace BLL.Implementaion2
{
    public class Parser : IParser<string, TradeProcess>
    {
        public TradeProcess Parse(string source)
        {
            string[] splitSource = source.Split(',');

            return new TradeProcess
            {
                Country = splitSource[0].Substring(0, 3),
                Currency = splitSource[0].Substring(3, 3),
                AmountOfTrade = Int32.Parse(splitSource[1]),
                TradePrice = Decimal.Parse(splitSource[2]),
            };
        }
    }
}
