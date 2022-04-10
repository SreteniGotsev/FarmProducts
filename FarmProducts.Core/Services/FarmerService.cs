using FarmProducts.Core.Models;
using FarmProducts.Core.Services;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
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

        public Task<bool> AddFarmer(UserViewModel user)
        {
            
        }

        public Task<bool> EditTFarmer(FarmerViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<FarmerViewModel> GetFaremr(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetUser(string id)
        {
            var user =  await repo.GetByIdAsync<UserViewModel>(id);

            return new UserViewModel() { Id=user.Id };

        }
    }
}
