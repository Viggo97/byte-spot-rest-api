using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteSpot.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ExtendOfferByComputedSalariesAndExpiresAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Salaries");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Salaries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpiresAt",
                table: "Offers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "SalaryMaxComputed",
                table: "Offers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaryMinComputed",
                table: "Offers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "SalaryMaxComputed",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "SalaryMinComputed",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Salaries",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
