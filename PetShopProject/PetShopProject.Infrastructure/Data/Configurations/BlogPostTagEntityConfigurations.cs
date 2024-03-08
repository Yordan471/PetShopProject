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
    public class BlogPostTagEntityConfigurations : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.HasKey(pt => new { pt.BlogPostId, pt.TagId });

            builder.HasOne(pt => pt.BlogPost)
                .WithMany(b => b.BlogPostsTags)
                .HasForeignKey(pt => pt.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Tag)
                .WithMany(t => t.BlogPostsTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
