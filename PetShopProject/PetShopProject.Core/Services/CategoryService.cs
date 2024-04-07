using Microsoft.EntityFrameworkCore;
using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.CategoryViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;


namespace PetShopProject.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PetShopDbContext dbContext;

        public CategoryService(PetShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EditCategoryAsync(CategoryEditViewModel editCategory)
        {
            dbContext.Entry(editCategory).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> categories = await dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int Id)
        {
            Category category = await dbContext.Categories
                .AsNoTracking()
                .Include(c => c.Products)
                .FirstAsync(c => c.Id == Id);

            return category;
        }
    }
}
