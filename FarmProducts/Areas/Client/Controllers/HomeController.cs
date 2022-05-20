using FarmProducts.Core.Contracts;
using FarmProducts.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICartService service;
        public HomeController(ICartService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            IEnumerable<CartItem> products = service.GetAll();
            return View(products);
        }
    }
}
