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
            PostsTags = new HashSet<PostTag>();
        }

        [Comment("Tag identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Tag name")]
        [Required]
        [MaxLength(TagNameMaxLength)]
        public string TagName { get; set; } = null!;

        [Comment("Collection of posts and tags")]
        public ICollection<PostTag> PostsTags { get; set; }
    }
}
