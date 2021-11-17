using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Extensions;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag>Tags { get; set; }
        public DbSet<Profession> Professions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tag>().ToTable("tags");
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Title).IsRequired().HasMaxLength(20);
            builder.Entity<Tag>().HasMany(p => p.Posts)
                .WithOne(p => p.Tag)
                .HasForeignKey(p => p.TagId);
            
            builder.Entity<Interest>().ToTable("Interests");
            builder.Entity<Interest>().HasKey(p => p.Id);
            builder.Entity<Interest>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();    
            builder.Entity<Interest>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Interest>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Interest>().Property(p => p.Published).IsRequired();
            builder.Entity<Interest>().HasMany(p => p.User)
                .WithOne(p => p.Interest)
                .HasForeignKey(p => p.InterestId);
            builder.Entity<Interest>().HasMany(p => p.Posts)
                .WithOne(p => p.Interest)
                .HasForeignKey(p => p.InterestId);

            builder.Entity<Interest>().HasData
            (
                new Interest{Id=500,Title = "Casual",Description = "Informal clothes",Published = true},
                new Interest{Id=501,Title = "Formal",Description = "Formal and elegant clothes",Published = false},
                new Interest{Id=502,Title = "Sport",Description = "Clothes for training",Published = true}
            );

            //Advisor
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            
            //Constrarins Advisor
            builder.Entity<User>().HasMany(p => p.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            builder.Entity<User>().HasMany(p => p.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(20);
            builder.Entity<Post>().Property(p => p.Image).IsRequired();
            builder.Entity<Post>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Entity<Post>().Property(p => p.Rate).IsRequired().ValueGeneratedOnUpdateSometimes();
            builder.Entity<Post>().Property(p => p.NumberOfRates).IsRequired().ValueGeneratedOnUpdateSometimes();
            builder.Entity<Post>().HasMany(p => p.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId);
            
            builder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Summer outfit", Image = "img 1", Description = "The best outfits for summer", Rate = 0, NumberOfRates = 0},
                new Post { Id = 2, Title = "Sprint outfit", Image = "img 2", Description = "The best outfits for Sprint", Rate = 0, NumberOfRates = 0}
            );
            
            builder.Entity<Comment>().ToTable("comments");
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.Text).IsRequired().HasMaxLength(200);
            
            builder.Entity<Profession>().ToTable("Professions");
            builder.Entity<Profession>().HasKey(p => p.Id);
            builder.Entity<Profession>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profession>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Profession>().HasMany(p => p.User)
                .WithOne(p => p.Profession)
                .HasForeignKey(p => p.ProfessionId);
            
            builder.Entity<Profession>().HasData
            (
                new Profession { Id=100, Name = "Fashion consultant"},
                new Profession { Id=101, Name = "Designer"}
            );

            builder.UseSnakeCaseNamingConventions();
        }
    }
}