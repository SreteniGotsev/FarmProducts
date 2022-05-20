using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService service;
        //private readonly IOrderService orderService;
        public CartController(ICartService _service)
        {
            service = _service;
        }

        public IActionResult AddToCart(QuantityViewModel model, Guid id)
        {
            
            service.AddItem(id, model);
            return RedirectToAction("Cart", "Home");
        }
        public IActionResult RemoveFromCart(Guid id)
        {
            service.RemoveItem(id);
            return RedirectToAction("Cart", "Home");
        }
        public IActionResult PlaceOrder()
        {
           // orderService.Order();
            service.DeleteCart();
            return RedirectToAction("Cart", "Home");
        }
    }
}
