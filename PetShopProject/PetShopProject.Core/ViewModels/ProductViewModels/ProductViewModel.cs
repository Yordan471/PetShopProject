using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetShopProject.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Product price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Product image url
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
