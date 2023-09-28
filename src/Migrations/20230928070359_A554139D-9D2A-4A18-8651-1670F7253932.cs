using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class A554139D9D2A4A1886511670F7253932 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTerminationMinutes",
                table: "Contract");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 14, 3, 58, 984, DateTimeKind.Local).AddTicks(5501),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 12, 56, 35, 717, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.AddColumn<short>(
                name: "Status",
                table: "Contract",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contract");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 12, 56, 35, 717, DateTimeKind.Local).AddTicks(320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 14, 3, 58, 984, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.AddColumn<bool>(
                name: "IsTerminationMinutes",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
