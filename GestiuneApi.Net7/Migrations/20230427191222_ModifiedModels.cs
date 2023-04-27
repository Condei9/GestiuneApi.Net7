using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneSaliNET7.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Reservations",
                newName: "IsOnParity");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Reservations",
                newName: "IsLab");

            migrationBuilder.AlterColumn<bool>(
                name: "Groups",
                table: "Reservations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Day",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Day");

            migrationBuilder.RenameColumn(
                name: "IsOnParity",
                table: "Reservations",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "IsLab",
                table: "Reservations",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Groups",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
