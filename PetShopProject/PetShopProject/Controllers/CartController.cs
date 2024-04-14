using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuGet.Packaging;
using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PetShopProject.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly ILogger<CartController> logger;
        private readonly IProductService productService;

        public CartController(ICartService _cartService, ILogger<CartController> _logger, IProductService _productService) 
        {
            this.cartService = _cartService;
            this.logger = _logger;
            this.productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            // Get current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Get current user cart items from db
            var cartItems = await cartService.GetAllCartProductsForUser(Guid.Parse(userId));

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            // Get cart item by id and update the quantity
            var cartItem = await cartService.GetCartItemAsync(id);

            if (cartItem == null)
            {
                logger.LogWarning("Cart item {id} doesn't exist", id);
                return RedirectToAction("Index");
            }

            await cartService.Update(cartItem, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            // Get Cart Item from db and remove it
            var cartItem = await cartService.GetCartItemAsync(id);
            if (cartItem == null)
            {
                logger.LogWarning("Cart item {id} doesn't exist", id);
                return RedirectToAction("Index");
            }

            await cartService.Remove(cartItem);

            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if (!User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Login", "User");
            }

            // Get current user id
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if the product is already in the cart of the user
            var cartItem = await cartService.CheckIfCartItemExists(Guid.Parse(userId), productId);

            if (cartItem == null)
            {
                // If the product is null we create new one
                cartItem = new CartItem
                {
                    CustummerId = Guid.Parse(userId),
                    ProductId = productId,
                    Product = await productService.GetProductByIdAsync(productId),
                    Quantity = quantity                   
                };

                
                cartItem.Product.Quantity -= quantity;

                await cartService.AddCartItemToDb(cartItem);
            }
            else
            {
                // If the product is already in the cart increase it's quantity
                await cartService.IncreaseQuantityCartItemAsync(cartItem, quantity);
            }

            TempData["AddedProductName"] = cartItem.Product.Name;
            TempData["AddedQuantity"] = quantity;

            return RedirectToAction("Index");
        }
    }
}
