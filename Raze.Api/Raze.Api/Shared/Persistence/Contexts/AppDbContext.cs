﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Raze.Api.Domain.Models;
using Raze.Api.Extensions;
using Raze.Api.Security.Domain.Models;

namespace Raze.Api.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag>Tags { get; set; }
        public DbSet<Profession> Professions { get; set; }
        protected readonly IConfiguration _configuration;
        
        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
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
            builder.Entity<Interest>().Property(p => p.Img).IsRequired();
            builder.Entity<Interest>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Interest>().Property(p => p.Published).IsRequired();
            builder.Entity<Interest>().HasMany(p => p.User)
                .WithOne(p => p.Interest)
                .HasForeignKey(p => p.InterestId);
            builder.Entity<Interest>().HasMany(p => p.Posts)
                .WithOne(p => p.Interest)
                .HasForeignKey(p => p.InterestId);

            //builder.Entity<Interest>().HasData
            //(
            //    new Interest{Id=1,Title = "Casual",Img = "image",Description = "Informal clothes",Published = true},
            //    new Interest{Id=2,Title = "Formal",Img = "image",Description = "Formal and elegant clothes",Published = false},
            //    new Interest{Id=3,Title = "Sport",Img = "image",Description = "Clothes for training",Published = true}
            //);

            //Advisor
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.ImgProfile).IsRequired();
            builder.Entity<User>().Property(p => p.Age).IsRequired();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.UserType).IsRequired();
            builder.Entity<User>().Property(p => p.Premium).IsRequired();

            builder.Entity<User>().HasOne(p => p.Profession)
                .WithMany(p => p.User)
                .HasForeignKey(p => p.ProfessionId);
            builder.Entity<User>().HasOne(p => p.Interest)
                .WithMany(i => i.User)
                .HasForeignKey(p => p.InterestId);
            
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
            
            //builder.Entity<Post>().HasData(
            //    new Post { Id = 1, Title = "Summer outfit", Image = "img 1", Description = "The best outfits for summer", Rate = 0, NumberOfRates = 0},
            //    new Post { Id = 2, Title = "Sprint outfit", Image = "img 2", Description = "The best outfits for Sprint", Rate = 0, NumberOfRates = 0}
            //);
            
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
            
            //builder.Entity<Profession>().HasData
            //(
            //    new Profession { Id=100, Name = "Fashion consultant"},
            //    new Profession { Id=101, Name = "Designer"}
            //);

            builder.UseSnakeCaseNamingConventions();
        }
    }
}