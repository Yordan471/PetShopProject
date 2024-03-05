using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetShopProject.Common.EntityValidationsConstants.BlogPostValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Blog post of a user")]
    public class BlogPost
    {
        [Comment("Blog post identifuer")]
        [Key]
        public int Id { get; set; }

        [Comment("Title of a blog post")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Content of blog post")]
        [Required]
        [MaxLength(ContentMaxValue)]
        public string Content { get; set; } = null!;

        [Comment("Date time of publishing blog post")]
        [Required]
        public DateTime PublishDate { get; set; }

        [Comment("Author identifier")]
        [Required]
        public string AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public IdentityUser Author { get; set; } = null!;
    }
}
