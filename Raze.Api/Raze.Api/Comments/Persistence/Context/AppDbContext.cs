using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Extensions;

namespace Raze.Api.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>().ToTable("comments");
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.Text).IsRequired().HasMaxLength(200);
            
            builder.UseSnakeCaseNamingConventions();
        }
    }
}