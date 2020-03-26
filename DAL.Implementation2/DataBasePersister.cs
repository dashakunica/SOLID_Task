using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Contract;
using Bll.Contract;

namespace DAL.Implementation2
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
            string sql = string.Format("Insert Into Trades" +
                   "(CurrenceFrom, CurrencyTo, AmountOfTrade, TradePrice) " +
                   "Values(@CurrenceFrom, @CurrencyTo, @AmountOfTrade, @TradePrice)");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    foreach (var item in source)
                    {
                        cmd.Parameters.AddWithValue("@CurrenceFrom", item.Country);
                        cmd.Parameters.AddWithValue("@CurrencyTo", item.Currency);
                        cmd.Parameters.AddWithValue("@AmountOfTrade", item.AmountOfTrade);
                        cmd.Parameters.AddWithValue("@TradePrice", item.TradePrice);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
