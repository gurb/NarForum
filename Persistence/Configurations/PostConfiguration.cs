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
                    Id = Guid.NewGuid().ToString(),
                    Content = "Post Content",
                    DateCreate = DateTime.UtcNow,
                    DateUpdate = DateTime.UtcNow,
                }
            );

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(10000);
        }
    }
}
