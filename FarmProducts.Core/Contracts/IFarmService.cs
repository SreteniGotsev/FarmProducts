using FarmProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Contracts
{
    public interface IFarmService
    { 
        Task<bool> AddFarm(FarmViewModel model);
        Task<bool> EditFarm(FarmViewModel model);
        FarmViewModel GetFarm();
        public FarmViewModel GetFarmById(Guid id);
        public IEnumerable<FarmViewModel> GetAllFarms();
        void DeleteFarm();
    }
}
