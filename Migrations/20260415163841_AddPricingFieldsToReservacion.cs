using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSysRD.Migrations
{
    /// <inheritdoc />
    public partial class AddPricingFieldsToReservacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadNoches",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioPorNoche",
                table: "Reservaciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAPagar",
                table: "Reservaciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadNoches",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "PrecioPorNoche",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "TotalAPagar",
                table: "Reservaciones");
        }
    }
}
