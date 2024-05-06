using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // find all configurations file from assembly and apply
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumDbContext).Assembly);

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
