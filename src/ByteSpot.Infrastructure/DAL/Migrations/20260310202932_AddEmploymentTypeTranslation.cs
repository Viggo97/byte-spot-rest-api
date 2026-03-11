using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteSpot.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEmploymentTypeTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EmploymentTypes",
                newName: "Value");

            migrationBuilder.CreateTable(
                name: "EmploymentTypeTranslations",
                columns: table => new
                {
                    EmploymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    LanguageCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypeTranslations", x => new { x.EmploymentTypeId, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_EmploymentTypeTranslations_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentTypeTranslations");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "EmploymentTypes",
                newName: "Name");
        }
    }
}
