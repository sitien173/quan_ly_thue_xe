using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class C5EEA63962FE4EC98D8BC52810155006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackNote_CarLogbook_CarLogBookId",
                table: "TrackNote");

            migrationBuilder.RenameColumn(
                name: "LogbookTypeEnum",
                table: "CarLogbook",
                newName: "CheckInOutCarTypeEnum");

            migrationBuilder.AddColumn<int>(
                name: "CheckInOutCarId",
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
                oldDefaultValue: new DateTime(2023, 3, 21, 12, 8, 31, 864, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.CreateIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "TrackNote",
                column: "CheckInOutCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackNote_CarLogbook_CheckInOutCarId",
                table: "TrackNote",
                column: "CheckInOutCarId",
                principalTable: "CarLogbook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackNote_CarLogbook_CheckInOutCarId",
                table: "TrackNote");

            migrationBuilder.DropIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "TrackNote");

            migrationBuilder.DropColumn(
                name: "CheckInOutCarId",
                table: "TrackNote");

            migrationBuilder.RenameColumn(
                name: "CheckInOutCarTypeEnum",
                table: "CarLogbook",
                newName: "LogbookTypeEnum");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 12, 8, 31, 864, DateTimeKind.Local).AddTicks(617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 13, 35, 44, 17, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.AddForeignKey(
                name: "FK_TrackNote_CarLogbook_CarLogBookId",
                table: "TrackNote",
                column: "CarLogBookId",
                principalTable: "CarLogbook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
