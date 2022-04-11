using FarmProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Contracts
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerViewModel model, string userId);
        Task<CustomerViewModel> GetCustomer(string id);
        Task<bool> EditCustomer(CustomerViewModel model);
    }
}


