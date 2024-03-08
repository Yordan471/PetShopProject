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

        [Comment("Post identifier")]
        [Required]
        public int PostId { get; set; }

        [Comment("Blog post entity")]
        [ForeignKey(nameof(PostId))]
        public BlogPost BlogPost { get; set; } = null!;

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
    }
}
