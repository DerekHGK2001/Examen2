using Moq;
using SmartMarket.Core.Interfaces;
using SmartMarket.Core.Models;
using SmartMarket.Core.Rules;
using SmartMarket.Infrastructure.DataAccess;
using SmartMarket.Infrastructure.Serialization;
using SmartMarket.Infrastructure.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace SmartMarket.Tests
{
    public class StockServiceTests
    {
        [Fact]
        public async Task AddStockItemAsync_WithValidStockItem_ReturnsTrue()
        {
            // Arrange
            var stockItem = new StockItem
            {
                ProductName = "Test Product",
                Price = 10,
                ProviderId = new System.Guid("00000000-0000-0000-0000-000000000000"),
                ProviderName = "Test Provider",
                ProducedOn = new DateOnly(2021, 1, 1)
            };
            var stockItemString = JsonConvert.SerializeObject(stockItem);
            var providerManagementServiceMock = new Mock<IProviderManagementService>();
            providerManagementServiceMock.Setup(x => x.GetFromApiByIdAsync(It.IsAny<System.Guid>())).ReturnsAsync((Provider?)null);
            var stockService = new StockService();

            // Act
            var result = await stockService.AddStockItemAsync(stockItemString);

            // Assert
            Assert.True(result);
        }
    }
}


