﻿using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Core.Services;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IApplicationDbRepository repo;
        public FarmerService(IApplicationDbRepository _repo)
        {
            repo = _repo;
            
        }

        public async Task<bool> AddFarmer(FarmerViewModel model,string userId)
        {

            bool result = false;
           

            if (model != null)
            {
                Farmer farmer = new Farmer()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    UserId = userId
                };

                await repo.AddAsync(farmer);
                repo.SaveChanges();
                result = true;
            }

            return result;

        }

        public async Task<bool> EditFarmer(FarmerViewModel model)
        {
            bool result = false;
            var farmer = await repo.GetByIdAsync<Farmer>(model.Id);

            if (farmer != null)
            {
                farmer.Name = model.Name;
                farmer.Surname = model.Surname;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<FarmerViewModel> GetFaremr(string id)
        {
            var farmer = await repo.GetByIdAsync<Customer>(id);

            FarmerViewModel model = new FarmerViewModel()
            {
                Name = farmer.Name,
                Surname = farmer.Surname,

            };

            return model;
        }

        
    }
}
