using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.ProductViewModels;

namespace PetShopProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel viewModel = new()
            {
                Name = product.Name,
                Description = product.LongDescription,
                Price = product.Price.ToString(),
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl
            };

            return View(viewModel);
        }
    }
}
