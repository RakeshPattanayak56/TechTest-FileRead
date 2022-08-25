using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTest.Library
{
    public class ValuationEngine
    {
        private readonly IList<Trade> _trades;
        private readonly Dictionary<string, double> _results = new Dictionary<string, double>();
        private readonly PriceTicker _ticker;

        public ValuationEngine(IEnumerable<Trade> trades)
        {
            _trades = new List<Trade>(trades);
            _ticker = new PriceTicker();
            _ticker.PriceChanged += new EventHandler<PriceChangedEventArgs>(Ticker_PriceChanged);
        }

        void Ticker_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            // calculate the present value and publish the results on an event
            
        }

        public void Start()
        {
            _ticker.Start();
        }

        public void Stop()
        {
            _ticker.Stop();
        }

    }
}
