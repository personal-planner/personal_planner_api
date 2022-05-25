using DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace DAL
{
    public class PlannerDbContext : IdentityDbContext<UserModel>
    {
        public PlannerDbContext(DbContextOptions options) : base(options)
        {
            if(Database.EnsureCreated())
            {
                /*UserModel u1 = new UserModel()
                {
                    Email = "Email 1@gmail.com", 
                    UserName = "Username 1", 
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                userManager.CreateAsync(u1, "qweQWE1!").Wait();*/
                //roleManager.CreateAsync(new IdentityRole(UserRoles.)).Wait();

                /*var c1 = Categories.Add(new CategoryModel { ColorCode= "#BB5F4C", Title="Title 1", Order = 1, User = u1 }).Entity;
                var c2 = Categories.Add(new CategoryModel { ColorCode= "#4CBB99", Title="Title 1", Order = 1, User = u1 }).Entity;
                var c3 = Categories.Add(new CategoryModel { ColorCode= "#4C8ABB", Title="Title 1", Order = 1, User = u1 }).Entity;
                var c4 = Categories.Add(new CategoryModel { ColorCode = "#8547A9", Title = "Title 1", Order = 1, User = u1 }).Entity;
                
                SaveChanges();

                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.High, Category = c1, Title = "Title 1", Description = "Description 1", ScheduledEndDate = DateTime.Now.AddDays(3), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.Highest, Category = c1, Title = "Title 2", Description = "Description 2", ScheduledEndDate = DateTime.Now.AddDays(2), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.Low, Category = c2, Title = "Title 3", Description = "Description 3", ScheduledEndDate = DateTime.Now.AddDays(4), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.High, Category = c2, Title = "Title 4", Description = "Description 4", ScheduledEndDate = DateTime.Now.AddDays(2), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.Medium, Category = c3, Title = "Title 5", Description = "Description 5", ScheduledEndDate = DateTime.Now.AddDays(3), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.Lowest, Category = c3, Title = "Title 6", Description = "Description 6", ScheduledEndDate = DateTime.Now.AddDays(5), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.Low, Category = c4, Title = "Title 7", Description = "Description 7", ScheduledEndDate = DateTime.Now.AddDays(1), User = u1 });
                Acts.Add(new ActModel { CreatedAt = DateTime.Now, ScheduledDuration = 100000000, Priority = ActPriority.Highest, Category = c4, Title = "Title 8", Description = "Description 8", ScheduledEndDate = DateTime.Now.AddDays(5), User = u1 });
                SaveChanges();*/
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ActModel> Acts { get; set; }
        public new virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<CategoryModel> Categories { get; set; }
    }
}
