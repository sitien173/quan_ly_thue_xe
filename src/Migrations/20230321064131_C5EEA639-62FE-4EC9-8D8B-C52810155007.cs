using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class C5EEA63962FE4EC98D8BC52810155007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote");

            migrationBuilder.DropIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "TrackNote");

            migrationBuilder.DropColumn(
                name: "CarLogBookId",
                table: "TrackNote");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 13, 41, 31, 66, DateTimeKind.Local).AddTicks(4472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 13, 35, 44, 17, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote",
                columns: new[] { "CheckInOutCarId", "CarId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote");

            migrationBuilder.AddColumn<int>(
                name: "CarLogBookId",
                table: "TrackNote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 13, 35, 44, 17, DateTimeKind.Local).AddTicks(3796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 13, 41, 31, 66, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote",
                columns: new[] { "CarLogBookId", "CarId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "TrackNote",
                column: "CheckInOutCarId");
        }
    }
}
