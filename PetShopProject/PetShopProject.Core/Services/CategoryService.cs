using Microsoft.EntityFrameworkCore;
using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.CategoryViewModels;
using PetShopProject.ViewModels.ProductViewModels;


namespace PetShopProject.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PetShopDbContext dbContext;

        public CategoryService(PetShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> categories = await dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                })
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int Id)
        {
            Category category = await dbContext.Categories
                .AsNoTracking()
                .Include(c => c.Products)
                .FirstAsync(c => c.Id == Id);

            string type = "Куче";

            CategoryViewModel categoryView = new()
            {
                Name = category.Name,
                Description = category.Description,
                Products = category.Products
                .Where(p => p.AnimalType == type)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    ImageUrl = p.ImageUrl,
                    Description = p.ShortDescription
                })
                .ToList()
            };

            return categoryView;
        }
    }
}
