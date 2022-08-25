using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Library.TradeLoaders;

namespace TechTest.Library
{
    public class TradeLoaderOld
    {
        public IEnumerable<Trade> LoadTrades()
        {
            var trades = new List<Trade>();
            
            trades.AddRange((new XmlTradeLoader()).LoadTrades("../../../Trades.xml"));            
            trades.AddRange((new CsvTradeLoader()).LoadTrades("../../../Trades.csv"));

            return trades;
        }
    }
}
