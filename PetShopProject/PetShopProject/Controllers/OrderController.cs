using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.Services;
using PetShopProject.Core.ViewModels.CartViewModels;
using PetShopProject.Core.ViewModels.OrderViewModels;
using PetShopProject.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PetShopProject.Controllers
{
    public class OrderController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly ILogger<OrderController> logger;
        private readonly IUserService userService;

        public OrderController(
            IOrderService _orderService,
            ICartService _cartService,
            UserManager<User> _userManager,
            ILogger<OrderController> _logger,
            IUserService _userService)
        {
            orderService = _orderService;
            cartService = _cartService;
            userManager = _userManager;
            logger = _logger;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = userManager.FindByIdAsync(userId);

            if (user == null)
            {
                logger.LogWarning("User {userId} doesn't exist", userId);
                return BadRequest();
            }

            var cartItems = await cartService.GetCartItemsAsync(Guid.Parse(userId));

            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            var model = new OrderCheckoutViewModel
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(item => item.Total)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(List<CartCheckoutViewModel> cartItems)
        {
            var cartItemsView = GetCartItemsFromCheckoutViewModels(cartItems);
            var totalPrice = cartItemsView.Sum(c => c.Product.Price * c.Quantity);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                logger.LogWarning("User {userId} doesn't exist", userId);
                return BadRequest();
            }

            // Will be changed when there is more time
            // OrderConfirmation Action will be implemented in Admin area and logic will change
            if (user.BankAccountAmount >= totalPrice)
            {
                // Deduct the total price from the user's bank account
                await userService.UpdateUserBankAccountAmountAsync(user, totalPrice);

                // Create a new order
                var order = new Order
                {
                    UserId = Guid.Parse(userId),
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = totalPrice,
                    IsCompleted = true
                };
                await orderService.CreateOrderAsync(order);

                // Clear the user's cart
                await cartService.ClearCartAsync(Guid.Parse(userId));

                return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }

        public IActionResult InsufficientFunds()
        {
            return View();
        }

        
        // Private methods
        private List<CartItem> GetCartItemsFromCheckoutViewModels(List<CartCheckoutViewModel> cartCheckoutViewModel)
        {
            return cartCheckoutViewModel.Select(cvm => new CartItem
            {
                ProductId = cvm.ProductId,
                Product = new Product
                {
                    Id = cvm.ProductId,
                    Name = cvm.ProductName,
                    Price = cvm.Price
                },
                Quantity = cvm.Quantity,
            }).ToList();
        }
    }
}
