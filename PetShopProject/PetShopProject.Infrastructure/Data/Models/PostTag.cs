using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("PostTag entity")]
    public class PostTag
    {
        [Comment("Post identifier")]
        [Required]
        public int PostId { get; set; }

        [Comment("Blog post entity")]
        [ForeignKey(nameof(PostId))]
        public BlogPost BlogPost { get; set; } = null!;

        [Comment("Tag identifier")]
        [Required]
        public int TagId { get; set; }

        [Comment("Tag entity")]
        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; } = null!;
    }
}
