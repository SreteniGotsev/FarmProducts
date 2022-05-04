using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FarmProducts.Areas.Client.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly ICustomerService service;
        public ProfileController(ICustomerService _service)
        {
            service = _service;
        }
        public IActionResult MyProfile()
        {
            var model = service.GetCustomer();
            if (model.Result == null)
            {
                return RedirectToAction("AddProfile");
            }
            return View(model.Result);
        }
        public IActionResult EditProfile()
        {
            var model = service.GetCustomer();
            if (model.Result == null)
            {
                return RedirectToAction("AddProfile");
            }
            return View(model.Result);
        }
        [HttpPost]
        public IActionResult EditProfile(CustomerViewModel model)
        {
            
            service.EditCustomer(model);
            return RedirectToAction("MyProfile");
        }
        public IActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProfile(CustomerViewModel model)
        {
            service.AddCustomer(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
