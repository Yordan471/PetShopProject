using PetShopProject.Core.ViewModels.HomeViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Contracts
{
    public interface IHomeService
    {
        public Task<IEnumerable<HomeViewModel>> GetProductsByAnimalAndCategoryAsync();
    }
}
