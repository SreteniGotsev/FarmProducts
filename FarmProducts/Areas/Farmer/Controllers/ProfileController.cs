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
        private readonly IHttpContextAccessor accessor;
        public ProfileController(IFarmerService _service,IHttpContextAccessor _accessor)
        {
            service = _service;
            accessor = _accessor;
        }
        public IActionResult MyProfile()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProfile(FarmerViewModel model)
        {
           
            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            service.AddFarmer(model, userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
