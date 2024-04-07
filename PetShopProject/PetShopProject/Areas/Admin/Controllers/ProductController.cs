using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.ProductViewModels;
using System.Collections.Generic;
using static PetShopProject.Common.GlobalConstants;

namespace PetShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService _productService, ILogger<ProductController> _logger)
        {
            this.productService = _productService;
            this.logger = _logger;
        }

        public async Task<IActionResult> Index()
        {
            // Dog products
            List<ProductViewModel> dogProducts = await productService
                .GetAllProductsAsync(AnimalTypeDog);

            if (dogProducts == null)
            {
                logger.LogWarning($"No products found for animal type {AnimalTypeDog}");
                return BadRequest();
            }

            //List<ProductViewModel> catProducts = await productService
            //    .GetAllProductsAsync(AnimalTypeCat);

            //if (catProducts == null)
            //{
            //    logger.LogWarning($"No products found for animal type {AnimalTypeCat}");
            //    return BadRequest();
            //}

            //List<ProductViewModel> birdProducts = await productService
            //   .GetAllProductsAsync(AnimalTypeBird);

            //if (catProducts == null)
            //{
            //    logger.LogWarning($"No products found for animal type {AnimalTypeBird}");
            //    return BadRequest();
            //}

            //dogProducts.AddRange(catProducts);
            //dogProducts.AddRange(birdProducts);

            return View(dogProducts);
        }
    }
}
