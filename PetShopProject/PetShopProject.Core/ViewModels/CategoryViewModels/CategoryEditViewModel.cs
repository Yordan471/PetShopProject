using System.ComponentModel.DataAnnotations;

using static PetShopProject.Common.EntityValidationsErrorMessages;
using static PetShopProject.Common.EntityValidationsConstants.CategoryValidations;

namespace PetShopProject.Core.ViewModels.CategoryViewModels
{
    public class CategoryEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, 
            ErrorMessage = NameCategoryInccorectLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, 
            ErrorMessage = DescriptionCategoryInccorectlength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(AnimalTypeMaxLength, MinimumLength = AnimalTypeMinLength, 
            ErrorMessage = AnimalTypeCategoryInccorectLength)]
        public string AnimalType { get; set; } = string.Empty;
    }
}
