using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Library.TradeLoaders;

namespace TechTest.Library
{
    public class TradeLoader : ITradeLoader
    {
        private string GetType(string path)
        {
            if (path.Contains(".xml") || path.Contains(".pip") || path.Contains(".csv"))
            {
                return Path.GetExtension(path);
            }
            else
            {
                return "Invalid";
            }
        }
        public IEnumerable<Trade> LoadTrades(string fileName)
        {
            var trades = new List<Trade>();
            switch (GetType(fileName))
            {
                case ".xml":
                    trades.AddRange((new XmlTradeLoader()).LoadTrades(fileName));
                    break;
                case ".csv":
                    trades.AddRange((new CsvTradeLoader()).LoadTrades(fileName));
                    break;
                case ".pip":
                    trades.AddRange((new CsvTradeLoader()).LoadTrades(fileName));
                    break;
                default:
                    //Console.WriteLine("Invalid file name");
                    break;
            }
            return trades;
        }
    }

}
