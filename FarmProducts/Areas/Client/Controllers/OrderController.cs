using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
