using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTest.Library
{
    public class PriceChangedEventArgs : EventArgs
    {
        public PriceChangedEventArgs(string symbol, double newPrice, double origPrice)
        {
            Symbol = symbol;
            NewPrice = newPrice;
            OrigPrice = origPrice;
        }

        public double OrigPrice { get; private set; }
        public double NewPrice { get; private set; }
        public string Symbol { get; private set; }
    }
}
