using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class EF1DEA5578194A96AD8E7432C7F131 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Missing",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "TransferContent",
                table: "Invoice",
                newName: "Content");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 13, 47, 44, 495, DateTimeKind.Local).AddTicks(6314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                scale: 0,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debt",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Invoice",
                newName: "TransferContent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 13, 47, 44, 495, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.AddColumn<decimal>(
                name: "Missing",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
