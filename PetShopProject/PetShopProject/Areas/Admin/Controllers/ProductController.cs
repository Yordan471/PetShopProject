using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.CategoryViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;
using PetShopProject.Infrastructure.Data.Models;
using System.Collections.Generic;
using static PetShopProject.Common.GlobalConstants;

namespace PetShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService _productService, ILogger<ProductController> _logger, ICategoryService _categoryService)
        {
            this.productService = _productService;
            this.logger = _logger;
            this.categoryService = _categoryService;
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

        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductCreateViewModel
            {
                Categories = await categoryService.GetAllCategoriesForProductCreationAsync()
                
            };

            return View(viewModel);
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = new Product
                    {
                        Name = viewModel.Name,
                        LongDescription = viewModel.LongDescription,
                        ShortDescription = viewModel.ShortDescription,
                        Price = viewModel.Price,
                        ImageUrl = viewModel.ImageUrl,
                        AnimalType = viewModel.AnimalType,
                        CategoryId = viewModel.CategoryId
                    };

                    await productService.CreateProduct(product);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while creating a product.");
                    ModelState.AddModelError("", "An error occurred while creating the product.");
                }
            }

            viewModel.Categories = await categoryService.GetAllCategoriesForProductCreationAsync();

            return View(viewModel);
        }
    }
}
