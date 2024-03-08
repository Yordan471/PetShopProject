using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.CategoryValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Product Category")]
    public class Category
    {
        public Category() 
        {
            Products = new HashSet<Product>();
        }

        [Comment("Category identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Categiry name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Category description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Category navigation property collection to products")]
        public ICollection<Product> Products { get; set; }
    }
}
