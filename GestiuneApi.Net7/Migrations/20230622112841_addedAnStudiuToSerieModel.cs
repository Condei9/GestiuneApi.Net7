using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneSaliNET7.Migrations
{
    /// <inheritdoc />
    public partial class addedAnStudiuToSerieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "anStudiu",
                table: "Serii",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anStudiu",
                table: "Serii");
        }
    }
}
