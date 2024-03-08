using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetShopProject.Common.EntityValidationsConstants.CommentValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("User comment")]
    public class Comment
    {
        [Comment("Comment identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("User identifier")]
        [Required]
        public Guid UserId { get; set; }

        [Comment("User entity")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Comment("Comment content")]
        [Required]
        [MaxLength(ContentMaxValue)]
        public string Content { get; set; } = null!;

        [Comment("Comment creation date")]
        [Required]
        public DateTime CommentDate { get; set; }

        [Comment("Product identifier")]
        public int? ProductId { get; set; }

        [Comment("Product entity")]
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Comment("BlogPost identifier")]
        public int? BlogPostId { get; set; }

        [Comment("BlogPost entity")]
        [ForeignKey(nameof(BlogPostId))]
        public BlogPost? BlogPost { get; set; }
    }
}
