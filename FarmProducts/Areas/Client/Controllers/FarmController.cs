using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class FarmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
