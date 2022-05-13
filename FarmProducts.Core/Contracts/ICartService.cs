using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Contracts
{
    public interface ICartService
    {
        void AddItem(Guid id);
        void RemoveItem(Guid id);
        void DeleteCart();
        IEnumerable<CartItem> GetAll();
    }
}
