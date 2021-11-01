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
            //Constrains Users
            builder.Entity < User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.UserName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.FirstName).IsRequired();
            builder.Entity<User>().Property(p => p.LastName).IsRequired();
            
            
            //Seed Data Users
            builder.Entity<User>().HasData(
                new UserAdvisor{Id = 1,FirstName = "George",LastName = "Boston",UserName = "gerx200",Password = "goku123",Age = 52,Premium =false,TypeUser =EUserType.Advisor,YearsExperience = 20,Rank = 1273,Profession = "Doctor"},
                new UserAdvisor{Id = 2,FirstName = "Louis",LastName = "Dan",UserName = "luDan",Password = "miau09",Age = 19,Premium =true,TypeUser =EUserType.Advisor,YearsExperience = 4,Rank = 1473,Profession = "Soccer Player"},
                new UserAdvisor{Id = 3,FirstName = "Drake",LastName = "Bell",UserName = "Drell",Password = "hamburgesa",Age = 23,Premium =false,TypeUser =EUserType.Advisor,YearsExperience = 13,Rank = 273,Profession = "Teacher"}, 
                new UserAdvised{Id = 4,FirstName = "Loriam",LastName = "KARL",UserName = "kARLO",Password = "dracula25",Age = 22,Premium =false,TypeUser =EUserType.Advised,Mood = 2},
                new UserAdvised{Id = 5,FirstName = "Dexter",LastName = "Newbe",UserName = "Dex",Password = "Nerito27",Age = 28,Premium =true,TypeUser =EUserType.Advised,Mood = 3}
              
                     );
        }
    }
}