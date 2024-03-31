using PetShopProject.Core.Contracts;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ViewModels.CategoryViewModels;
using PetShopProject.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly PetShopDbContext dbContext;

        public ProductService(PetShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        //public async Task<IEnumerable<ProductViewModel>> GetAllProductsOfCategoryAsync(int Id)
        //{
        //    Category category = await dbContext.Categories.FindAsync(Id);

        //    List<ProductViewModel> products = category.Products.Select(p => new ProductViewModel()
        //    {
        //        Name = p.Name,
        //        Description = p.ShortDescription,
        //        ImageUrl = p.ImageUrl,
        //        Price = p.Price.ToString()
        //    })
        //        .ToList();
            
        //    return products;
        //}

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
