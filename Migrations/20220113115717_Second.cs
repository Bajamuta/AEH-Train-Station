using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainStation.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Journey_DayID",
                table: "Journey");

            migrationBuilder.DropColumn(
                name: "DayID",
                table: "Journey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayID",
                table: "Journey",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Journey_DayID",
                table: "Journey",
                column: "DayID");
        }
    }
}
