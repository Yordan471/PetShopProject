using Microsoft.EntityFrameworkCore;
using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.CategoryViewModels;


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
                    Name = c.Name,
                    Description = c.Description,
                })
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            Category category = await dbContext.Categories.FindAsync(id);

            CategoryViewModel categoryView = new()
            {
                Name = category.Name,
                Description = category.Description,
            };

            return categoryView;
        }
    }
}
