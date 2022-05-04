using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    public class FarmController : BaseController
    {
        private readonly IFarmService service;
        public FarmController(IFarmService _service)
        {
             service = _service;
        }
        public IActionResult AllFarms()
        {
            var farms = service.GetAllFarms();
            
            if (farms == null)
            {
                return RedirectToAction("AddFarm");
            }
            return View(farms);
        }

        public IActionResult FarmDetails(Guid Id)
        {
            var farm = service.GetFarmById(Id);
            return View(farm);
        }
    }
}
