using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class _56B1C5FA281D44B8B4F6438026C39AF1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accidents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 22, 37, 0, 518, DateTimeKind.Local).AddTicks(6080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 27, 3, 15, 0, 810, DateTimeKind.Local).AddTicks(3250));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 3, 15, 0, 810, DateTimeKind.Local).AddTicks(3250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 27, 22, 37, 0, 518, DateTimeKind.Local).AddTicks(6080));

            migrationBuilder.CreateTable(
                name: "Accidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    AccidentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accidents_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accidents_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_CarId",
                table: "Accidents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ContractId",
                table: "Accidents",
                column: "ContractId",
                unique: true);
        }
    }
}
