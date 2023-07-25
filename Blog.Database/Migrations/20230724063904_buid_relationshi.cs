using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Database.Migrations
{
    /// <inheritdoc />
    public partial class buid_relationshi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BlogPost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_UserId",
                table: "BlogPost",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_User_UserId",
                table: "BlogPost",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_User_UserId",
                table: "BlogPost");

            migrationBuilder.DropIndex(
                name: "IX_BlogPost_UserId",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogPost");
        }
    }
}
