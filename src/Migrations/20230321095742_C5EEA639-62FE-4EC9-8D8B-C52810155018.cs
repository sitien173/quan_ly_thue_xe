using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class C5EEA63962FE4EC98D8BC52810155018 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInOutCar_Customer_CustomerId",
                table: "CheckInOutCar");

            migrationBuilder.DropForeignKey(
                name: "FK_VerifyProcessRent_Car_CarId",
                table: "VerifyProcessRent");

            migrationBuilder.DropForeignKey(
                name: "FK_VerifyProcessRent_CheckInOutCar_CheckInOutCarId",
                table: "VerifyProcessRent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VerifyProcessRent",
                table: "VerifyProcessRent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckInOutCar",
                table: "CheckInOutCar");

            migrationBuilder.RenameTable(
                name: "VerifyProcessRent",
                newName: "TrackNote");

            migrationBuilder.RenameTable(
                name: "CheckInOutCar",
                newName: "CarLogbook");

            migrationBuilder.RenameIndex(
                name: "IX_VerifyProcessRent_CheckInOutCarId",
                table: "TrackNote",
                newName: "IX_TrackNote_CheckInOutCarId");

            migrationBuilder.RenameIndex(
                name: "IX_VerifyProcessRent_CarId",
                table: "TrackNote",
                newName: "IX_TrackNote_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckInOutCar_CustomerId",
                table: "CarLogbook",
                newName: "IX_CarLogbook_CustomerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 16, 57, 42, 27, DateTimeKind.Local).AddTicks(1583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 16, 42, 1, 375, DateTimeKind.Local).AddTicks(2967));

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "TrackNote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "CarLogbook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarLogbook",
                table: "CarLogbook",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarLogbook_CarId",
                table: "CarLogbook",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarLogbook_Car_CarId",
                table: "CarLogbook",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarLogbook_Customer_CustomerId",
                table: "CarLogbook",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackNote_CarLogbook_CheckInOutCarId",
                table: "TrackNote",
                column: "CheckInOutCarId",
                principalTable: "CarLogbook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackNote_Car_CarId",
                table: "TrackNote",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarLogbook_Car_CarId",
                table: "CarLogbook");

            migrationBuilder.DropForeignKey(
                name: "FK_CarLogbook_Customer_CustomerId",
                table: "CarLogbook");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackNote_CarLogbook_CheckInOutCarId",
                table: "TrackNote");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackNote_Car_CarId",
                table: "TrackNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackNote",
                table: "TrackNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarLogbook",
                table: "CarLogbook");

            migrationBuilder.DropIndex(
                name: "IX_CarLogbook_CarId",
                table: "CarLogbook");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarLogbook");

            migrationBuilder.RenameTable(
                name: "TrackNote",
                newName: "VerifyProcessRent");

            migrationBuilder.RenameTable(
                name: "CarLogbook",
                newName: "CheckInOutCar");

            migrationBuilder.RenameIndex(
                name: "IX_TrackNote_CheckInOutCarId",
                table: "VerifyProcessRent",
                newName: "IX_VerifyProcessRent_CheckInOutCarId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackNote_CarId",
                table: "VerifyProcessRent",
                newName: "IX_VerifyProcessRent_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarLogbook_CustomerId",
                table: "CheckInOutCar",
                newName: "IX_CheckInOutCar_CustomerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 16, 42, 1, 375, DateTimeKind.Local).AddTicks(2967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 16, 57, 42, 27, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "VerifyProcessRent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VerifyProcessRent",
                table: "VerifyProcessRent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckInOutCar",
                table: "CheckInOutCar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInOutCar_Customer_CustomerId",
                table: "CheckInOutCar",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VerifyProcessRent_Car_CarId",
                table: "VerifyProcessRent",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VerifyProcessRent_CheckInOutCar_CheckInOutCarId",
                table: "VerifyProcessRent",
                column: "CheckInOutCarId",
                principalTable: "CheckInOutCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
