﻿// <auto-generated />
using System;
using FakeInstagramMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeInstagramMigrations.Migrations
{
    [DbContext(typeof(FakeInstagramContext))]
    partial class FakeInstagramContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PostAttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");
                    b.HasIndex("PostAttributeId");

                    b.HasIndex("PostAttributeId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.PostAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("PostAttributes");
                });
                
            modelBuilder.Entity("FakeInstagramEfModels.Entities.PostImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Uploaded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PostImages");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Sol")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.PostTextAttribute", b =>
                {
                    b.HasBaseType("FakeInstagramEfModels.Entities.PostAttribute");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("PostTextAttributes");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.PostImageAttribute", b =>
                {
                    b.HasBaseType("FakeInstagramEfModels.Entities.PostTextAttribute");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ImageId");

                    b.ToTable("PostImageAttributes");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Like", b =>
                {
                    b.HasOne("FakeInstagramEfModels.Entities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Post", b =>
                {
                    b.HasOne("FakeInstagramEfModels.Entities.PostAttribute", "PostAttribute")
                        .WithMany()
                        .HasForeignKey("PostAttributeId");

                    b.HasOne("FakeInstagramEfModels.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostAttribute");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Tag", b =>
                {
                    b.HasOne("FakeInstagramEfModels.Entities.Post", null)
                        .WithMany("Tags")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.User", b =>
                {
                    b.HasOne("FakeInstagramEfModels.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.PostTextAttribute", b =>
                {
                    b.HasOne("FakeInstagramEfModels.Entities.PostAttribute", null)
                        .WithOne()
                        .HasForeignKey("FakeInstagramEfModels.Entities.PostTextAttribute", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.PostImageAttribute", b =>
                {
                    b.HasOne("FakeInstagramEfModels.Entities.PostTextAttribute", null)
                        .WithOne()
                        .HasForeignKey("FakeInstagramEfModels.Entities.PostImageAttribute", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("FakeInstagramEfModels.Entities.PostImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.Post", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("FakeInstagramEfModels.Entities.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
