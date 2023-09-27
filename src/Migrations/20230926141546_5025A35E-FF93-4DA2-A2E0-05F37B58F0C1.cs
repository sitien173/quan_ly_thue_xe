using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class _5025A35EFF934DA2A2E005F37B58F0C1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCarRent",
                table: "Contract");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 21, 15, 45, 809, DateTimeKind.Local).AddTicks(909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 17, 20, 7, 278, DateTimeKind.Local).AddTicks(6013));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 17, 20, 7, 278, DateTimeKind.Local).AddTicks(6013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 21, 15, 45, 809, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.AddColumn<int>(
                name: "TotalCarRent",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
