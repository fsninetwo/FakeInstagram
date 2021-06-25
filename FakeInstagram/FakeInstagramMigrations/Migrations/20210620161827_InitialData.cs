using FakeInstagramEfModels.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeInstagramMigrations.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new FakeInstagramContextFactory();
            var context = dbContextFactory.CreateDbContext(null);
            var roles = new List<UserRole>
            {
                new UserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "User"
                },
                new UserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator"
                }
            };

            context.AddRange(roles);
            context.SaveChanges();

            var user = new User
            {
                Email = "admin@admin.com",
                Password = "12345678",
                UserRole = context.UserRoles.FirstOrDefault(role => role.Name.Equals("Administrator"))
            };

            context.Add(user);
            context.SaveChanges();
            var posttext1 = new PostTextAttribute { Text = "Simple Post" };
            var post1 = new Post
            {
                Header = "First Post",
                User = user,
                PostAttribute = posttext1
            };
            context.Add(post1);
            context.SaveChanges();

            var posttext2 = new PostTextAttribute { Text = "Complex Post" };
            var post2 = new Post
            {
                Header = "Second Post",
                User = user,
                PostAttribute = posttext2
            };
            context.Add(post2);
            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
