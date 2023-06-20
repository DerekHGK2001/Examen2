using SmartMarket.Core.Models;
using System;

namespace SmartMarket.Infrastructure.Serialization
{
    public interface IStockSerializer
    {
        StockItem Deserialize(string stockItem);
    }

}
