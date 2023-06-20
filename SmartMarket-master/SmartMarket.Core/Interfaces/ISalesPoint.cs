using System.Collections.Generic;

namespace SmartMarket.Core.Interfaces
{
    public interface ISalesPoint
    {
        void ScanItem(string productName);
        Dictionary<string, decimal> GetTotals();
    }
}
