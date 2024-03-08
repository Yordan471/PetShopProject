using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Infrastructure.Data;
using PetShopProject.Infrastructure.Data.Models;

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
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<PetShopDbContext>();
            

            return services;
        }
    }
}
