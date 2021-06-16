using FakeInstagramMigrations.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramMigrations
{
    public class FakeInstagramContextFactory : IDesignTimeDbContextFactory<FakeInstagramContext>
    {
        public FakeInstagramContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Console.WriteLine($"environmentName={environmentName}");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true);

            IConfigurationRoot configuration = builder.Build();

            var settings = new AppSettings();
            configuration.Bind(settings);

            var optionsBuilder = new DbContextOptionsBuilder<FakeInstagramContext>();
            optionsBuilder.UseSqlServer(
                settings.ConnectionString,
                b => b.MigrationsAssembly(typeof(FakeInstagramContextFactory).Assembly.FullName)
            );

            return new FakeInstagramContext(optionsBuilder.Options);
        }
    }
}
