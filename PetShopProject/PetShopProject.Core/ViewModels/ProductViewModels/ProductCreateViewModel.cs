using PetShopProject.Core.ViewModels.CategoryViewModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static PetShopProject.Common.EntityValidationsConstants.ProductValidations;
using static PetShopProject.Common.EntityValidationsErrorMessages;

namespace PetShopProject.Core.ViewModels.ProductViewModels
{
    /// <summary>
    /// Product view model for creating product
    /// </summary>
    public class ProductCreateViewModel
    {
        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
            ErrorMessage = NameCategoryInccorectLength)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Product long description for details
        /// </summary>
        [Required]
        [StringLength(LongDescriptionMaxLength, MinimumLength = LongDescriptionMinLength,
            ErrorMessage = DescriptionCategoryInccorectlength)]
        public string LongDescription { get; set; } = string.Empty;

        /// <summary>
        /// Product short desciption
        /// </summary>
        [Required]
        [StringLength(ShortDescriptionMaxLength, MinimumLength = ShortDescriptionMinLength,
            ErrorMessage = DescriptionCategoryInccorectlength)]
        public string ShortDescription { get; set; } = string.Empty;

        /// <summary>
        /// Price of a product
        /// </summary>
        [Required]
        [Range(PriceMinValue, PriceMaxValue,
            ErrorMessage = PriceProductInccorectRange)]
        public decimal Price { get; set; }

        /// <summary>
        /// Product quantity for store
        /// </summary>
        [Required]
        [Range(QuantityMaxValue, QuantityMinValue,
            ErrorMessage = QuantityProductInccorectRange)]
        public int Quantity { get; set; }

        /// <summary>
        /// Image url for product
        /// </summary>
        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength,
            ErrorMessage = ImageUrlProductInccorectLength)]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Animal type
        /// </summary>
        [Required]
        [StringLength(AnimalTypeMaxLength, MinimumLength = AnimalTypeMinLength,
            ErrorMessage = AnimalTypeCategoryInccorectLength)]
        public string AnimalType { get; set; } = string.Empty;

        /// <summary>
        /// Category identifier
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category collection to choose of
        /// </summary>
        public IEnumerable<CategoryForCreateProductViewModel> Categories { get; set; }
    }
}
