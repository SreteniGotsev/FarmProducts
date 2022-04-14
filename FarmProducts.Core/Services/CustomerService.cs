using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FarmProducts.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public CustomerService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }

        public async Task<bool> AddCustomer(CustomerViewModel model)
        {
            bool result = false;
            var userId = GetUserId();
            var user = repo.GetByIdAsync<User>(userId).Result;

            if (model != null && user.CustomerId == null)
            {
                Customer customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    UserId = userId,
                    PhoneNumber = model.PhoneNumber,

                };

                await repo.AddAsync(customer);
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;

        }

        public async Task<bool> EditCustomer(CustomerViewModel model)
        {
            bool result = false;
            var customer = CustomerGet();

            if (customer != null)
            {
                customer.Name = model.Name;
                customer.Surname = model.Surname;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;

                repo.SaveChanges();
                result = true;
            }

            return result;
        }

        public async Task<CustomerViewModel> GetCustomer()
        {
            var customer = CustomerGet();

            CustomerViewModel model = new CustomerViewModel()
            {

                Name = customer.Name,
                Surname = customer.Surname,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.User.Email,
            };

            return model;
        }

        private string GetUserId()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }

        private Customer CustomerGet()
        {
            var userid = GetUserId();
            var customer = repo.All<Customer>().Where(c => c.UserId == userid).FirstOrDefault();
            return customer;

        }
    }
}
