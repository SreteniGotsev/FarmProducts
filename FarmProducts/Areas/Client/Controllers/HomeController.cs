using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
