using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Common
{
    public static class EntityValidationsErrorMessages
    {
        // USER
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

        // Postal code registration
        public const string PostalCodeRequiredErrMessage = "Пощенският код е задължителен.";
        public const string PostalCodeInccorectLength = "Пощенския код трябва да бъде {2} и най-много {1} цифри.";
        public const string PostalCodeOnlyDigitsErrMessage = "Пощенския код се състои само от цифри.";

        // City registration
        public const string CityRequiredErrMessage = "Градът е задължителен.";
        public const string CityInccorectLength = "Името на града трябва да бъде {2} и най-много {1} знака.";

        // Street registration
        public const string StreetRequiredErrMessage = "Улицата е задължителна.";
        public const string StreetInccorectLength = "Улицата трябва да бъде {2} и най-много {1} знака.";

        // Street number registration
        public const string StreetNumberRequiredErrMessage = "Номерът на улицата е задължителен.";
        public const string StreetNumberInccorectLength = "Номерът на улицата трябва да бъде {2} и най-много {1} знака.";

        // CATEGORY
        // Name Category Create
        public const string NameCategoryInccorectLength = "Името на категорията трябва да бъде {2} и най-много {1} знака.";

        // Description Category Create
        public const string DescriptionCategoryInccorectlength = "Описанието на категорията трябва да бъде {2} и най-много {1} знака.";

        // AnimalType Category Create
        public const string AnimalTypeCategoryInccorectLength = "Името на вида животно трябва да бъде {2} и най-много {1} знака.";

        // PRODUCT
        // Price Product Create
        public const string PriceProductInccorectRange = "Цената на продукта трябва да буде {2} и най-много {1} лева.";

        // ImageUrl Product Create
        public const string ImageUrlProductInccorectLength = "Пътят до снимката на продукта трябва да бъде {2} и най-много {1} знака.";
    }
}
