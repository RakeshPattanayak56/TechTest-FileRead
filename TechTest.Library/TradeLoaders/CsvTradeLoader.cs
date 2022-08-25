using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Library.TradeLoaders
{
    public class CsvTradeLoader
    {
        public IEnumerable<Trade> LoadTrades(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string tradeLine = reader.ReadLine();
                    string ext = Path.GetExtension(path);
                    var parts = tradeLine.Split(',');
                    if (ext == ".pip")
                    {
                        parts = tradeLine.Split('|');
                    }
                    var trade = new Trade
                    {
                        TradeType = parts[0],
                        Identifier = parts[1],
                        PaymentCurrency = parts[2],                    
                        Quantity = double.Parse(parts[3]),
                        Price = double.Parse(parts[4]),
                        Symbol = parts[5],
                        TradeDate = DateTime.Parse(parts[6]),
                    };

                    yield return trade;
                }
            }
        }

    }
}
