using Microsoft.EntityFrameworkCore;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Persistence.Contexts
{
    public class AppDbContext :DbContext
    {
        public DbSet<User>Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Inicialitation
            builder.Entity < User>().ToTable("Users");
            builder.Entity<UserAdvised>().ToTable("Users");
            builder.Entity<UserAdvisor>().ToTable("Users");
            //discriminator
            builder.Entity<User>().HasDiscriminator<string>("user_type")
                .HasValue<UserAdvisor>("user_advisor")
                .HasValue<UserAdvised>("user_advised");
            //Constrains 
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Seed Data Users
               builder.Entity<UserAdvised>().HasData(
                   new UserAdvised{Id = 4,FirstName = "Loriam",LastName = "KARL",UserName = "kARLO",Password = "dracula25",Age = 22,Premium =false,TypeUser =EUserType.Advised,Mood = 2},
                   new UserAdvised{Id = 5,FirstName = "Dexter",LastName = "Newbe",UserName = "Dex",Password = "Nerito27",Age = 28,Premium =true,TypeUser =EUserType.Advised,Mood = 3}
            );
               builder.Entity<UserAdvisor>().HasData(
                   new UserAdvisor{Id = 3,FirstName = "Drake",LastName = "Bell",UserName = "Drell",Password = "hamburgesa",Age = 23,Premium =false,TypeUser =EUserType.Advisor,YearsExperience = 13,Rank = 273,Profession = "Teacher"}
               );
        }
    }
}