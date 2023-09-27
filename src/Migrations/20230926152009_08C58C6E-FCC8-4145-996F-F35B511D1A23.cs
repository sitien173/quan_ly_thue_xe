using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class _08C58C6EFCC84145996FF35B511D1A23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Damages");

            migrationBuilder.DropColumn(
                name: "RepairCost",
                table: "Damages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 22, 20, 9, 616, DateTimeKind.Local).AddTicks(2726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 21, 15, 45, 809, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DamagedAt",
                table: "Damages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Damages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRepairCost",
                table: "Damages",
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
                name: "Content",
                table: "Damages");

            migrationBuilder.DropColumn(
                name: "TotalRepairCost",
                table: "Damages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 21, 15, 45, 809, DateTimeKind.Local).AddTicks(909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 22, 20, 9, 616, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DamagedAt",
                table: "Damages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Damages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RepairCost",
                table: "Damages",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
