using FarmProducts.Core.Contracts;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Repositories;
using FarmProducts.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public ProductService(IApplicationDbRepository _repository, IHttpContextAccessor _accessor)
        {
            repo = _repository;
            accessor = _accessor;
        }
        public async Task AddProduct(ProductViewModel model)
        {

            var farm = FarmGet();

            if (model != null)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    Category = model.Category,
                    Price = model.Price,
                    Farm = farm,
                    FarmId = farm.Id,
                    Orders = model.Orders
                };

                await repo.AddAsync(product);
                await repo.SaveChangesAsync();

            }
        }

        private Product ProductGet(Guid id)
        {
            var productList = ProductsGet();
            var product = productList.Where(p => p.Id == id).FirstOrDefault();
            return product;
        }
        private List<Product> ProductsGet()
        {
            var farmId = FarmGet();
            var products = repo.All<Product>().Where(x => x.FarmId == farmId.Id).ToList();
            return products;
        }

        private Farm FarmGet()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farm = repo.All<Farm>().Where(f => f.Farmer.UserId == userId).FirstOrDefault();
            return farm;
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = ProductGet(id);
            await repo.DeleteAsync<Product>(product);
        }

        public async Task EditProduct(ProductViewModel model)
        {
            var product = await repo.GetByIdAsync<Product>(model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Category = model.Category;
            product.Price=model.Price;
            product.Id = model.Id;
            product.FarmId = model.FarmId;
            product.Farm=model.Farm;
            product.Orders=model.Orders;

            await repo.SaveChangesAsync();
        }

        public ProductViewModel GetProduct(Guid productId)
        {
            var productDb = ProductGet(productId);

            ProductViewModel product = new ProductViewModel()
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Description = productDb.Description,
                Category = productDb.Category,
                Price = productDb.Price,
                Farm = productDb.Farm,
                FarmId = productDb.Id,
                Orders = productDb.Orders
            };

            return product;
        }

        public List<ProductViewModel> GetProducts()
        {
            var productsDb = ProductsGet();

            List<ProductViewModel> products = new List<ProductViewModel>();

            foreach (var productDb in productsDb)
            {
                ProductViewModel product = new ProductViewModel()
                {
                    Id = productDb.Id,
                    Name = productDb.Name,
                    Description = productDb.Description,
                    Category = productDb.Category,
                    Price = productDb.Price,
                    Farm = productDb.Farm,
                    FarmId = productDb.Id,
                    Orders = productDb.Orders
                };
                products.Add(product);
            }

            return products;
        }
    }

}

