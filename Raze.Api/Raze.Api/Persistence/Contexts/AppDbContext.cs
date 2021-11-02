using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Extensions;

namespace Raze.Api.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Comment> Comments { get; set; }
       
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Interest>().ToTable("Interests");
            builder.Entity<Interest>().HasKey(p => p.Id);
            builder.Entity<Interest>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Interest>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Interest>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Interest>().Property(p => p.Published).IsRequired();
            
            //TODO - Relationships with users
            
            builder.Entity<Interest>().HasData
            (
                new Interest{Id=500,Title = "Casual",Description = "Informal clothes",Published = true},
                new Interest{Id=501,Title = "Formal",Description = "Formal and elegant clothes",Published = false},
                new Interest{Id=502,Title = "Sport",Description = "Clothes for training",Published = true}
            );
            
            builder.Entity<Comment>().ToTable("comments");
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.Text).IsRequired().HasMaxLength(200);
            
            builder.UseSnakeCaseNamingConventions();
        }
    }
}