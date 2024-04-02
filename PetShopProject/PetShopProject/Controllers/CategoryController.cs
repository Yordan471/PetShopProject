using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.CategoryViewModels;


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
            CategoryViewModel category = await categoryService.GetCategoryByIdAsync(Id);

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
    }
}
