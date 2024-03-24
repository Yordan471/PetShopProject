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

        public async Task<IActionResult> Details(int id)
        {
            CategoryViewModel category = await categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            IEnumerable<ProductViewModel> products = await productService.GetAllProductsOfCategoryAsync(id);

            if (products != null && products.Any())
            {
                category.Products = products;
            }

            return View(category);
        }
    }
}
