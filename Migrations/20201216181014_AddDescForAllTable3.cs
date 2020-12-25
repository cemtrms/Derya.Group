using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteManagerPanel.Migrations
{
    public partial class AddDescForAllTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Definitions_DefinitionId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_Fields_FieldId",
                table: "FieldValue");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "FieldValue",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Fields",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<int>(
                name: "DefinitionId",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Definitions",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Definitions_DefinitionId",
                table: "Fields",
                column: "DefinitionId",
                principalTable: "Definitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_Fields_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Definitions_DefinitionId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_Fields_FieldId",
                table: "FieldValue");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "FieldValue",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Fields",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefinitionId",
                table: "Fields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Definitions",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Definitions_DefinitionId",
                table: "Fields",
                column: "DefinitionId",
                principalTable: "Definitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_Fields_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
