using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Database.Migrations
{
    /// <inheritdoc />
    public partial class rename_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_User_UserId",
                table: "BlogPost");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_BlogPost_UserId",
                table: "BlogPost");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "BlogPost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_UsersId",
                table: "BlogPost",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Users_UsersId",
                table: "BlogPost",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Users_UsersId",
                table: "BlogPost");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BlogPost_UsersId",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "BlogPost");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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
    }
}
