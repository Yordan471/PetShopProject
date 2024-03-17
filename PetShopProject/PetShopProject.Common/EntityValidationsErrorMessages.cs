using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Common
{
    public static class EntityValidationsErrorMessages
    {
        // User
        // Last name registration
        public const string LastNameInccorectLength = "Фамилията трябва да бъде поне {2} и най-много {1} знака.";
        public const string LastNameRequiredErrMessage = "Фамилията е задължителна.";

        // First name registration
        public const string FirstNameInccorectLength = "Името трябва да бъде поне {2} и най-много {1} знака.";
        public const string FirstNameRequiredErrMessage = "Името е задължително.";

        // Email registration
        public const string EmailRequiredErrMessage = "Имейл адресът е задължителен.";
        public const string ConfirmEmailRequiredErrMessage = "Потвърждението на имейл адреса е задължително.";
        public const string ConfirmEmailCompareErrMessage = "Имейл адресите не съвпадат.";

        // Password registration
        public const string PasswordRequiredErrMessage = "Паролата е задължителна.";
        public const string PasswordInccorectLength = "Паролата трябва да бъде поне {2} и най-много {1} знака.";
        public const string ConfirmPasswordCompareErrMessage = "Паролите не съвпадат.";

        // Phone number registration
        public const string PhoneNumberRequiredErrMessage = "Телефонният номер е задължителен.";

        // Recipient name registration
        public const string RecipientNameRequiredErrMessage = "Името на получателя е задължително.";
        public const string RecipientNameInccorectLength = "Името на получателя трябва да бъде поне {2} и най-малко {1} знака.";

        
    }
}
