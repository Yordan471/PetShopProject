using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Infrastructure.Data.Models;

namespace PetShopProject.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        public UserController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }



            return View();
        }
    }
}
