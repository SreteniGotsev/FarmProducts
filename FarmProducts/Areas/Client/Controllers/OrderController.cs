using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult OrderHistory()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
