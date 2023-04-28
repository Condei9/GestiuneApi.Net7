using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneSaliNET7.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Room",
                table: "Requests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Groups",
                table: "Requests",
                newName: "Cerere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Requests",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "Cerere",
                table: "Requests",
                newName: "Groups");
        }
    }
}
