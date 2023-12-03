using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityAPI.Migrations
{
    /// <inheritdoc />
    public partial class databaseupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Cycles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CityRoute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityRoute_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityRoute_CycleId",
                table: "CityRoute",
                column: "CycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityRoute");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Cycles");
        }
    }
}
