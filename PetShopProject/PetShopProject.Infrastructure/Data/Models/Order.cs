using Microsoft.AspNetCore.Identity;
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

    [Comment("Order of product/s")]
    public class Order
    {
        [Comment("Order identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("User identifier")]
        [Required]
        public int UserId { get; set; }

        [Comment("User entity")]
        public IdentityUser User { get; set; }

        [Comment("Date time of order")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Comment("Total price of order")]
        [Required]
        public decimal TotalAmount { get; set; }

        [Comment("Order is completed or not")]
        [Required]
        public bool IsCompleted { get; set; } 
    }
}
