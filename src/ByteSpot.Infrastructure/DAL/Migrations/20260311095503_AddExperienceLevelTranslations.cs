using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteSpot.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddExperienceLevelTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ExperienceLevels",
                newName: "Value");

            migrationBuilder.CreateTable(
                name: "ExperienceLevelTranslations",
                columns: table => new
                {
                    ExperienceLevelId = table.Column<int>(type: "integer", nullable: false),
                    LanguageCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevelTranslations", x => new { x.ExperienceLevelId, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_ExperienceLevelTranslations_ExperienceLevels_ExperienceLeve~",
                        column: x => x.ExperienceLevelId,
                        principalTable: "ExperienceLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceLevelTranslations");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ExperienceLevels",
                newName: "Name");
        }
    }
}
