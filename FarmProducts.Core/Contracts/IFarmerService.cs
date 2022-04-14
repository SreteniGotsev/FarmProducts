using FarmProducts.Core.Models;

namespace FarmProducts.Core.Services
{
    public interface IFarmerService
    {
        Task<bool> AddFarmer(FarmerViewModel model);
        FarmerViewModel GetFarmer();
        Task<bool> EditFarmer(FarmerViewModel model);
        void DeleteFarmer();

    }
}
