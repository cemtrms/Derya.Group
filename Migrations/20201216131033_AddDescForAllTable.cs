using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteManagerPanel.Migrations
{
    public partial class AddDescForAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sites",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fields",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Definitions",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fields");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Definitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000);
        }
    }
}
