using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneSaliNET7.Migrations
{
    /// <inheritdoc />
    public partial class removedSeriesTabelFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serii");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anStudiu = table.Column<int>(type: "int", nullable: false),
                    nrStudenti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serii", x => x.Id);
                });
        }
    }
}
