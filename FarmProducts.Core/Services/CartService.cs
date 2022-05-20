using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public CartService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }
        public void AddItem(Guid id, QuantityViewModel model)
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cart = repo.All<Cart>().Where(c => c.Customer.UserId == userId).Include("Products").FirstOrDefault();
           
            if (cart == null)
            {
                var user = repo.All<User>().Where(u => u.Id == userId).Include("Customer").FirstOrDefault();
                cart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = user.Customer.Id,
                    Customer = user.Customer
                };
                repo.AddAsync(cart);
            }
            
            var item = repo.All<CartItem>().Where(c => c.CartId == cart.Id && c.ProductId == id).FirstOrDefault();
            var product = repo.All<Product>().Where(p=>p.Id == id).FirstOrDefault();

            if (!cart.Products.Contains(item))
            {
                CartItem cItem = new CartItem()
                {
                    Id = Guid.NewGuid(),
                    CartId = cart.Id,
                    Cart = cart,
                    Quantity = 0,
                    ProductId = id,
                    Product = product
                };
                repo.AddAsync<CartItem>(cItem);
            }

            var cartItem = cart.Products.Where(p=>p.ProductId == id).FirstOrDefault();
            cartItem.Quantity += model.Quantity;
            repo.SaveChanges();

        }

        public void DeleteCart()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetAll()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var productsModels = new List<ProductViewModel>();
            var user = repo.All<User>().Where(u => u.Id == userId).Include("Customer").FirstOrDefault();

            var cart = repo.All<Cart>().Where(c => c.CustomerId == user.Customer.Id).Include(i=>i.Products).ThenInclude(p=>p.Product).FirstOrDefault();
            var products = cart.Products;

            return products;

        }

        public void RemoveItem(Guid id)
        {
            
        }
    }
}
