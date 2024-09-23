using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Persistence.DatabaseContext
{
    public class ForumDbContext: DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<Like> Likes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set;}
        public DbSet<BlogComment> BlogComments {get; set;}

        public DbSet<StaticPage> StaticPages { get; set; }

        public DbSet<TrackingLog> TrackingLogs { get; set; }

        public DbSet<Logo> Logos { get; set; }

        public DbSet<ForumSettings> ForumSettings { get; set; }

        public DbSet<UploadFile> UploadFiles { get; set; }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // find all configurations file from assembly and apply
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumDbContext).Assembly);

            modelBuilder.Entity<Category>()
                .HasIndex(u => u.CategoryId)
                .IsUnique();

            modelBuilder.Entity<BlogPost>()
                .HasIndex(u => u.BlogPostId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                entry.Entity.DateUpdate = DateTime.UtcNow;
                
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreate = DateTime.UtcNow;
                    entry.Entity.IsActive = true;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
