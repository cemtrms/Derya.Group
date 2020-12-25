using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteManagerPanel.Migrations
{
    public partial class AddItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "FieldValue");

            migrationBuilder.CreateTable(
                name: "FieldItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldValueId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldItem_FieldValue_FieldValueId",
                        column: x => x.FieldValueId,
                        principalTable: "FieldValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldItem_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FieldItem_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldItem_CreateUserId",
                table: "FieldItem",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldItem_FieldValueId",
                table: "FieldItem",
                column: "FieldValueId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldItem_ModifyUserId",
                table: "FieldItem",
                column: "ModifyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldItem");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FieldValue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
