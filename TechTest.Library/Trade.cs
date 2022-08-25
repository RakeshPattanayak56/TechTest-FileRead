using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Library
{
    public class Trade
    {
        public string Identifier { get; set; }
        public string TradeType { get; set; }
        public string PaymentCurrency { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0}({1}) ccy:{2} strike:{3} quant:{4} symb:{5} date:{6}", Identifier, TradeType, PaymentCurrency, Price.ToString("##.00"), Quantity, Symbol, TradeDate.ToString("yyyyMMdd"));
        }

    }
}
