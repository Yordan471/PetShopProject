using Microsoft.AspNetCore.Identity;
using PetShopProject.Infrastructure.Data.Models;
using static PetShopProject.Common.RoleConstants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRole(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(RoleAdming) == false)
            {
                var role = new IdentityRole<Guid>(RoleAdming);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("jordan4.71@abv.bg");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, RoleAdming);
                }
            }
        }
    }
}
