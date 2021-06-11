using FakeInstagramEfModels.Tables;
using Microsoft.EntityFrameworkCore;
using System;

namespace FakeInstagramEfModels
{
    public class FakeInstagramContext : DbContext
    {
        //All avaliable dbsets for EfCore
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Main database connection
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FakeInstagram;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Code-First methods for creating and updating models
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
