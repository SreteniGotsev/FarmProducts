using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class FarmController : BaseController
    {
        public IActionResult FarmView()
        {
            return View();
        }        
        public IActionResult AddFarm()
        {
            return View();
        }
        public IActionResult EditFarm()
        {
            return View();
        }
    }
}
