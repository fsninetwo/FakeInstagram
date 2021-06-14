using FakeInstagramEfModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using PostAttribute = FakeInstagramEfModels.Entities.PostAttribute;

namespace FakeInstagramEfModels
{
    public class FakeInstagramContext : DbContext
    {
        //All avaliable dbsets for EfCore
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        //public DbSet<PostStatus> PostStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Main database connection
            //var connectionString = @"Server=(local)\mssqllocaldb;Database=FakeInstagram;Integrated Security=True";
            var connectionString = @"Server=WIN-6280MA0A0E4\SQLEXPRESS;Database=FakeInstagram;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Code-First methods for creating and updating models
            modelBuilder.Entity<PostImageAttribute>().ToTable("PostImageAttributes");
            modelBuilder.Entity<PostTextAttribute>().ToTable("PostTextAttributes");
        }
    }
}
