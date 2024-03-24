using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.CategoryViewModels;

namespace PetShopProject.Core.Contracts
{
    public interface ICategoryService
    {
        public Task<CategoryViewModel> GetCategoryByIdAsync(int id); 

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
