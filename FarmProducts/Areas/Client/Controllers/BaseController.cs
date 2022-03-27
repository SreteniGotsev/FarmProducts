using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmProducts.Areas.Client.Controllers
{
    //[Authorize(Roles = "Client")]
    [Area("Client")]
    public class BaseController : Controller
    {
       
    }
}
