using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //seed an admin role
            string adminRoleId = "1";
            string adminRoleName = "Admin";
            //seed an admin user
            string adminUserId = "1";
            string adminUserName = "admin@products.com";
            string adminPassword = "test123";
            //declare a passwordhasher
            IPasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            //create a, admin user
            ApplicationUser admin = new ApplicationUser
            {
                Id = adminUserId,
                UserName = adminUserName,
                NormalizedUserName = adminUserName.ToUpper(),
                Email = adminUserName,
                NormalizedEmail = adminUserName,
                EmailConfirmed = true,
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                ConcurrencyStamp  = Guid.NewGuid().ToString(),
            };
            //set password hash
            admin.PasswordHash = hasher.HashPassword(admin, adminPassword);
            //set identity role
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole 
                    {
                        Id = adminRoleId,
                        Name = adminRoleName,
                        NormalizedName = adminRoleName.ToUpper(),
                    }
                );
            //set user
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            //set user role = admin (ids as string type generic)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                });

            //create a user
            ApplicationUser newUser = new ApplicationUser
            {
                Id = "2",
                UserName = "jimmy",
                NormalizedUserName = "JIMMY",
                Email = "jimi.hendrix@howest.be",
                NormalizedEmail = "JIMMY.HENDRIX@HOWEST.BE",
                EmailConfirmed = true,
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            newUser.PasswordHash = hasher.HashPassword(newUser, "test");
            //add user to usertable
            modelBuilder.Entity<ApplicationUser>().HasData(newUser);
            //add claimType
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = newUser.Id,
                ClaimType = "module",
                ClaimValue = "Pri"
            });

            modelBuilder.Entity<Category>().HasData
                (new Category[] {
                    new Category { Id = 1,Name = "Laptops" },
                    new Category { Id = 2,Name = "PC's" },
                    new Category { Id = 3,Name = "Phones" }
                });
            modelBuilder.Entity<Property>().HasData(
                new Property[] { 
                    new Property { Id = 1, Name = "Basic"},
                    new Property { Id = 2, Name = "Luxury"},
                    new Property { Id = 3, Name = "Student"},
                    new Property { Id = 4, Name = "Family"},
                    new Property { Id = 5, Name = "Office"}
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product[] { 
                    new Product { Id = 1,Name="Samsung L7",Price=456.23M,CategoryId=3},
                    new Product { Id = 2,Name="Redmi Note7",Price=325.13M,CategoryId=3},
                    new Product { Id = 3,Name="Dell Latitude",Price=1456.23M,CategoryId=1},
                    new Product { Id = 4,Name="Dell Desktop",Price=856.3M,CategoryId=2},
                    new Product { Id = 5,Name="IBook 7",Price=2456.00M,CategoryId=1},
                    new Product { Id = 6,Name="Iphone12",Price=958.23M,CategoryId=3},
                }
                );
            modelBuilder.Entity($"{nameof(Product)}{nameof(Property)}").HasData
                (
                    new [] { 
                        new {ProductsId=1,PropertiesId=1},
                        new {ProductsId=1,PropertiesId=2},
                        new {ProductsId=1,PropertiesId=3},
                        new {ProductsId=2,PropertiesId=1},
                        new {ProductsId=2,PropertiesId=2},
                        new {ProductsId=2,PropertiesId=3},
                        new {ProductsId=3,PropertiesId=1},
                        new {ProductsId=3,PropertiesId=3},
                        new {ProductsId=4,PropertiesId=1},
                        new {ProductsId=5,PropertiesId=1},
                        new {ProductsId=5,PropertiesId=3},
                        new {ProductsId=6,PropertiesId=1},
                        new {ProductsId=6,PropertiesId=2},
                    }
                );
        }
    }
}
