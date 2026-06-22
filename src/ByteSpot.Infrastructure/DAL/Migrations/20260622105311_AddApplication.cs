using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteSpot.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateFirstName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    CandidateLastName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CandidateEmail = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateEmail",
                table: "Applications",
                column: "CandidateEmail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
