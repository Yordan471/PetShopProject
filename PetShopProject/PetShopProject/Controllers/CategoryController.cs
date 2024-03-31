using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.CategoryViewModels;
using PetShopProject.ViewModels.ProductViewModels;


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
    }
}
