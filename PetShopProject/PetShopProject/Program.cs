using Microsoft.AspNetCore.Identity;
using PetShopProject.Extensions;
using PetShopProject.Infrastructure.Data.Models;
using PetShopProject.ModelBindings.Providers;

namespace PetShopProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });

            builder.Services.AddApplicationServices();
            builder.Services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
                });



            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.CreateAdminRoleAsync();
            app.CreateModeratorRoleAsync();

            app.Run();
        }
    }
}