using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    Id = 1,
                    Content = "Post Content",
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now,
                }
            );

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(10000);
        }
    }
}
