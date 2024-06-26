﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Models;
using System.Diagnostics;

namespace PetShopProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger, IHomeService _homeService)
        {
            this.logger = _logger;
            this.homeService = _homeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var viewModel = await homeService.GetProductsByAnimalAndCategoryAsync();
           
            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
