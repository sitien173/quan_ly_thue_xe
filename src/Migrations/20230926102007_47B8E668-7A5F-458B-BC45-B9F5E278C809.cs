using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class _47B8E6687A5F458BBC45B9F5E278C809 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Customer_CustomerId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_CustomerId",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Contract",
                newName: "RentRequestId");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "RentRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 17, 20, 7, 278, DateTimeKind.Local).AddTicks(6013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 16, 25, 51, 648, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.CreateIndex(
                name: "IX_Contract_RentRequestId",
                table: "Contract",
                column: "RentRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_RentRequest_RentRequestId",
                table: "Contract",
                column: "RentRequestId",
                principalTable: "RentRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_RentRequest_RentRequestId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_RentRequestId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "RentRequest");

            migrationBuilder.RenameColumn(
                name: "RentRequestId",
                table: "Contract",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 16, 25, 51, 648, DateTimeKind.Local).AddTicks(6291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 17, 20, 7, 278, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CustomerId",
                table: "Contract",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Customer_CustomerId",
                table: "Contract",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
