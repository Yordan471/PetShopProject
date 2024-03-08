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
        public BlogPost() 
        {
            BlogPostsTags = new HashSet<BlogPostTag>();
            Comments = new HashSet<Comment>();
        }
        
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
        public Guid AuthorId { get; set; }

        [Comment("Author entity")]
        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; } = null!;

        [Comment("BlogPost navigation property to comments")]
        public ICollection<Comment> Comments { get; set; }

        [Comment("BlogPost navigation property to blog posts tags")]
        public ICollection<BlogPostTag> BlogPostsTags { get; set; }
    }
}
