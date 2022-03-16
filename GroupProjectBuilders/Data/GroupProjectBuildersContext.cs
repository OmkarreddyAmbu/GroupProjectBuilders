#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupProjectBuilders.Models;
using Microsoft.AspNetCore.Identity;

public class GroupProjectBuildersContext : DbContext
    {
        public GroupProjectBuildersContext (DbContextOptions<GroupProjectBuildersContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

               SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
           var adminRoleId = Guid.NewGuid().ToString();
           var normalUserRoleId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
            new List<IdentityRole>()
            {
                    new ()
                    {
                        Id =adminRoleId,
                        Name = "Administrator",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedName = "Administrator".ToUpper()
                    },
                    new ()
                    {
                        Id =normalUserRoleId,
                        Name = "User",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        NormalizedName = "User".ToUpper()
                    }
            }
           );

            var adminId = Guid.NewGuid().ToString();
            var normalUser1Id = Guid.NewGuid().ToString();
            var normalUser2Id = Guid.NewGuid().ToString();

            builder.Entity<User>().HasData(
            new User
            {
                Id = adminId,
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                UserName = "admin@email.com",
                NormalizedUserName = "ADMIN@EMAIL.COM",               
                PasswordHash = "AQAAAAEAACcQAAAAEDs30VwJyCURbN7HfxfYOXXeqBL/STAHcgtbTNsugTWo2C1EmOgSreoFYg0uDM2w0w==",
                SecurityStamp = "5GUYLKEWMP4GZZ5UXZNO2JAPY5IHQVP3",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            }
            );

            builder.Entity<User>().HasData(
            new User
            {
                Id = normalUser1Id,
                Email = "normal1@email.com",
                NormalizedEmail = "NORMAL1@EMAIL.COM",
                UserName = "normal1@email.com",
                NormalizedUserName = "NORMAL1@EMAIL.COM",                
                PasswordHash = "AQAAAAEAACcQAAAAEDs30VwJyCURbN7HfxfYOXXeqBL/STAHcgtbTNsugTWo2C1EmOgSreoFYg0uDM2w0w==",
                SecurityStamp = "5GUYLKEWMP4GZZ5UXZNO2JAPY5IHQVP3",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            }
           );

            builder.Entity<User>().HasData(
            new User
            {
                Id = normalUser2Id,
                Email = "normal2@email.com",
                NormalizedEmail = "NORMAL2@EMAIL.COM",
                UserName = "normal2@email.com",
                NormalizedUserName = "NORMAL2@EMAIL.COM",               
                PasswordHash = "AQAAAAEAACcQAAAAEDs30VwJyCURbN7HfxfYOXXeqBL/STAHcgtbTNsugTWo2C1EmOgSreoFYg0uDM2w0w==",
                SecurityStamp = "5GUYLKEWMP4GZZ5UXZNO2JAPY5IHQVP3",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            }
            );
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = normalUserRoleId,
                UserId = normalUser1Id
            }
            );
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = normalUserRoleId,
                UserId = normalUser2Id
            }
           );
        }

    
        public DbSet<Journal> Journal { get; set; }
       

    }
