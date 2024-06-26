﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopProject.Infrastructure.Data.Models;
using static PetShopProject.Infrastructure.Data.SeedData;

namespace PetShopProject.Infrastructure.Data.Configurations
{
    public class UserEntityConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.BlogPosts)
                .WithOne(bp => bp.Author)
                .HasForeignKey(bp => bp.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.CartItems)
                .WithOne(ci => ci.Custummer)
                .HasForeignKey(ci => ci.CustummerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<User>(u => u.AddressId);

            builder
                .Property(u => u.BankAccountAmount)
                .HasPrecision(18, 2);

            SeedData seedData = new();

            builder.HasData(new User[] { seedData.AdminUser });
        }
    }
}
