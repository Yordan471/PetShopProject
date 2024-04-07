using Microsoft.AspNetCore.Identity;
using PetShopProject.Infrastructure.Data.Models;

using static PetShopProject.Common.RoleConstants;

namespace PetShopProject.Infrastructure.Data
{
    public class SeedData
    {
        public SeedData() 
        {
            SeedAddress();
            SeedAdmin();           
        }

        public User AdminUser { get; set; }

        public Address Address { get; set; }

        public void SeedAdmin()
        {
            var hasher = new PasswordHasher<User>();

            AdminUser = new User()
            {
                Id = new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"),
                FirstName = "Yordan",
                LastName = "Ivanov",
                UserName = "Ivanov",
                NormalizedUserName = "IVANOV",
                Email = "jordan4.71@abv.bg",
                NormalizedEmail = "JORDAN4.71@ABV.BG",
                AddressId = 1
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Adminpassword");
        }

        public void SeedAddress()
        {
            Address = new Address()
            {
                Id = 1,
                City = "Sofia",
                PostalCode = "1000",
                Street = "ul. Lelin"
            };
        }
    }
}

