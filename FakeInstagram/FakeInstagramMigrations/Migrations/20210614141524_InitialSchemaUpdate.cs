using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeInstagramMigrations.Migrations
{
    public partial class InitialSchemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTextAttributes_PostImage_ImageId",
                table: "PostTextAttributes");

            migrationBuilder.DropIndex(
                name: "IX_PostTextAttributes_ImageId",
                table: "PostTextAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostImage",
                table: "PostImage");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PostTextAttributes");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PostTextAttributes");

            migrationBuilder.RenameTable(
                name: "PostImage",
                newName: "PostImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostImages",
                table: "PostImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostImageAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImageAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImageAttributes_PostImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "PostImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostImageAttributes_PostTextAttributes_Id",
                        column: x => x.Id,
                        principalTable: "PostTextAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostImageAttributes_ImageId",
                table: "PostImageAttributes",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostImageAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostImages",
                table: "PostImages");

            migrationBuilder.RenameTable(
                name: "PostImages",
                newName: "PostImage");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PostTextAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "PostTextAttributes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostImage",
                table: "PostImage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostTextAttributes_ImageId",
                table: "PostTextAttributes",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTextAttributes_PostImage_ImageId",
                table: "PostTextAttributes",
                column: "ImageId",
                principalTable: "PostImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
