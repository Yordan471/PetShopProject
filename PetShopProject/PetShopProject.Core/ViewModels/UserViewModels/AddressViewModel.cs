using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.AddressValidations;
using static PetShopProject.Common.EntityValidationsErrorMessages;

namespace PetShopProject.ViewModels.UserViewModels
{
    public class AddressViewModel
    {
        /// <summary>
        /// City chosen by the user for registration
        /// </summary>
        [Required(ErrorMessage = CityRequiredErrMessage)]
        [Display(Name = "Град")]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength,
            ErrorMessage = CityInccorectLength)]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Street of the city
        /// </summary>
        [Required(ErrorMessage = StreetRequiredErrMessage)]
        [Display(Name = "Улица")]
        [StringLength(StreetMaxLength, MinimumLength = StreetMinLength,
            ErrorMessage = StreetInccorectLength)]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Postal code of the city
        /// </summary>
        [Required(ErrorMessage = PostalCodeRequiredErrMessage)]
        [Display(Name = "Пощенски код")]
        [StringLength(PostalCodeMaxLength, MinimumLength = PostalCodeMinLength,
            ErrorMessage = PostalCodeInccorectLength)]
        [RegularExpression(PostalCodeRegularExpression, ErrorMessage = PostalCodeOnlyDigitsErrMessage)]
        public string PostalCode { get; set; } = string.Empty;
    }
}
