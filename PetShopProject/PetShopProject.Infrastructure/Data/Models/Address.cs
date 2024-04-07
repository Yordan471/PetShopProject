using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetShopProject.Common.EntityValidationsConstants.AddressValidations;

namespace PetShopProject.Infrastructure.Data.Models
{
    [Comment("Address entity")]
    public class Address
    {
        [Comment("Address identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("City for registration")]
        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = string.Empty;

        [Comment("Street for registration")]
        [Required]
        [MaxLength(StreetMaxLength)]
        public string Street { get; set; } = string.Empty;

        [Comment("Postal code for registration")]
        [Required]
        [MaxLength(PostalCodeMaxLength)]
        public string PostalCode { get; set; } = string.Empty;

        [Comment("User identifier")]
        [Required]
        public Guid UserId { get; set; }

        [Comment("User entity")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
