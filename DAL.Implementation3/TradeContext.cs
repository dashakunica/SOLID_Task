using System;
using System.Collections.Generic;
using System.Text;
using Bll.Contract;
using System.Data.Entity;

namespace DAL.Implementation3
{
    public class TradeContext : DbContext
    {
        public TradeContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<TradeProcess> Trades { get; set; }
    }
}
