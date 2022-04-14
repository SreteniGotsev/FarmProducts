using FarmProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Contracts
{
    public interface IProductService
    {
        Task AddProduct(ProductViewModel model);
        Task EditProduct(ProductViewModel model);
        ProductViewModel GetProduct(Guid Id);
        List<ProductViewModel> GetProducts();
        Task DeleteProduct(Guid Id);


    }
}
