using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService service;
        public ProductController(IProductService _service)
        {
            service = _service;
        }

        public IActionResult ProductView(Guid Id)
        {
            var product = service.GetProduct(Id);
            return View(product);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {
            
            service.AddProduct(model);
            return RedirectToAction("AllProducts");
        }
        public IActionResult AllProducts()
        {
            var products = service.GetProducts();
            return View(products);
        }

        public IActionResult EditProduct(Guid Id)
        {
            var product =service.GetProduct(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductViewModel model)
        {
            service.EditProduct(model);
            return RedirectToAction("AllProducts");
        }

        public IActionResult DeleteProduct(Guid Id)
        {
            service.DeleteProduct(Id);
            return RedirectToAction("AllProducts");
        }
    }
}
