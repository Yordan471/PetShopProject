﻿using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.ProductViewModels;

namespace PetShopProject.Core.Contracts
{
    public interface IProductService
    {
        public Task<Product> GetProductByIdAsync(int id);

        public Task<List<ProductViewModel>> GetAllProductsAsync(string animalType);

        public Task CreateProduct(Product product);

        public Task UpdateProductAsync(Product product);

        public Task DeleteProductAsync(int id);

        public Task<Product> GetProductByIdAsyncNoTracking(int id);
    }
}
