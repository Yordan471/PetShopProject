﻿using Microsoft.AspNetCore.Mvc;
using PetShopProject.Core.ViewModels.ProductViewModels;
using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Core.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel() 
        {
            Products = new HashSet<ProductViewModel>();
        }

        /// <summary>
        /// Category identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Category description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Animal type
        /// </summary>
        public string AnimalType { get; set; } = string.Empty;


        /// <summary>
        /// All products of a category
        /// </summary>
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
