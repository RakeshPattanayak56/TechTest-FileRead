using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TechTest.Library
{
    /// <summary>
    /// price ticker that publishes random price changes for a set of symbols
    /// </summary>
    public class PriceTicker
    {
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        private readonly Timer _timer;
        private readonly Random _random =  new Random(Guid.NewGuid().GetHashCode());

        private readonly Dictionary<string, double> _symbolPrices;
        private readonly string[] _symbols =
            {
                "SXFZ3", "EDX3", "EDV3", "SIF4P", "JGBZ3", "LCOZ3", "BAXZ3", "DJH4", "SPH4", "CLG4"
            };

        public PriceTicker()
        {
            _timer = new Timer(TimerFire, null, -1, -1);
            _symbolPrices = new Dictionary<string, double>();

            foreach (string s in _symbols)
                _symbolPrices.Add(s, _random.NextDouble() * 100);
        }

        public void Start()
        {
            _timer.Change(0, 250);
        }

        public void Stop()
        {
            _timer.Change(-1, -1);         
        }

        public double? GetCurrentPrice(string symbol)
        {
            double retVal;
            return _symbolPrices.TryGetValue(symbol, out retVal) ? (double?)retVal : null;
        }

        private void TimerFire(object o)
        {
            var tmp = PriceChanged;
            if (tmp != null)
            {
                // pick a random symbol
                string symbol = _symbols[_random.Next(_symbols.Length)];
                // determine a random +/- change amount
                double change = _random.NextDouble() * (_random.NextDouble() <= .5 ? 1 : -1);
                // get the original price and update the current price with the change
                double origPrice = _symbolPrices[symbol];
                double newPrice = _symbolPrices[symbol] = (origPrice + change);

                // tell subscribers about the change..
                tmp(this, new PriceChangedEventArgs(symbol, newPrice, origPrice));
            }
        }         
    }

    
}
