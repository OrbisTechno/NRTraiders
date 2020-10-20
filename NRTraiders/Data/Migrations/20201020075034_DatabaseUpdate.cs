using Microsoft.EntityFrameworkCore.Migrations;

namespace NRTraiders.Data.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AppUser");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "AppUser",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "AppUser");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
