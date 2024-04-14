using Microsoft.EntityFrameworkCore;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.ViewModels.HomeViewModels;
using PetShopProject.Core.ViewModels.ProductViewModels;
using PetShopProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly PetShopDbContext dbContext;
        private readonly IProductService productService;

        public HomeService(PetShopDbContext _dbContext, IProductService _productService) 
        {
            dbContext = _dbContext;
            productService = _productService;
        }

        public async Task<IEnumerable<HomeViewModel>> GetProductsByAnimalAndCategoryAsync()
        {
            var viewModel = new List<HomeViewModel>();

            var animalTypes = await dbContext.Products
                .AsNoTracking()
                .Select(p => p.AnimalType)
                .Distinct()
                .ToListAsync();

            foreach (var animalType in animalTypes)
            {
                var categories = await dbContext.Products
                    .AsNoTracking()
                    .Where(p => p.AnimalType == animalType && p.Category.Products.Any())
                    .Select(p => p.Category.Name)
                    .Distinct()
                    .ToListAsync();

                foreach (var category in categories)
                {
                    var products = await dbContext.Products
                        .AsNoTracking()
                        .Where(p => p.AnimalType == animalType && p.Category.Name == category)
                        .Take(3)
                        .Select(p => new ProductViewModel()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            AnimalType = p.AnimalType,
                            ImageUrl = p.ImageUrl,
                            Description = p.ShortDescription,
                            Price = p.Price.ToString()
                        })
                        .ToListAsync();

                    viewModel.Add(new HomeViewModel
                    {
                        AnimalType = animalType,
                        CategoryName = category,
                        Products = products
                    });
                }
            }

            return viewModel;
        }
    }
}
