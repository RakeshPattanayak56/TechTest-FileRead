using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TechTest.Library.TradeLoaders
{
    public class XmlTradeLoader
    {
        public IEnumerable<Trade> LoadTrades(string path)
        {
            var doc = XDocument.Load(path);

            return doc.Root.Elements("trade").Select(tradeElem => new Trade{  Identifier= tradeElem.Attribute("identifier").Value
                ,  TradeType=tradeElem.Attribute("tradeType").Value
                ,  PaymentCurrency=tradeElem.Attribute("paymentCurrency").Value
                ,  Quantity = double.Parse(tradeElem.Attribute("quantity").Value)
                ,  Price = double.Parse(tradeElem.Attribute("price").Value)
                ,  TradeDate=DateTime.Parse(tradeElem.Attribute("tradeDate").Value)
                ,  Symbol = tradeElem.Attribute("symbol").Value
            });
        }
    }
}
