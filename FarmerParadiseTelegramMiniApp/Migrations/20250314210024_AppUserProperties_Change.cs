using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class AppUserProperties_Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chickens",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Eggs",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EggsInIncubator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Tugrics",
                table: "AspNetUsers",
                newName: "Water");

            migrationBuilder.RenameColumn(
                name: "Fertilizer",
                table: "AspNetUsers",
                newName: "RareGrain");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Water",
                table: "AspNetUsers",
                newName: "Tugrics");

            migrationBuilder.RenameColumn(
                name: "RareGrain",
                table: "AspNetUsers",
                newName: "Fertilizer");

            migrationBuilder.AddColumn<long>(
                name: "Chickens",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Eggs",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EggsInIncubator",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
