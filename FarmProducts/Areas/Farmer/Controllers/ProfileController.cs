using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class ProfileController : BaseController
    {
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
    }
}
