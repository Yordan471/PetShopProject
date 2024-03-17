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
            public const int AddressMaxLength = 150;
            public const int AddressMinLength = 3;
            public const int RecipientNameMaxLength = 50;
            public const int RecipientNameMinLength = 2;    
        }

        public static class ProductValidations
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
            public const int DescriptionMaxLength = 150;
            public const int DescriptionMinLength = 2;
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
