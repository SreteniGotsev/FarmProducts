using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Core.Services;
using FarmProducts.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IFarmerService service;
        public ProfileController(IFarmerService _service)
        {
            service = _service;
        }
        public IActionResult MyProfile()
        {
            var model = service.GetFarmer();
            if (model == null)
            {
                return RedirectToAction("AddProfile");
            }

            return View(model);
        }
        public IActionResult EditProfile()
        {   
            var model = service.GetFarmer();
            if (model == null)
            {
                return RedirectToAction("AddProfile");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProfile(FarmerViewModel model)
        { 
            service.EditFarmer(model);

            return RedirectToAction("MyProfile");
        }

        public IActionResult AddProfile()
        {       
           return View();
        }
        [HttpPost]
        public IActionResult AddProfile(FarmerViewModel model)
        {
            service.AddFarmer(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteFarmer()
        {
            service.DeleteFarmer();
            return RedirectToAction("Index", "Home");
        }
    }
}
