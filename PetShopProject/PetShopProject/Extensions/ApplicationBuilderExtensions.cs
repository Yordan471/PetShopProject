using Microsoft.AspNetCore.Identity;
using PetShopProject.Infrastructure.Data.Models;
using static PetShopProject.Common.RoleConstants;
using static PetShopProject.Infrastructure.Data.RolesDataInitializer;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(RoleAdming) == false)
            {
                await SeedData(userManager, roleManager);
            }
        }
    }
}
