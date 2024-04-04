using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Core.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            RememberMe = false;
            ExternalLogins = new List<AuthenticationScheme>();
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

    }
}
