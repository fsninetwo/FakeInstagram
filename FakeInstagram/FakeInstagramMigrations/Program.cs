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
        }
    }
}
