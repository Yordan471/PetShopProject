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

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogPostTag> BlogPostsTags { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrdersDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfigurations());
            builder.ApplyConfiguration(new BlogPostEntityConfigurations());
            builder.ApplyConfiguration(new BlogPostTagEntityConfigurations());
            builder.ApplyConfiguration(new OrderDetailsEntityConfigurations());
            builder.ApplyConfiguration(new OrderEntityConfigurations());
            builder.ApplyConfiguration(new ProductEntityConfigurations());
            builder.ApplyConfiguration(new TagEntityConfigurations());
            builder.ApplyConfiguration(new CategoryConfigurations());
            builder.ApplyConfiguration(new AddressConfigurations());

            base.OnModelCreating(builder); 
        }
    }
}
