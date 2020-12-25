using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteManagerPanel.Migrations
{
    public partial class updatedefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFields_Sites_SiteId",
                table: "AdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFields_User_CreatedBy",
                table: "AdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFields_User_ModifiedBy",
                table: "AdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_AdditionalFields_DefinitionId",
                table: "Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalFields",
                table: "AdditionalFields");

            migrationBuilder.RenameTable(
                name: "AdditionalFields",
                newName: "Definitions");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalFields_SiteId",
                table: "Definitions",
                newName: "IX_Definitions_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalFields_ModifiedBy",
                table: "Definitions",
                newName: "IX_Definitions_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalFields_CreatedBy",
                table: "Definitions",
                newName: "IX_Definitions_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Definitions",
                table: "Definitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Definitions_Sites_SiteId",
                table: "Definitions",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Definitions_User_CreatedBy",
                table: "Definitions",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Definitions_User_ModifiedBy",
                table: "Definitions",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Definitions_DefinitionId",
                table: "Fields",
                column: "DefinitionId",
                principalTable: "Definitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Definitions_Sites_SiteId",
                table: "Definitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Definitions_User_CreatedBy",
                table: "Definitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Definitions_User_ModifiedBy",
                table: "Definitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Definitions_DefinitionId",
                table: "Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Definitions",
                table: "Definitions");

            migrationBuilder.RenameTable(
                name: "Definitions",
                newName: "AdditionalFields");

            migrationBuilder.RenameIndex(
                name: "IX_Definitions_SiteId",
                table: "AdditionalFields",
                newName: "IX_AdditionalFields_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Definitions_ModifiedBy",
                table: "AdditionalFields",
                newName: "IX_AdditionalFields_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Definitions_CreatedBy",
                table: "AdditionalFields",
                newName: "IX_AdditionalFields_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalFields",
                table: "AdditionalFields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFields_Sites_SiteId",
                table: "AdditionalFields",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFields_User_CreatedBy",
                table: "AdditionalFields",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFields_User_ModifiedBy",
                table: "AdditionalFields",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_AdditionalFields_DefinitionId",
                table: "Fields",
                column: "DefinitionId",
                principalTable: "AdditionalFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
