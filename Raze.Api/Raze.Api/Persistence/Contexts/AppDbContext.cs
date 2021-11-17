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
        public DbSet<AdvisedUser>AdvisedUsers { get; set; }
        public DbSet<AdvisorUser>AdvisorUsers{ get; set; }
        public DbSet<Tag>Tags { get; set; }
        public DbSet<Profession> Professions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //discriminator
            builder.Entity<User>()
                .HasDiscriminator<string>("user_type")
                .HasValue<AdvisedUser>("advised")
                .HasValue<AdvisorUser>("advisor");
            builder.Entity<User>()
                .Property(p => p.Type)
                .HasMaxLength(200)
                .HasColumnName("blog_type");

            //Constrains Advised
            builder.Entity<AdvisedUser>().Property(p => p.FirstName)
                .HasColumnName("first_name").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisedUser>().Property(p => p.LastName)
                .HasColumnName("last_name").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisedUser>().Property(p => p.UserName)
                .HasColumnName("user_name").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisedUser>().Property(p => p.Password)
                .HasColumnName("password").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisedUser>().Property(p => p.Age)
                .HasColumnName("age").IsRequired();
            builder.Entity<AdvisedUser>().Property(p => p.Premium)
                .HasColumnName("premium").IsRequired();
            builder.Entity<AdvisedUser>().Property(p => p.Mood)
                .HasColumnName("mood").IsRequired();
            builder.Entity<AdvisedUser>().HasMany(p => p.Comments)
                .WithOne(p => p.AdvisedUser)
                .HasForeignKey(p => p.UserId);
            builder.Entity<AdvisedUser>().HasMany(p => p.Posts)
                .WithOne(p => p.AdvisedUser)
                .HasForeignKey(p => p.UserId);
            
            //Constrarins Advisor
            builder.Entity<AdvisorUser>().Property(p => p.FirstName)
                .HasColumnName("first_name").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisorUser>().Property(p => p.LastName)
                .HasColumnName("last_name").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisorUser>().Property(p => p.UserName)
                .HasColumnName("user_name").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisorUser>().Property(p => p.Password)
                .HasColumnName("password").IsRequired().HasMaxLength(100);
            builder.Entity<AdvisorUser>().Property(p => p.Age)
                .HasColumnName("age").IsRequired();
            builder.Entity<AdvisorUser>().Property(p => p.Premium)
                .HasColumnName("premium").IsRequired();
            builder.Entity<AdvisorUser>().Property(p => p.YearsExperience)
                .HasColumnName("years_of_experience").IsRequired();
            builder.Entity<AdvisorUser>().Property(p => p.Rank)
                .HasColumnName("rank").IsRequired();
            builder.Entity<AdvisorUser>().HasMany(p => p.Comments)
                .WithOne(p => p.AdvisorUser)
                .HasForeignKey(p => p.UserId);
            builder.Entity<AdvisorUser>().HasMany(p => p.Posts)
                .WithOne(p => p.AdvisorUser)
                .HasForeignKey(p => p.UserId);
            
            //################################################################3

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
            builder.Entity<Profession>().HasMany(p => p.UserAdvisors)
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