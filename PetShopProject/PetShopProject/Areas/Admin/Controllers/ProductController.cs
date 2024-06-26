﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.CategoryViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Services;
using System.Collections.Generic;
using static PetShopProject.Common.GlobalConstants;
using static PetShopProject.Common.RoleConstants;

namespace PetShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleAdmin)]
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
            IEnumerable<ProductViewModel> dogProducts = await productService
                .GetAllProductsAsync(AnimalTypeDog);

            if (!dogProducts.Any())
            {
                logger.LogWarning($"No products found for animal type {AnimalTypeDog}");
            }
            else
            {
                logger.LogInformation($"Successfully retrieved {dogProducts.Count()} products for animal type {AnimalTypeDog}");
            }

            IEnumerable<ProductViewModel> catProducts = await productService
                .GetAllProductsAsync(AnimalTypeCat);

            if (!catProducts.Any())
            {
                logger.LogWarning($"No products found for animal type {AnimalTypeCat}");
            }
            else
            {
                logger.LogInformation($"Successfully retrieved {catProducts.Count()} products for animal type {AnimalTypeCat}");
            }

            var allProducts = dogProducts.Concat(catProducts);

            return View(allProducts);
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await categoryService.GetAllCategoriesForProductCreationAsync();

                if (!categories.Any())
                {
                    logger.LogWarning("No categories found for product creation.");
                    return NotFound();
                }

                var viewModel = new ProductCreateViewModel
                {
                    Categories = categories
                };

                logger.LogInformation($"ProductCreateViewModel created with {categories.Count()} categories.");

                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving categories for product creation.");
                return View("Error500");
            }
        }

        // POST: Product/Create
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
                        Quantity = viewModel.Quantity,
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

        // GET: Product/Edit
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return View("Error404");
                }

                var viewModel = new ProductEditViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    ShortDescription = product.ShortDescription,
                    LongDescription = product.LongDescription,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                    AnimalType = product.AnimalType,
                    CategoryId = product.CategoryId,
                    Categories = await categoryService.GetAllCategoriesForProductCreationAsync()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving the product for editing.");
                return View("Error500");
            }
        }

        // POST: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return View("Error404");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var product = await productService.GetProductByIdAsync(id);
                    if (product == null)
                    {
                        return View("Error404");
                    }

                    product.Name = viewModel.Name;
                    product.ShortDescription = viewModel.ShortDescription;
                    product.LongDescription = viewModel.LongDescription;
                    product.Price = viewModel.Price;
                    product.ImageUrl = viewModel.ImageUrl;
                    product.AnimalType = viewModel.AnimalType;
                    product.CategoryId = viewModel.CategoryId;

                    await productService.UpdateProductAsync(product);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while updating the product.");
                    ModelState.AddModelError("", "An error occurred while updating the product. Please try again later.");
                }
            }

            viewModel.Categories = await categoryService.GetAllCategoriesForProductCreationAsync();

            return View(viewModel);
        }

        // GET: Product/Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsyncNoTracking(id);
                if (product == null)
                {
                    return View("Error404");
                }

                var viewModel = new ProductDeleteViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    ShortDescription = product.ShortDescription,
                    LongDescription = product.LongDescription,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                    CategoryName = product.Category.Name
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving the product for deletion.");
                return View("Error500");
            }
        }

        // POST: Product/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);

                if (product == null)
                {
                    logger.LogWarning($"Product with ID {id} not found for deletion.");
                    return View("Error404");
                }

                await productService.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while deleting the product with ID {id}.");
                return View("Error500");
            }
        }
    }
}
