using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Infrastructure.Data.Configurations;
using PetShopProject.Infrastructure.Data.Models;

namespace PetShopProject.Infrastructure.Data
{
    public class PetShopDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfigurations());
            builder.ApplyConfiguration(new BlogPostEntityConfigurations());
            builder.ApplyConfiguration(new BlogPostTagEntityConfigurations());
            builder.ApplyConfiguration(new OrderDetailsEntityConfigurations());
            builder.ApplyConfiguration(new OrderEntityConfigurations());
            builder.ApplyConfiguration(new ProductEntityConfigurations());
            builder.ApplyConfiguration(new TagEntityConfigurations());

            base.OnModelCreating(builder); 
        }
    }
}
