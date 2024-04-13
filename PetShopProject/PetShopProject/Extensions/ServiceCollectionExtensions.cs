using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Core.Contracts;
using PetShopProject.Core.Services;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.Services;
using static PetShopProject.Common.GlobalConstants;

namespace PetShopProject.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartService, CartService>();

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
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
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
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<PetShopDbContext>();
            
            return services;
        }
    }
}
