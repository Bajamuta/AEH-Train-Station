using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainStation.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationPlaceID",
                table: "Journey",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Journey_DestinationPlaceID",
                table: "Journey",
                column: "DestinationPlaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Journey_Place_DestinationPlaceID",
                table: "Journey",
                column: "DestinationPlaceID",
                principalTable: "Place",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journey_Place_DestinationPlaceID",
                table: "Journey");

            migrationBuilder.DropIndex(
                name: "IX_Journey_DestinationPlaceID",
                table: "Journey");

            migrationBuilder.DropColumn(
                name: "DestinationPlaceID",
                table: "Journey");
        }
    }
}
