using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Details of the order")]
    public class OrderItem
    {
        [Comment("Order details identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Order identifier")]
        [Required]
        public int OrderId { get; set; }

        [Comment("Order entity")]
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Comment("Product identifier")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Product entity")]
        public Product Product { get; set; } = null!;

        [Comment("Quantity of units")]
        [Required]
        public int Quantity { get; set; }

        [Comment("Price for a unit ot product")]
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
