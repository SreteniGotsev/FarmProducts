using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    public class FarmController : BaseController
    {
        private readonly IFarmService service;
        public FarmController(IFarmService _service)
        {
            service = _service;
        }
        public IActionResult FarmView()
        {

            var farm = service.GetFarm();
            if (farm == null)
            {
                return RedirectToAction("AddFarm");
            }

            return View(farm);
        }        
        public IActionResult AddFarm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFarm(FarmViewModel model)
        {
            service.AddFarm(model);
            return RedirectToAction("FarmView");
        }
        public IActionResult EditFarm()
        {
            var farm = service.GetFarm();
            return View(farm);
        }
        [HttpPost]
        public IActionResult EditFarm(FarmViewModel model)
        {
            service.EditFarm(model);
            return RedirectToAction("FarmView");
        }

        public IActionResult DeleteFarm()
        {
            service.DeleteFarm();
            return RedirectToAction("Index", "Home");
        }
    }
}
