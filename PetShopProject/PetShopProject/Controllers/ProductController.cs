using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.ProductViewModels;

namespace PetShopProject.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel viewModel = new()
            {
                Id = id,
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
