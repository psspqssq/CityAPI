using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedroutescount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoutesCount",
                table: "Cycles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutesCount",
                table: "Cycles");
        }
    }
}
