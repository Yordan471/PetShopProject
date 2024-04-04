using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.Services;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.CategoryViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;


namespace PetShopProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService, IProductService _productService)
        {
            this.productService = _productService;
            this.categoryService = _categoryService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryViewModel> categories = await categoryService.GetAllCategoriesAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        public async Task<IActionResult> Details(int Id)
        {
            Category category = await categoryService.GetCategoryByIdAsync(Id);

            string type = "Куче";

            CategoryViewModel categoryView = new()
            {
                Name = category.Name,
                Description = category.Description,
                Products = category.Products
                .Where(p => p.AnimalType == type)
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

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            CreateCategoryViewModel category = new();

            return View(category);
        }

        [HttpPost]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await categoryService.DeleteCategoryAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
