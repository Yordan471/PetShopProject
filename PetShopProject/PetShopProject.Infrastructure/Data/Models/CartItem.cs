using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Cart with item")]
    public class CartItem
    {
        [Comment("Cart item identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Custummer identifier")]
        [Required]
        public string CustrummerId { get; set; } = string.Empty;

        [Comment("Custummer entity")]
        public IdentityUser Custummer { get; set; } = null!;

        [Comment("Product identifier")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Product entity")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("Quantity of a product")]
        [Required]
        public int Quantity { get; set; }

        [Comment("Price of a single unit for product")]
        [Required]
        
        public decimal UnitPrice { get; set; }
    }
}
