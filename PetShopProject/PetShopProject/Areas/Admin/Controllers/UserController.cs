using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Infrastructure.Data.Models;
using static PetShopProject.Common.RoleConstants;

namespace PetShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleAdmin)]
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;

        public UserController(SignInManager<User> _signInManager) 
        {
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
