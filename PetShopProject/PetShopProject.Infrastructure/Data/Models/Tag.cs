using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.TagValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Tag entity")]
    public class Tag
    {
        public Tag() 
        {
            BlogPostsTags = new HashSet<BlogPostTag>();
        }

        [Comment("Tag identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Tag name")]
        [Required]
        [MaxLength(TagNameMaxLength)]
        public string TagName { get; set; } = null!;

        [Comment("Tag navigation property to collection of blog post tags")]
        public ICollection<BlogPostTag> BlogPostsTags { get; set; }
    }
}
