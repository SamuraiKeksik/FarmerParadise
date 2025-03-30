using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class FieldsEvent_IsGoodEventProperty_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGoodEvent",
                table: "FieldEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FieldEvents",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsGoodEvent",
                value: true);

            migrationBuilder.InsertData(
                table: "FieldEvents",
                columns: new[] { "Id", "Description", "IsGoodEvent", "Name", "SowGrainCostModifier", "SowWaterCostModifier", "YieldModifier" },
                values: new object[] { 2L, "Засуха - описание", false, "Засуха", 1.0, 2.0, 0.90000000000000002 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FieldEvents",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "IsGoodEvent",
                table: "FieldEvents");
        }
    }
}
