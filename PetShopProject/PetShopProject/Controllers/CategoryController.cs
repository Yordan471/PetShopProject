using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.Services;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.CategoryViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;

using static PetShopProject.Common.GlobalConstants;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;


namespace PetShopProject.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryService _categoryService, IProductService _productService, ILogger<CategoryController> _logger)
        {
            this.productService = _productService;
            this.categoryService = _categoryService;
            this.logger = _logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string animalType)
        {
            IEnumerable<CategoryViewModel> categories = await categoryService.GetAllCategoriesAsync();

            ViewData["AnimalType"] = animalType;

            if (categories == null)
            {
                return View("Error404");
            }

            return View(categories);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int Id, string animalType)
        {
            if (Id <= 0)
            {
                return BadRequest("Invalid category ID.");
            }

            if (string.IsNullOrEmpty(animalType))
            {
                return BadRequest("Animal type is required.");
            }

            try
            {
                Category category = await categoryService.GetCategoryByIdAsync(Id);

                if (category == null)
                {
                    return View("Error404");
                }

                CategoryViewModel categoryView = new()
                {
                    Name = category.Name,
                    Description = category.Description,
                    Products = category.Products
                .Where(p => p.AnimalType == animalType)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    ImageUrl = p.ImageUrl,
                    Description = p.ShortDescription
                })
                .ToList()
                };

                return View(categoryView);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving category details for ID: {Id}", Id);
                TempData["ErrorMessage"] = "An error occurred while retrieving the category details.";
                return View("Error500");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateCategoryViewModel category = new();

            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                Category category = new()
                {
                    Name = model.Name,
                    Description = model.Description,
                    AnimalType = model.AnimalType
                };

                await categoryService.CreateCategoryAsync(category);

                return View("Index");
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "An error occurred while creating a category.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the category. Please try again.");

                return View(model);
            } 
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                Category category = await categoryService.GetCategoryByIdAsync(Id);
                if (category == null)
                {
                    TempData["ErrorMessage"] = "Category not found";
                    return View("Error404");
                }

                CategoryDeleteViewModel categoryDelete = new CategoryDeleteViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    AnimalType = category.AnimalType
                };

                return View(categoryDelete);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving the category with ID: {id}", Id);
                TempData["ErrorMessage"] = $"An error occurred while retrieving the category with ID: {Id}";
                return View("Error500");
            } 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                Category category = await categoryService.GetCategoryByIdAsync(Id);

                if (category == null)
                {
                    return NotFound();
                }

                await categoryService.DeleteCategoryAsync(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the category with ID: {Id}", Id);
                TempData["ErrorMessage"] = $"An error occurred while deleting the category with ID: {Id}";
                return View("Error500");
            }   
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var category = await categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return View("Error404");
                }

                CategoryEditViewModel editCategory = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    AnimalType = category.AnimalType
                };

                return View(editCategory);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving the category with ID: {id}", id);
                TempData["ErrorMessage"] = $"An error occurred while retrieving the category with ID: {id}";
                return View("Error500");
            }   
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CategoryEditViewModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            var existingCategory = await categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                TempData["ErrorMessage"] = "Category not found";
                return View("Error404");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    Category categoryToEdit = new()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description,
                        AnimalType = category.AnimalType
                    };

                    await categoryService.EditCategoryAsync(categoryToEdit);
                    return RedirectToAction(nameof(Index));
                }

                return View(category);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while editing the category with ID: {id}", id);
                TempData["ErrorMessage"] = $"An error occurred while editing the category with ID: {id}";
                return View("Error500");
            }  
        }
    }
}
