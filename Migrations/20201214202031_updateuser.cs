using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteManagerPanel.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "User",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OperationClaim",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OperationClaim");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "User",
                newName: "Status");
        }
    }
}
