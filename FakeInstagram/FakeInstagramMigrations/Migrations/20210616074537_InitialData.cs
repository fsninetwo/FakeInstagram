﻿using FakeInstagramEfModels.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace FakeInstagramMigrations.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new FakeInstagramContextFactory();
            var context = dbContextFactory.CreateDbContext(null);
            var user = new User
            {
                Login = "fsninetwo",
                Password = "12345678"
            };

            context.Add(user);
            context.SaveChanges();
            var posttext1 = new PostTextAttribute { Text = "Simple Post" };
            var post1 = new Post
            {
                Header = "First Post",
                User = user,
                PostAttributes = new List<PostAttribute> { posttext1 }
            };
            context.Add(post1);
            context.SaveChanges();

            var posttext2 = new PostTextAttribute { Text = "Complex Post" };
            var post2 = new Post
            {
                Header = "Second Post",
                User = user,
                PostAttributes = new List<PostAttribute> { posttext2 }
            };
            context.Add(post2);
            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
