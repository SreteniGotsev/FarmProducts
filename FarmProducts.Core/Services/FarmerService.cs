using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace FarmProducts.Core.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor accessor;
        public FarmerService(IApplicationDbRepository _repo, IHttpContextAccessor _accessor)
        {
            repo = _repo;
            accessor = _accessor;
        }

        public async Task<bool> AddFarmer(FarmerViewModel model)
        {

            bool result = false;
            var userId = GetUserId();
            var user = UserGet();

            if (model != null && user.FarmerId == null)
            {
                Farmer farmer = new Farmer()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    UserId = userId,
                    User = user,
                    PhoneNumber = model.PhoneNumber,
                    Farm = null,
                };

                user.FarmerId = farmer.Id;
                user.Farmer = farmer;

                repo.AddAsync(farmer);
                repo.SaveChanges();
                result = true;
            }

            return result;

        }


        public async Task<bool> EditFarmer(FarmerViewModel model)
        {
            bool result = false;
            var farmer = FarmerGet();


            if (farmer != null)
            {
                farmer.Name = model.Name;
                farmer.Surname = model.Surname;
                farmer.PhoneNumber = model.PhoneNumber;

                repo.SaveChanges();
                result = true;
            }

            return result;
        }

        public FarmerViewModel GetFarmer()
        {
            var user = UserGet();
            var farmer = repo.All<Farmer>().Where(x => x.Id == user.FarmerId).Include(f => f.Farm).FirstOrDefault();
            if (farmer != null)
            {

                FarmerViewModel model = new FarmerViewModel()
                {
                    Name = farmer.Name,
                    Surname = farmer.Surname,
                    PhoneNumber = farmer.PhoneNumber,
                    Email = user.Email,
                    Farm = farmer.Farm,
                };
                return model;
            }
            return null;

        }
        public void DeleteFarmer()
        {
            var user = UserGet();
            repo.Delete(user.Farmer);
            repo.SaveChanges();
        }
        private User UserGet()
        {
            var userId = GetUserId();
            var user = repo.GetByIdAsync<User>(userId).Result;
            return user;

        }
        private Farmer FarmerGet()
        {
            var userId = GetUserId();
            var farmer = repo.All<Farmer>().Where(f => f.UserId == userId).FirstOrDefault();
            return farmer;

        }
        private string GetUserId()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }

    }
}
