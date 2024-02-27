using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.CategoryValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Product Category")]
    public class Category
    {
        [Comment("Category identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Categiry name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}
