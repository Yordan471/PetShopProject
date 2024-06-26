﻿using System;
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

        // Product and category animaltype property
        public const string AnimalTypeDog = "Куче";
        public const string AnimalTypeCat = "Котка";
        public const string AnimalTypeBird = "Птица";
    }

}
