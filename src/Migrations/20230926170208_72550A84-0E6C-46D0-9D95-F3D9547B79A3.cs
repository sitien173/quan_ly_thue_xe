using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class _72550A840E6C46D09D95F3D9547B79A3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "Debt",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PayMethodEnum",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PayOff",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Prepay",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "TotalCarRental",
                table: "Invoice",
                newName: "Vat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 0, 2, 7, 854, DateTimeKind.Local).AddTicks(1405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 26, 22, 20, 9, 616, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Money",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceWithVat",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                scale: 0,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Invoice",
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
                name: "Money",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "TotalPriceWithVat",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Vat",
                table: "Invoice",
                newName: "TotalCarRental");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 26, 22, 20, 9, 616, DateTimeKind.Local).AddTicks(2726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 27, 0, 2, 7, 854, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PayMethodEnum",
                table: "Invoice",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PayOff",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Prepay",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Invoice",
                type: "decimal(12,0)",
                precision: 12,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,0)", precision: 12, nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalMethod = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(12,0)", precision: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_CarId",
                table: "InvoiceDetail",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");
        }
    }
}
