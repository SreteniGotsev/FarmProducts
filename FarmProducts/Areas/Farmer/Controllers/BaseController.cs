using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Farmer.Controllers
{
    [Area("Farmer")]
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
