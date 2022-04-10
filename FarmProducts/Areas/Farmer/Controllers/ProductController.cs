using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult ProductView()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult EditProduct()
        {
            return View();
        }
    }
}
