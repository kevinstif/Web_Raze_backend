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
        public DbSet<UserAdvised>UserAdviseds { get; set; }
        public DbSet<UserAdvisor>UserAdvisors{ get; set; }
        public DbSet<Tag>Tags { get; set; }

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
            builder.Entity<Interest>().HasMany(p => p.UserAdvisors)
                .WithOne(p => p.Interest)
                .HasForeignKey(p => p.InterestId);
            builder.Entity<Interest>().HasMany(p => p.UserAdviseds)
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
            
            builder.Entity<UserAdvised>().ToTable("UserAdviseds");
            builder.Entity<UserAdvisor>().ToTable("UserAdvisors");
            //discriminator
            //Constrains Advised
            builder.Entity<UserAdvised>().HasKey(p => p.Id);
            builder.Entity<UserAdvised>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserAdvised>().HasMany(p => p.Comments)
                .WithOne(p => p.UserAdvised)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserAdvised>().HasMany(p => p.Posts)
                .WithOne(p => p.UserAdvised)
                .HasForeignKey(p => p.UserId);
            
            //Constrarins Advisor
            builder.Entity<UserAdvisor>().HasKey(p => p.Id);
            builder.Entity<UserAdvisor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserAdvisor>().HasMany(p => p.Comments)
                .WithOne(p => p.UserAdvisor)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserAdvisor>().HasMany(p => p.Posts)
                .WithOne(p => p.UserAdvisor)
                .HasForeignKey(p => p.UserId);
            
            //Seed Data Users
            builder.Entity<UserAdvised>().HasData(
                new UserAdvised{Id = 4,FirstName = "Loriam",LastName = "KARL",UserName = "kARLO",Password = "dracula25",Age = 22,Premium =false,Mood = 2},
                new UserAdvised{Id = 5,FirstName = "Dexter",LastName = "Newbe",UserName = "Dex",Password = "Nerito27",Age = 28,Premium =true,Mood = 3}
            );
            
            builder.Entity<UserAdvisor>().HasData(
                new UserAdvisor{Id = 3,FirstName = "Drake",LastName = "Bell",UserName = "Drell",Password = "hamburgesa",Age = 23,Premium =false,YearsExperience = 13,Rank = 273,Profession = "Teacher"}
            );

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

            builder.UseSnakeCaseNamingConventions();
        }
    }
}