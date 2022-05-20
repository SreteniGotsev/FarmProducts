using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
                    Category = Enum.Parse<Category>(model.Category),
                    Price = model.Price,
                    Farm = farm,
                    FarmId = farm.Id,
                    Carts = model.Carts
                };

                repo.AddAsync(product);
                repo.SaveChanges();

            }
        }
        //Call the farm and include the Products and every individual product
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
            repo.Delete<Product>(product);
            repo.SaveChanges();
        }

        public async Task EditProduct(ProductViewModel model)
        {
            var product = repo.All<Product>().Where(p=>p.Id==model.Id).FirstOrDefault();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Category = Enum.Parse<Category>(model.Category);
            repo.SaveChanges();
        }

        public ProductViewModel GetProduct(Guid productId)
        {
            var productDb = ProductGet(productId);

            ProductViewModel product = new ProductViewModel()
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Description = productDb.Description,
                Category = productDb.Category.ToString(),
                Price = Math.Round(productDb.Price,2),
                Farm = productDb.Farm,
                FarmId = productDb.Id,
                Carts = productDb.Carts
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
                    Category = productDb.Category.ToString(),
                    Price = Math.Round(productDb.Price, 2),
                    Farm = productDb.Farm,
                    FarmId = productDb.FarmId,
                    Carts = productDb.Carts
                };
                products.Add(product);
            }

            return products;
        }
    }

}

