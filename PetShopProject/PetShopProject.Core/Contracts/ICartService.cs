using PetShopProject.Core.ViewModels.CartViewModels;
using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Contracts
{
    public interface ICartService
    {
        public Task<List<CartViewModel>> GetAllCartProductsForUser(Guid userId);

        public Task Update(CartItem cartItem, int quantity);

        public Task<CartItem> GetCartItemAsync(int id);

        public Task Remove(CartItem cartItem);

        public Task<CartItem> CheckIfCartItemExists(Guid id, int productId); 

        public Task AddCartItemToDb(CartItem cartItem);

        public Task IncreaseQuantityCartItemAsync(CartItem cartItem, int quantity);
    }
}
