using System;
using System.Collections.Generic;
using DAL.Contract;
using Bll.Contract;

namespace DAL.Implementation3
{
    public class DataBasePersister : IPersister<TradeProcess>
    {
        private readonly string connectionString;

        public DataBasePersister(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Save(IEnumerable<TradeProcess> source)
        {
            using (TradeContext db = new TradeContext(this.connectionString))
            {
                foreach (var item in source)
                {
                    db.Trades.Add(item);
                    db.SaveChanges();
                }
            }
        }
    }
}
