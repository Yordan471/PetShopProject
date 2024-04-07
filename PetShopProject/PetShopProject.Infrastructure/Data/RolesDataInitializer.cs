using Microsoft.AspNetCore.Identity;
using PetShopProject.Infrastructure.Data.Models;

using static PetShopProject.Common.RoleConstants;

namespace PetShopProject.Infrastructure.Data
{
    public static class RolesDataInitializer
    {
        public static async Task SeedData(UserManager<User> userManager,
           RoleManager<IdentityRole<Guid>> roleManager)
        {
            // Seed Roles
            await SeedRoles(roleManager);

            // Seed Admin User
            await SeedAdmin(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(RoleAdming))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>()
                {
                    Id = new Guid("ebcff65e-e6d5-4408-918f-527a958dd2b3"),
                    Name = RoleAdming,
                    NormalizedName = NormalizedRoleAdmin,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
            if (!await roleManager.RoleExistsAsync(RoleModerator))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>()
                {
                    Id = Guid.Parse("b1f3b56e-fa1f-494b-be34-05c98e094534"),
                    Name = RoleModerator,
                    NormalizedName = NormalizedRoleModerator,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
        }

        private static async Task SeedAdmin(UserManager<User> userManager)
        {
            var adminUser = await userManager.FindByEmailAsync("jordan4.71@abv.bg");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    Id = new Guid("6f45410f-ae12-46bf-a736-429395a0574d"),
                    FirstName = "Yordan",
                    LastName = "Ivanov",
                    UserName = "Ivanov",
                    Email = "jordan4.71@abv.bg",
                    Address = new Address()
                    {
                        Id = 1,
                        City = "Sofia",
                        PostalCode = "1000",
                        Street = "ul. Lelin",
                        UserId = Guid.Parse("6f45410f-ae12-46bf-a736-429395a0574d")
                    }
                };
                await userManager.CreateAsync(adminUser, "Adminpassword");
                await userManager.AddToRoleAsync(adminUser, RoleAdming);
            }
        }
    }
}
