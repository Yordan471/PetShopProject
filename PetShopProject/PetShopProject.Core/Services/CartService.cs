using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Logging;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.CartViewModels;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Services
{
    public class CartService : ICartService
    {
        private readonly PetShopDbContext dbContext;

        public CartService(PetShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task AddCartItemToDb(CartItem cartItem)
        {
            await dbContext.AddAsync(cartItem);
            await dbContext.SaveChangesAsync();
        }

        public async Task<CartItem> CheckIfCartItemExists(Guid id, int productId)
        {
            return await dbContext.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.CustummerId == id && ci.ProductId == productId);
        }

        public async Task<List<CartViewModel>> GetAllCartProductsForUser(Guid userId)
        {
            var cartItems = await dbContext.CartItems
               .Where(ci => ci.CustummerId == userId)
               .Include(ci => ci.Product)
               .Select(ci => new CartViewModel()
               {
                   Id = ci.Id,
                   ProductId = ci.ProductId,
                   ProductName = ci.Product.Name,
                   Quantity = ci.Quantity,
                   Price = ci.Product.Price.ToString()
               })
               .ToListAsync();

            return cartItems;
        }

        public async Task<CartItem> GetCartItemAsync(int id)
        {
            var cartItem = await dbContext.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            return cartItem;
        }

        public async Task IncreaseQuantityCartItemAsync(CartItem cartItem, int quantity)
        {
            cartItem.Quantity += quantity;
            cartItem.Product.Quantity -= quantity;
            await dbContext.SaveChangesAsync();
        }

        public async Task Remove(CartItem cartItem)
        {
            cartItem.Product.Quantity += cartItem.Quantity;

            dbContext.Remove(cartItem);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(CartItem cartItem ,int quantity)
        {
            cartItem.Product.Quantity += cartItem.Quantity;

            cartItem.Quantity = quantity;
            cartItem.Product.Quantity -= quantity;
            await dbContext.SaveChangesAsync();
        }
    }
}
