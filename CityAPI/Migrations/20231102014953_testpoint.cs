using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityAPI.Migrations
{
    /// <inheritdoc />
    public partial class testpoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "approximateTravelTime",
                table: "CityRoute",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "XYCoordinate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    CityRouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XYCoordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XYCoordinate_CityRoute_CityRouteId",
                        column: x => x.CityRouteId,
                        principalTable: "CityRoute",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_XYCoordinate_CityRouteId",
                table: "XYCoordinate",
                column: "CityRouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XYCoordinate");

            migrationBuilder.DropColumn(
                name: "approximateTravelTime",
                table: "CityRoute");
        }
    }
}
