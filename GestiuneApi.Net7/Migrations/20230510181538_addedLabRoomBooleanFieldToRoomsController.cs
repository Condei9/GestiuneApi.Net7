using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneSaliNET7.Migrations
{
    /// <inheritdoc />
    public partial class addedLabRoomBooleanFieldToRoomsController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "labRoom",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "labRoom",
                table: "Rooms");
        }
    }
}
