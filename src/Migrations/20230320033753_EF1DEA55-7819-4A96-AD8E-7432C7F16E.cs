using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class EF1DEA5578194A96AD8E7432C7F16E : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail");

            migrationBuilder.DropIndex(
                name: "IX_ContractDetail_ContractId",
                table: "ContractDetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContractDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 9, 45, 53, 601, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail",
                columns: new[] { "ContractId", "CarId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 9, 45, 53, 601, DateTimeKind.Local).AddTicks(5381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContractDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail",
                columns: new[] { "Id", "CarId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractDetail_ContractId",
                table: "ContractDetail",
                column: "ContractId");
        }
    }
}
