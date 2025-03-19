using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class AppUserEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Aucts",
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
                name: "Fertilizer",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Grain",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdditionalGameAvailable",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGameAvailable",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferalLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Tugrics",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Waxws",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aucts",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Eggs",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fertilizer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Grain",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAdditionalGameAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsGameAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReferalLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tugrics",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Waxws",
                table: "AspNetUsers");
        }
    }
}
