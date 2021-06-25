using FakeInstagramEfModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace FakeInstagramMigrations
{
    public class FakeInstagramContext : DbContext
    {
        public FakeInstagramContext(DbContextOptions<FakeInstagramContext> options) : base(options)
        {

        }

        //All avaliable dbsets for EfCore
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostTextAttribute> PostTextAttributes { get; set; }
        public DbSet<PostImageAttribute> PostImageAttributes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
