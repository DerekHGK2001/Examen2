using SmartMarket.Core.Interfaces;
using SmartMarket.Core.Models;
using SmartMarket.Core.Rules;
using SmartMarket.Infrastructure.DataAccess;
using SmartMarket.Infrastructure.Serialization;
using System;
using System.Threading.Tasks;

namespace SmartMarket.Infrastructure.Services
{
    public class StockService : IStockService
    {
        public async Task<bool> AddStockItemAsync(string stockItem)
        {
            var stockSerializer = new StockSerializer();
            var providerManagementService = ProviderManagementService.Instance;

            var stockItemObject = stockSerializer.Deserialize(stockItem);
            if (string.IsNullOrEmpty(stockItemObject.ProductName))
            {
                return false;
            }

            if (stockItemObject.Price <= 0)
            {
                return false;
            }

            var isExpired = ExpirationRules.CalculateExpiration(stockItemObject);
            if (!isExpired)
            {
                return false;
            }

            var provider = await providerManagementService.GetFromApiByIdAsync(stockItemObject.ProviderId);
            if (provider is null)
            {
                SmartMarketDataAccess.AddProvider(stockItemObject.ProviderId, stockItemObject.ProviderName);
            }

            SmartMarketDataAccess.AddStockItem(stockItemObject);
            return true;
        }
    }
}






