using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Core.ViewModels.CategoryViewModels;

namespace PetShopProject.Core.Contracts
{
    public interface ICategoryService
    {
        public Task<Category> GetCategoryByIdAsync(int id); 

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        public Task<Category> CreateCategoryAsync(Category category);

        public Task DeleteCategoryAsync(int id);

        public Task EditCategoryAsync(Category editCategory);

        public Task<IEnumerable<CategoryForCreateProductViewModel>> GetAllCategoriesForProductCreationAsync();
    }
}
