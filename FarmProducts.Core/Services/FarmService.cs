using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FarmProducts.Core.Services
{
    public class FarmService : IFarmService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public FarmService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }

        public async Task<bool> AddFarm(FarmViewModel model)
        {
            bool isDone = false;
            var farmerId = GetFarmerId();
            var farmer = repo.GetByIdAsync<Farmer>(farmerId).Result;

            if (model != null && farmer.Farm == null)
            {
                Farm farm = new Farm()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Address = model.Address,
                    Description = model.Description,
                    Certificate = model.Certificate,
                    Cities = model.Cities,
                    FarmerId = farmer.Id
                };
                repo.AddAsync(farm);
                repo.SaveChanges();
                isDone = true;
            }
            return isDone;
        }


        public async Task<bool> EditFarm(FarmViewModel model)
        {
            bool isDone = false;
            var farm = FarmGet();

            if (farm != null)
            {
                farm.Name = model.Name;
                farm.Description = model.Description;
                farm.Certificate = model.Certificate;
                farm.Address = model.Address;
                farm.Cities = model.Cities;
                farm.IsRegistered = model.IsRegistered;

                repo.SaveChanges();
                isDone = true;
            }

            return isDone;
        }

        public FarmViewModel GetFarm()
        {
            var farm = FarmGet();

            FarmViewModel model = new FarmViewModel()
            {

                Name = farm.Name,
                Description = farm.Description,
                Address = farm.Address,
                Certificate = farm.Certificate,
                IsRegistered = farm.IsRegistered,
                Cities = farm.Cities,
                FarmerId = farm.FarmerId
                
            };
            return model;
        }

        public void DeleteFarm()
        {
            var farm = FarmGet();
            repo.Delete(farm);
        }
        private Guid GetFarmerId()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farmer = repo.All<Farmer>().Where(f => f.UserId.Equals(userId)).FirstOrDefault().Id;
            return farmer;
        }
        private Farm FarmGet()
        {
            var farmerId = GetFarmerId();
            var farm = repo.All<Farm>().Where(f => f.FarmerId == farmerId).FirstOrDefault();
            return farm;
        }
    }
}
