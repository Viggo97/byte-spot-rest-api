using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteSpot.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkModeTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WorkModes",
                newName: "Value");

            migrationBuilder.CreateTable(
                name: "WorkModeTranslations",
                columns: table => new
                {
                    WorkModeId = table.Column<int>(type: "integer", nullable: false),
                    LanguageCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkModeTranslations", x => new { x.WorkModeId, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_WorkModeTranslations_WorkModes_WorkModeId",
                        column: x => x.WorkModeId,
                        principalTable: "WorkModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkModeTranslations");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "WorkModes",
                newName: "Name");
        }
    }
}
