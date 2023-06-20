using SmartMarket.Core.Interfaces;
using SmartMarket.Core.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartMarket.Infrastructure.Services
{
    public class ProviderManagementService : IProviderManagementService
    {
        private static ProviderManagementService _instance;
        private static readonly HttpClient _client = new HttpClient();

        private ProviderManagementService()
        {
        }

        public static ProviderManagementService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProviderManagementService();
                }
                return _instance;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
            }
        }

        public async Task<Provider?> GetFromApiByIdAsync(Guid id)
        {
            var response = await _client.GetAsync($"https://localhost:5001/api/providers/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var provider = JsonSerializer.Deserialize<Provider>(responseContent);
            return provider;
        }
    }
}
