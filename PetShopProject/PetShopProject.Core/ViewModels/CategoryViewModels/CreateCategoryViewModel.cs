using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.CategoryValidations;
using static PetShopProject.Common.EntityValidationsErrorMessages;

namespace PetShopProject.Core.ViewModels.CategoryViewModels
{
    public class CreateCategoryViewModel    
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
            ErrorMessage = NameCategoryInccorectLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, 
            ErrorMessage = DescriptionCategoryInccorectlength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string AnimalType { get; set; } = string.Empty;
    }
}
