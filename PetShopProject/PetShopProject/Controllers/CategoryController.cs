using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.Services;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.CategoryViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;

using static PetShopProject.Common.GlobalConstants;


namespace PetShopProject.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService, IProductService _productService)
        {
            this.productService = _productService;
            this.categoryService = _categoryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string animalType)
        {
            IEnumerable<CategoryViewModel> categories = await categoryService.GetAllCategoriesAsync();

            ViewData["AnimalType"] = animalType;

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int Id, string animalType)
        {
            Category category = await categoryService.GetCategoryByIdAsync(Id);

            if (category == null)
            {
                return NotFound();
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

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            CreateCategoryViewModel category = new();

            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {      
                return RedirectToAction(nameof(Create));
            }

            Category category = new()
            {
                Name = model.Name,
                Description = model.Description,
                AnimalType = model.AnimalType
            };

            await categoryService.CreateCategoryAsync(category);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            Category category = await categoryService.GetCategoryByIdAsync(Id);
            if (category == null)
            {
                return NotFound();
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await categoryService.DeleteCategoryAsync(Id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryEditViewModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await categoryService.EditCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}
