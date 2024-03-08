using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("PostTag entity")]
    public class BlogPostTag
    {
        public BlogPostTag() 
        {
            BlogPostsTags = new HashSet<BlogPostTag>();
        }

        [Comment("Post identifier")]
        [Required]
        public int BlogPostId { get; set; }

        [Comment("Blog post entity")]
        [ForeignKey(nameof(BlogPostId))]
        public BlogPost BlogPost { get; set; } = null!;

        [Comment("Tag identifier")]
        [Required]
        public int TagId { get; set; }

        [Comment("Tag entity")]
        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; } = null!;

        [Comment("BlogPost navigation property to collection blog posts tags")]
        public ICollection<BlogPostTag> BlogPostsTags { get; set; }
    }
}
