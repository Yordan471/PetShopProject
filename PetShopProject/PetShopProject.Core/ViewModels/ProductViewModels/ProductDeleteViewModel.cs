using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Core.ViewModels.ProductViewModels
{
    /// <summary>
    /// View for delete action
    /// </summary>
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
