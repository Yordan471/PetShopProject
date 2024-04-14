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
            public const int RecipientNameMaxLength = 50;
            public const int RecipientNameMinLength = 2;
            public const double BankAccountAmountMaxValue = 100000;
            public const double BankAccountAmountMinValue = 0;
        }

        public static class AddressValidations
        {
            public const int PostalCodeMaxLength = 12;
            public const int PostalCodeMinLength = 4;
            public const string PostalCodeRegularExpression = "^\\d{4}$";
            public const int CityMaxLength = 25;
            public const int CityMinLength = 2;
            public const int StreetMaxLength = 50;
            public const int StreetMinLength = 2;
        }

        public static class ProductValidations
        {
            public const int NameMaxLength = 150;
            public const int NameMinLength = 3;
            public const int LongDescriptionMaxLength = 1000;
            public const int LongDescriptionMinLength = 5;
            public const int ShortDescriptionMaxLength = 100;
            public const int ShortDescriptionMinLength = 5;
            public const double PriceMaxValue = 10000;
            public const double PriceMinValue = 0;
            public const int QuantityMaxValue = 10000;
            public const int QuantityMinValue = 0;
            public const int ImageUrlMaxLength = 2048;
            public const int ImageUrlMinLength = 5;
            public const int AnimalTypeMaxLength = 25;
            public const int AnimalTypeMinLength = 2;
        }

        public static class CategoryValidations
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
            public const int DescriptionMaxLength = 300;
            public const int DescriptionMinLength = 2;
            public const int AnimalTypeMaxLength = 25;
            public const int AnimalTypeMinLength = 2;
        }

        public static class OrderValidations
        {
            public const decimal TotalAmountMaxValue = int.MaxValue;
            public const decimal TotalAmountMinValue = 0.01M;
        }

        public static class OrderDetailsValidations
        {
            public const int QuantityMaxValue = 100;
            public const int QuantityMinValue = 1;
            public const decimal PriceMaxValue = int.MaxValue;
            public const decimal PriceMinValue = 0.01M;
        }

        public static class CartDetailsValidations
        {
            public const int QuantityMaxValue = 100;
            public const int QuantityMinValue = 1;
            public const decimal PriceMaxValue = int.MaxValue;
            public const decimal PriceMinValue = 0.01M;
        }

        public static class BlogPostValidations
        {
            public const int TitleMaxLength = 150;
            public const int TitleMinLength = 3;
            public const int ContentMaxValue = 5000;
            public const int ContentMinValue = 100;
            public const int ImageUrlMaxLength = 2048;
        }

        public static class TagValidations
        {
            public const int TagNameMaxLength = 50;
            public const int TagNameMinLength = 3;  
        }

        public static class CommentValidations
        {
            public const int ContentMaxValue = 5000;
            public const int ContentMinValue = 2;
        }
    }
}
