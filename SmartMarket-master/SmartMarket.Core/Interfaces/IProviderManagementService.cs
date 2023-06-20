using SmartMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMarket.Core.Interfaces
{
    public interface IProviderManagementService
    {
        Task<Provider?> GetFromApiByIdAsync(Guid id);
    }

}
