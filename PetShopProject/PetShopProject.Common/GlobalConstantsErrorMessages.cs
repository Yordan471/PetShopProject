using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Common
{
    public class GlobalConstantsErrorMessages
    {
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

        // Street number
        public const string StreetNumberRequiredErrMessage = "Номерът на улицата е задължителен.";
        public const string StreetNumberInccorectLength = "Номерът на улицата трябва да бъде {2} и най-много {1} знака.";
    }
}
