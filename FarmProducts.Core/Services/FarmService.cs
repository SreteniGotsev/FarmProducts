using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            var farmer = GetFarmer();

            if (model != null && farmer.Farm == null)
            {
                Farm farm = new Farm()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Address = model.Address,
                    Description = model.Description,
                    Certificate = model.Certificate,
                    FarmerId = farmer.Id,
                    Farmer = farmer,
                    IsRegistered = model.IsRegistered,

                };

                City city = new City()
                {
                    Name = CityEnum.Varna
                };
                city.Farms.Add(farm);
                farm.Cities.Add(city);
                repo.AddAsync(city);


                //foreach (var item in model.Cities)
                //{
                //    City city = new City()
                //    {
                //        Name = item.Name,
                //    };

                //    city.Farms.Add(farm);
                //    farm.Cities.Add(city);
                //    repo.AddAsync(city);
                //}

                //foreach (var item in model.Days)
                //{
                //    Day day = new Day()
                //    {
                //       DayOfWeek = item.DayOfWeek
                //    };

                //    day.Farms.Add(farm);
                //    farm.DeliveryDays.Add(day);
                //    repo.AddAsync(day);
                //}

                farmer.Farm = farm;

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
                farm.IsRegistered = model.IsRegistered;

                if (repo.All<City>().Where(c => c.Name == Enum.Parse<CityEnum>(model.Name)) == null)
                {

                    City city = new City()
                    {
                        Name = Enum.Parse<CityEnum>(model.Name),
                    };
                    city.Farms.Add(farm);
                    farm.Cities.Add(city);
                    repo.AddAsync(city);
                }
                repo.SaveChanges();
                isDone = true;
            }

            return isDone;
        }

        public FarmViewModel GetFarm()
        {
            var farm = FarmGet();

            if (farm == null)
            {
                return null;
            }

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
        public FarmViewModel GetFarmById(Guid id)
        {
            var farm = repo.All<Farm>().Where(f => f.Id == id).Include("Products").Include("Farmer").FirstOrDefault();

            if (farm == null)
            {
                return null;
            }

            FarmViewModel model = new FarmViewModel()
            {

                Name = farm.Name,
                Description = farm.Description,
                Address = farm.Address,
                Certificate = farm.Certificate,
                IsRegistered = farm.IsRegistered,
                Cities = farm.Cities,
                FarmerId = farm.FarmerId,
                Phone = farm.Farmer.PhoneNumber

            };

            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (var item in farm.Products)
            {
                ProductViewModel product = new ProductViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.ToString(),
                    Description = item.Description,
                    FarmId = item.FarmId,
                    Farm = item.Farm,
                    Price = item.Price,
                    Carts = item.Carts,
             
                };
                products.Add(product);
            }
            model.Products = products;
            return model;
        }

        public void DeleteFarm()
        {
            var farm = FarmGet();
            repo.Delete(farm);
            repo.SaveChanges();
        }

        public IEnumerable<FarmViewModel> GetAllFarms()
        {
            var farmer = GetFarmer();
            var farmList = new List<FarmViewModel>();
            var farms = repo.All<Farm>().Where(f => f.FarmerId != farmer.Id);
            foreach (var farm in farms)
            {
                FarmViewModel farmViewModel = new FarmViewModel()
                {
                    Address = farm.Address,
                    Name = farm.Name,
                    Certificate = farm.Certificate,
                    Description = farm.Description,
                    FarmerId = farm.FarmerId,
                    Id = farm.Id,
                    
                    //  Cities = farm.Cities
                };
                farmList.Add(farmViewModel);
            }

            return farmList;
        }
        private Farmer GetFarmer()
        {
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farmer = repo.All<Farmer>().Where(f => f.UserId.Equals(userId)).FirstOrDefault();
            return farmer;
        }
        private Farm FarmGet()
        {
            var farmer = GetFarmer();
            var farm = repo.All<Farm>().Where(f => f.FarmerId == farmer.Id).FirstOrDefault();
            return farm;
        }
    }
}
