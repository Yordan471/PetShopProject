using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PetShopProject.Common.RoleConstants;

namespace PetShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleAdmin)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
