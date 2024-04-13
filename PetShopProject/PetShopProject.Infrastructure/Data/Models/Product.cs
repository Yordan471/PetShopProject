using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetShopProject.Common.EntityValidationsConstants.ProductValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Animal product")]
    public class Product
    {
        public Product() 
        {
            Comments = new HashSet<Comment>();
            OrdersDetails = new HashSet<OrderDetails>();
        }

        [Comment("Product identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Product name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Product short description")]
        [Required]
        [MaxLength(ShortDescriptionMaxLength)]
        public string ShortDescription { get; set; } = string.Empty;

        [Comment("Product long description")]
        [Required]
        [MaxLength(LongDescriptionMaxLength)]
        public string LongDescription { get; set; } = string.Empty;

        [Comment("Product price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Product image path")]
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;

        [Comment("Product quantity in store")]
        [Required]
        public int Quantity { get; set; }

        [Comment("Animal type")]
        [MaxLength(AnimalTypeMaxLength)]
        [Required]
        public string AnimalType { get; set; } = string.Empty;

        [Comment("Category identifier")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Category entity")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("Product navigation property to collection of comments")]
        public ICollection<Comment> Comments { get; set; }

        [Comment("Product navigation property to collection of orders details")]
        public ICollection<OrderDetails> OrdersDetails { get; set; }
    }
}
