using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class _6354A7D014EE41FA9FEA43A22339C7BD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 10, 7, 19, 903, DateTimeKind.Local).AddTicks(6484),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 13, 47, 44, 495, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContractDetail",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDetail_ContractId",
                table: "ContractDetail",
                column: "ContractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 3, 20, 13, 47, 44, 495, DateTimeKind.Local).AddTicks(6314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 21, 10, 7, 19, 903, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractDetail",
                table: "ContractDetail",
                columns: new[] { "ContractId", "CarId" });
        }
    }
}
