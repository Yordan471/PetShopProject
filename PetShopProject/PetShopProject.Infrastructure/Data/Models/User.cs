using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.UserValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User() 
        {
            Orders = new HashSet<Order>();
            Comments = new HashSet<Comment>();
            CartItems = new HashSet<CartItem>();
            BlogPosts = new HashSet<BlogPost>();
        }

        [Comment("User's first name")]
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Comment("User's last name")]
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Comment("User's address")]
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        [Comment("Recipient name")]
        [Required]
        [MaxLength(RecipientNameMaxLength)]
        public string RecipientName { get; set; } = string.Empty;

        public ContactPreference ContactPreferance { get; set; }

        [Comment("User's collection of orders")]
        public ICollection<Order> Orders { get; set; }

        [Comment("User's collection of comments")]
        public ICollection<Comment> Comments { get; set; }

        [Comment("User's collection of cart items")]
        public ICollection<CartItem> CartItems { get; set; }

        [Comment("User's collection of blog posts")]
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
