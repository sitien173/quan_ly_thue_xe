using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class C5EEA63962FE4EC98D8BC52810155012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TrackNote");

            migrationBuilder.RenameColumn(
                name: "CheckInOutCarTypeEnum",
                table: "CarLogbook",
                newName: "CheckInOutEnum");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 16, 16, 44, 471, DateTimeKind.Local).AddTicks(8887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 13, 58, 53, 231, DateTimeKind.Local).AddTicks(534));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckInOutEnum",
                table: "CarLogbook",
                newName: "CheckInOutCarTypeEnum");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TrackNote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 13, 58, 53, 231, DateTimeKind.Local).AddTicks(534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 16, 16, 44, 471, DateTimeKind.Local).AddTicks(8887));
        }
    }
}
