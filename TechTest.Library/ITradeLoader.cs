using System.Collections.Generic;

namespace TechTest.Library
{
    public interface ITradeLoader
    {
        IEnumerable<Trade> LoadTrades(string fileName);
    }
}