using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Infrastructure.Data.Configurations
{
    public class BlogPostEntityConfigurations : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasMany(b => b.Comments)
            .WithOne(c => c.BlogPost)
            .HasForeignKey(c => c.BlogPostId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BlogPostsTags)
            .WithOne(pt => pt.BlogPost)
            .HasForeignKey(pt => pt.BlogPostId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
