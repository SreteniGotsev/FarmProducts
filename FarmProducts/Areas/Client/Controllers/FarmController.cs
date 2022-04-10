using FarmProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class FarmController : BaseController
    {
        public IActionResult AllFarms()
        {
            
            return View();
        }

        public IActionResult FarmDetails()
        {
           
            return View();
        }
    }
}
