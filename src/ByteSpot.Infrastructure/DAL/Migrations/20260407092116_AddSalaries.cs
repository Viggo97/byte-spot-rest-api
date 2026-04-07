using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteSpot.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixedSalary",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "Offers");

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmploymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Min = table.Column<int>(type: "integer", nullable: true),
                    Max = table.Column<int>(type: "integer", nullable: true),
                    Fixed = table.Column<int>(type: "integer", nullable: true),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salaries_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmploymentTypeId",
                table: "Salaries",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_OfferId",
                table: "Salaries",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.AddColumn<int>(
                name: "FixedSalary",
                table: "Offers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxSalary",
                table: "Offers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinSalary",
                table: "Offers",
                type: "integer",
                nullable: true);
        }
    }
}
