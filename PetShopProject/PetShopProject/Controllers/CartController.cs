using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuGet.Packaging;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.CartViewModels;
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
            if (!User?.Identity?.IsAuthenticated ?? false)
            {
                // Потребителят не е удостоверен, пренасочи към страницата за вход
                return RedirectToAction("Login", "User");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                // Невалиден потребителски идентификатор, покажи съобщение за грешка
                TempData["ErrorMessage"] = "Invalid user ID. Please log in again.";
                return RedirectToAction("Login", "User");
            }

            IEnumerable<CartViewModel> cartItems;

            try
            {
                cartItems = await cartService.GetAllCartProductsForUser(Guid.Parse(userId));
            }
            catch (Exception ex)
            {
                // Грешка при извличане на продуктите от количката, покажи съобщение за грешка
                logger.LogError(ex, "An error occurred while retrieving cart items.");
                TempData["ErrorMessage"] = "An error occurred while retrieving your cart. Please try again later.";
                return View("Error500");
            }

            if (!cartItems.Any())
            {
                // Количката е празна, покажи съобщение на потребителя
                TempData["InfoMessage"] = "Your cart is empty.";
            }

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            // Валидиране на входните данни
            if (id <= 0 || quantity < 1)
            {
                return RedirectToAction("Index");
            }

            var cartItem = await cartService.GetCartItemAsync(id);

            if (cartItem == null)
            {
                TempData["ErrorMessage"] = "Cart item not found";
                View("Error404");
            }

            try
            {
                // Извикване на услугата за актуализиране на количката
                await cartService.Update(cartItem, quantity);                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating cart item {id} with quantity {quantity}.", id, quantity);
                TempData["ErrorMessage"] = "An error occurred while updating the cart item. Please try again later.";
                return View("Error505");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItem = await cartService.GetCartItemAsync(id);
            if (cartItem == null)
            {
                logger.LogWarning("Cart item {id} doesn't exist", id);
                TempData["ErrorMessage"] = "Cart item doesn't exist";
                return View("Error404");
            }

            try
            {
                await cartService.Remove(cartItem);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error removing cart item {id}", id);
                TempData["ErrorMessage"] = $"Error removing cart item {id}";
                return View("Error505");
            }

            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if (!User?.Identity?.IsAuthenticated ?? false)
            {
                string returnUrl = Url.Action("AddToCart", "Cart", new { productId, quantity });
                return RedirectToAction("Login", "User", new {returnUrl});
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
