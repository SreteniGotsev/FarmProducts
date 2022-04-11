using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbRepository repo;
        public CustomerService(IApplicationDbRepository _repo)
        {
            repo = _repo;

        }

        public async Task<bool> AddCustomer(CustomerViewModel model, string userId)
        {

            bool result = false;


            if (model != null)
            {
                Customer customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    UserId = userId
                };

                await repo.AddAsync(customer);
                repo.SaveChanges();
                result = true;
            }

            return result;

        }

        public async Task<bool> EditCustomer(CustomerViewModel model)
        {
            bool result = false;
            var customer = await repo.GetByIdAsync<Customer>(model.Id);

            if (customer != null)
            {
                customer.Name = model.Name;
                customer.Surname = model.Surname;
                customer.Address = model.Address;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<CustomerViewModel> GetCustomer(string id)
        {
            var customer = await repo.GetByIdAsync<Customer>(id);

            CustomerViewModel model = new CustomerViewModel()
            {

                Name = customer.Name,
                Surname = customer.Surname,
                Address = customer.Address,



            };
            
            return model;
        }
    }
}
