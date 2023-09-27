using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class DC1C2A6F76454CA997F91C006C4AA39D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debt",
                table: "Contract");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 3, 15, 0, 810, DateTimeKind.Local).AddTicks(3250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 27, 0, 2, 7, 854, DateTimeKind.Local).AddTicks(1405));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 0, 2, 7, 854, DateTimeKind.Local).AddTicks(1405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 27, 3, 15, 0, 810, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "Contract",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
