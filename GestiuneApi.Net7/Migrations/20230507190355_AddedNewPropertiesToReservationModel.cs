using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneSaliNET7.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertiesToReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Subgroup",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serie",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Subgroup",
                table: "Reservations");
        }
    }
}
