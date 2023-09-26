using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class C5EEA63962FE4EC98D8BC52810155009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote");

            migrationBuilder.RenameColumn(
                name: "ResultEnum",
                table: "TrackNote",
                newName: "VerifyProcessRentEnum");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TrackNote",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "VerifyImage",
                table: "TrackNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerifyImageThumb",
                table: "TrackNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 13, 58, 53, 231, DateTimeKind.Local).AddTicks(534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 13, 41, 31, 66, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CarLogbook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "TrackNote",
                column: "CheckInOutCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLogbook_CustomerId",
                table: "CarLogbook",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarLogbook_Customer_CustomerId",
                table: "CarLogbook",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarLogbook_Customer_CustomerId",
                table: "CarLogbook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote");

            migrationBuilder.DropIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "TrackNote");

            migrationBuilder.DropIndex(
                name: "IX_CarLogbook_CustomerId",
                table: "CarLogbook");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TrackNote");

            migrationBuilder.DropColumn(
                name: "VerifyImage",
                table: "TrackNote");

            migrationBuilder.DropColumn(
                name: "VerifyImageThumb",
                table: "TrackNote");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CarLogbook");

            migrationBuilder.RenameColumn(
                name: "VerifyProcessRentEnum",
                table: "TrackNote",
                newName: "ResultEnum");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 13, 41, 31, 66, DateTimeKind.Local).AddTicks(4472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 13, 58, 53, 231, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote",
                columns: new[] { "CheckInOutCarId", "CarId" });
        }
    }
}
