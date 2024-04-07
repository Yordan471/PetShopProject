using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;

namespace PetShopProject.Services
{
    public class ProductService : IProductService
    {
        private readonly PetShopDbContext dbContext;

        public ProductService(PetShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync(string animalType)
        {
            var products = await dbContext.Products
                .AsNoTracking()
                .Where(p => p.AnimalType == animalType)
                .OrderBy(p => p.Name)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.ShortDescription,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price.ToString()
                })
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);

            return product;
        }
    }
}
