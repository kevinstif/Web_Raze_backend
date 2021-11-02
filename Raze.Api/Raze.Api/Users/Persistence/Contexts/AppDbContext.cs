using Microsoft.EntityFrameworkCore;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        
        public DbSet<UserAdvised>UserAdviseds { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Inicialitation
          
            builder.Entity<UserAdvised>().ToTable("UserAdviseds");
            //discriminator
            //Constrains 
            builder.Entity<UserAdvised>().HasKey(p => p.Id);
            builder.Entity<UserAdvised>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Seed Data Users
            builder.Entity<UserAdvised>().HasData(
                new UserAdvised{Id = 4,FirstName = "Loriam",LastName = "KARL",UserName = "kARLO",Password = "dracula25",Age = 22,Premium =false,Mood = 2},
                new UserAdvised{Id = 5,FirstName = "Dexter",LastName = "Newbe",UserName = "Dex",Password = "Nerito27",Age = 28,Premium =true,Mood = 3}
            );
        }
        
    }
    
    
}