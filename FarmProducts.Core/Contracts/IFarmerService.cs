using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
	public interface IFarmerService
	{
		Task<bool> AddFarmer(FarmerViewModel model, string userId);
		Task<FarmerViewModel> GetFaremr(string id);
		Task<bool> EditFarmer(FarmerViewModel model);
	}
}
