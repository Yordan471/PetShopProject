using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Common
{
    public static class GlobalConstants
    {
        // Password Constraints
        public const int PasswordMaxLength = 128;
        public const int PasswordMinLength = 8;
        public const int RequiredUniqueChars = 3;

        // Postal code 
        public const int PostalCodeMaxLength = 12;
        public const int PostalCodeMinLength = 4;
        public const string PostalCodeRegularExpression = "^\\d{4}$";

        // City 
        public const int CityMaxLength = 25;
        public const int CityMinLength = 2;

        // Street
        public const int StreetMaxLength = 50;
        public const int StreetMinLength = 2;

        // Street number
        public const int StreetNumberMaxLength = 10;
        public const int StreetNumberMinLength = 1;
    }
}
