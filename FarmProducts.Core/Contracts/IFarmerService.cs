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
		Task<UserViewModel> GetUser(string id);
		Task<bool> AddFarmer(UserViewModel user);
		Task<FarmerViewModel> GetFaremr(string id);
		Task<bool> EditTFarmer(FarmerViewModel model);
	}
}
