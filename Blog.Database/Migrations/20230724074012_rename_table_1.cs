using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Database.Migrations
{
    /// <inheritdoc />
    public partial class rename_table_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Users_UsersId",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogPost");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "BlogPost",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Users_UsersId",
                table: "BlogPost",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Users_UsersId",
                table: "BlogPost");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "BlogPost",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BlogPost",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Users_UsersId",
                table: "BlogPost",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
