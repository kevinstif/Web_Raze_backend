using Microsoft.EntityFrameworkCore;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Extensions;

namespace Raze.Api.Users.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        
        public DbSet<UserAdvised>UserAdviseds { get; set; }
        public DbSet<UserAdvisor>UserAdvisors{ get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Inicialitation
          
            builder.Entity<UserAdvised>().ToTable("UserAdviseds");
            builder.Entity<UserAdvisor>().ToTable("UserAdvisors");
            //discriminator
            //Constrains Advised
            builder.Entity<UserAdvised>().HasKey(p => p.Id);
            builder.Entity<UserAdvised>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Constrarins Advisor
            builder.Entity<UserAdvisor>().HasKey(p => p.Id);
            builder.Entity<UserAdvisor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Seed Data Users
            builder.Entity<UserAdvised>().HasData(
                new UserAdvised{Id = 4,FirstName = "Loriam",LastName = "KARL",UserName = "kARLO",Password = "dracula25",Age = 22,Premium =false,Mood = 2},
                new UserAdvised{Id = 5,FirstName = "Dexter",LastName = "Newbe",UserName = "Dex",Password = "Nerito27",Age = 28,Premium =true,Mood = 3}
            );
            
            builder.Entity<UserAdvisor>().HasData(
                new UserAdvisor{Id = 3,FirstName = "Drake",LastName = "Bell",UserName = "Drell",Password = "hamburgesa",Age = 23,Premium =false,YearsExperience = 13,Rank = 273,Profession = "Teacher"}
            );
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
