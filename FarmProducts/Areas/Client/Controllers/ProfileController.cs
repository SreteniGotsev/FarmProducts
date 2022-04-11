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
        private readonly IHttpContextAccessor accessor;
        public ProfileController(ICustomerService _service, IHttpContextAccessor _accessor)
        {
            service = _service;
            accessor = _accessor;
        }
        public IActionResult MyProfile()
        {
           var _userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = service.GetCustomer(_userId);
            return View(model);
        }
        public IActionResult EditProfile()
        {
            return View();
        }
        [HttpPut]
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

            var userId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            service.AddCustomer(model, userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
