using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Contract
{
    public class TradeProcess
    {
        public string Country { get; set; }

        public string Currency { get; set; }

        public int AmountOfTrade { get; set; }

        public decimal TradePrice { get; set; }
    }
}
