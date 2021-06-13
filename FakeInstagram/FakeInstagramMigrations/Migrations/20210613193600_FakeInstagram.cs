using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeInstagramMigrations.Migrations
{
    public partial class FakeInstagram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribute_Posts_PostId",
                table: "Attribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute");

            migrationBuilder.RenameTable(
                name: "Attribute",
                newName: "Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_Attribute_PostId",
                table: "Attributes",
                newName: "IX_Attributes_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Posts_PostId",
                table: "Attributes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Posts_PostId",
                table: "Attributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.RenameTable(
                name: "Attributes",
                newName: "Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_PostId",
                table: "Attribute",
                newName: "IX_Attribute_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribute_Posts_PostId",
                table: "Attribute",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
