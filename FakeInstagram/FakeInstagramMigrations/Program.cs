using FakeInstagramEfModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramMigrations
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dbContextFactory = new FakeInstagramContextFactory();
            var context = dbContextFactory.CreateDbContext(args);
            Console.WriteLine("Migrating Database");
            context.Database.Migrate();
            Console.WriteLine("Migration Completed");
            Console.WriteLine("Adding Data to Database");
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
            Console.WriteLine("Database data updated");
        }
    }
}
