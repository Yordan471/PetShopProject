using PetShopProject.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static PetShopProject.Common.EntityValidationsConstants.UserValidations;
using static PetShopProject.Common.EntityValidationsErrorMessages;
using static PetShopProject.Common.GlobalConstants;
using static PetShopProject.Common.GlobalConstantsErrorMessages;

namespace PetShopProject.ViewModels.UserViewModels
{
    /// <summary>
    /// View model for registration
    /// </summary>
    public class RegisterViewModel
    {
        public RegisterViewModel() 
        {
            ContactPreference = ContactPreference.Email;
        }

        /// <summary>
        /// Last name of the user
        /// </summary>
        [Required(ErrorMessage = LastNameRequiredErrMessage)]
        [Display(Name = "Фамилия")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, 
            ErrorMessage = LastNameInccorectLength)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// First name of the user
        /// </summary>
        [Required(ErrorMessage = FirstNameRequiredErrMessage)]
        [Display(Name = "Име")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength,
            ErrorMessage = FirstNameInccorectLength)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Email of the user for registration
        /// </summary>
        [Required(ErrorMessage = EmailRequiredErrMessage)]
        [EmailAddress]
        [Display(Name = "Имейл адрес")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Confirm email for registration
        /// </summary>
        [Required(ErrorMessage = ConfirmEmailRequiredErrMessage)]
        [EmailAddress]
        [Compare("Email", ErrorMessage = ConfirmEmailCompareErrMessage)]
        [Display(Name = "Потвърди имейл адрес")]
        public string ConfirmEmail { get; set; } = string.Empty;

        /// <summary>
        /// Password of the user for registration
        /// </summary>
        [Required(ErrorMessage = PasswordRequiredErrMessage)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = PasswordInccorectLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Confirm password for registration
        /// </summary>
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ConfirmPasswordCompareErrMessage)]
        [Display(Name = "Потвърди парола")]
        public string ConfirmPassword { get; set; } = string.Empty;

        /// <summary>
        /// Phone number of the user for registration
        /// </summary>
        [Required(ErrorMessage = PhoneNumberRequiredErrMessage)]
        [Phone]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// A way to contact the user
        /// </summary>
        [Display(Name = "Предпочитан контакт")]
        public ContactPreference ContactPreference { get; set; }

        /// <summary>
        /// Name of the recipient of the purchase
        /// </summary>
        [Required(ErrorMessage = RecipientNameRequiredErrMessage)]
        [Display(Name = "Име на получател")]
        [StringLength(RecipientNameMaxLength, MinimumLength = RecipientNameMinLength, 
            ErrorMessage = RecipientNameInccorectLength)]
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// Address for the purchase to be delivered
        /// </summary>
        [Required]
        public AddressViewModel Address { get; set; }
    }
}

