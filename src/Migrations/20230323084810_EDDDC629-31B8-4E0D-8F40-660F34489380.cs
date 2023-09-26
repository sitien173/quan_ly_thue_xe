using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class EDDDC62931B84E0D8F40660F34489380 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerifyProcessRent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 23, 15, 48, 10, 633, DateTimeKind.Local).AddTicks(5784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 23, 12, 56, 6, 543, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CheckInOutCar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CheckInOutCar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 23, 12, 56, 6, 543, DateTimeKind.Local).AddTicks(143),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 23, 15, 48, 10, 633, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.CreateTable(
                name: "VerifyProcessRent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInOutCarId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifyImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifyImageThumb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyProcessRent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerifyProcessRent_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VerifyProcessRent_CheckInOutCar_CheckInOutCarId",
                        column: x => x.CheckInOutCarId,
                        principalTable: "CheckInOutCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerifyProcessRent_CarId",
                table: "VerifyProcessRent",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifyProcessRent_CheckInOutCarId",
                table: "VerifyProcessRent",
                column: "CheckInOutCarId");
        }
    }
}
