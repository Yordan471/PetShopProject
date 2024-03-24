using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Contracts
{
    public interface IProductService
    {
        public Task<Product> GetProductByIdAsync(int id);

        public Task<IEnumerable<ProductViewModel>> GetAllProductsOfCategoryAsync(int id);
    }
}
