using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Common
{
    public static class EntityValidationsConstants
    {
        public static class UserValidations
        {
            public const int FirstNameMaxLength = 50;
            public const int FirstNameMinLength = 2;
            public const int LastNameMaxLength = 50;
            public const int LastNameMinLength = 2;
            public const int PasswordMaxLength = 128;
            public const int PasswordMinLength = 8;
        }

        public static class Product
        {
            public const int NameMaxLength = 150;
            public const int NameMinLength = 3;
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 5;
            public const string PriceMaxValue = "10000";
            public const string PriceMinValue = "0";
            public const int ImageUrlMaxLength = 2048;
        }

        public static class CategoryValidations
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }


    }
}
