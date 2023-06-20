using System;
using SmartMarket.Core.Models;

namespace SmartMarket.Core.Rules
{
    public class ExpirationRules
    {
        public static bool CalculateExpiration(StockItem stockItem)
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            var currentAge = now.DayNumber - stockItem.ProducedOn.DayNumber;
            switch (currentAge)
            {
                case > 30:
                    return false;
                case > 15:
                case > 7 when stockItem.MembershipDeal is not null:
                    stockItem.IsCloseToExpirationDate = true;
                    break;
                default:
                    stockItem.IsCloseToExpirationDate = false;
                    break;
            }

            return true;
        }
    }
}
