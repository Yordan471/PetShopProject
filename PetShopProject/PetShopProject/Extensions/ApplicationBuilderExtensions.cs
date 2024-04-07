using Microsoft.AspNetCore.Identity;
using PetShopProject.Infrastructure.Data.Models;
using static PetShopProject.Common.RoleConstants;
using static PetShopProject.Infrastructure.Data.SeedData;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
          
            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(RoleAdmin) == false)
            {
                var role = new IdentityRole<Guid>()
                {
                    Name = RoleAdmin,
                    NormalizedName = NormalizedRoleAdmin,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };
                await roleManager.CreateAsync(role);   
            }

            var admin = await userManager.FindByNameAsync("Ivanov");

            if (admin == null)
            {
                throw new InvalidOperationException($"User 'Ivanov' not found.");
            }

            if (string.IsNullOrEmpty(admin.SecurityStamp))
            {
                admin.SecurityStamp = Guid.NewGuid().ToString();
                var updateResult = await userManager.UpdateAsync(admin);
                if (!updateResult.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to update security stamp for user 'Ivanov': {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
                }
            }

            await userManager.AddToRoleAsync(admin, RoleAdmin);
        }

        public static async Task CreateModeratorRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(RoleModerator) == false)
            {
                var role = new IdentityRole<Guid>()
                {
                    Name = RoleModerator,
                    NormalizedName = NormalizedRoleModerator,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
