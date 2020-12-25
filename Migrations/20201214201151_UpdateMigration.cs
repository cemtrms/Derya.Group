using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteManagerPanel.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedBy",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ModifiedBy",
                table: "User");

            migrationBuilder.DropTable(
                name: "AdditionalFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_User_CreatedBy",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ModifiedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsArray",
                table: "AdditionalFields");

            migrationBuilder.DropColumn(
                name: "IsSearchable",
                table: "AdditionalFields");

            migrationBuilder.DropColumn(
                name: "ShowInGrid",
                table: "AdditionalFields");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "AdditionalFields");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AdditionalFields");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefinitionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_AdditionalFields_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "AdditionalFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldValue_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldValue_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldValue_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CreatedBy",
                table: "Fields",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_DefinitionId",
                table: "Fields",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ModifiedBy",
                table: "Fields",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_CreateUserId",
                table: "FieldValue",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValue",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_ModifyUserId",
                table: "FieldValue",
                column: "ModifyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldValue");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArray",
                table: "AdditionalFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSearchable",
                table: "AdditionalFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInGrid",
                table: "AdditionalFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Sort",
                table: "AdditionalFields",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AdditionalFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdditionalFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalFieldId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalFieldValues_AdditionalFields_AdditionalFieldId",
                        column: x => x.AdditionalFieldId,
                        principalTable: "AdditionalFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdditionalFieldValues_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdditionalFieldValues_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedBy",
                table: "User",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_ModifiedBy",
                table: "User",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldValues_AdditionalFieldId",
                table: "AdditionalFieldValues",
                column: "AdditionalFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldValues_CreatedBy",
                table: "AdditionalFieldValues",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldValues_ModifiedBy",
                table: "AdditionalFieldValues",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedBy",
                table: "User",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ModifiedBy",
                table: "User",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
