using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class OrderController : BaseController
    {

        public IActionResult Details()
        {
            return View();
        }
        public IActionResult AllOrders()
        {
            return View();
        }
    }
}
