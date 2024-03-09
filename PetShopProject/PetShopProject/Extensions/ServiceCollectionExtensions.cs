using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using static PetShopProject.Common.GlobalConstants;

namespace PetShopProject.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<PetShopDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = config
                .GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireNonAlphanumeric = config
                .GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireUppercase = config
                .GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireLowercase = config
                .GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireDigit = config
                .GetValue<bool>("Identity:Password:RequireDigit");
                options.Password.RequiredLength = config
                .GetValue<int>("Identity:Password:RequiredLength");
                options.Password.RequiredUniqueChars = config
                .GetValue<int>("Identity:Password:RequiredUniqueChars");
            })
                .AddEntityFrameworkStores<PetShopDbContext>();
            

            return services;
        }
    }
}
