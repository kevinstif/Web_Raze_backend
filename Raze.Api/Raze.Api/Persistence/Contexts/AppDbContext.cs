using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Extensions;

namespace Raze.Api.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(20);
            builder.Entity<Post>().Property(p => p.Image).IsRequired();
            builder.Entity<Post>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Entity<Post>().Property(p => p.Rate).IsRequired().ValueGeneratedOnUpdateSometimes();
            builder.Entity<Post>().Property(p => p.NumberOfRates).IsRequired().ValueGeneratedOnUpdateSometimes();

            builder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Summer outfit", Image = "img 1", Description = "The best outfits for summer", Rate = 0, NumberOfRates = 0},
                new Post { Id = 2, Title = "Sprint outfit", Image = "img 2", Description = "The best outfits for Sprint", Rate = 0, NumberOfRates = 0}
                );
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}