using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //builder.HasData(
            //    new Post
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Content = "Post Content",
            //        DateCreate = DateTime.UtcNow,
            //        DateUpdate = DateTime.UtcNow,
            //    }
            //);

            //builder.Property(x => x.Content)
            //    .IsRequired()
            //    .HasMaxLength(10000);
        }
    }
}
