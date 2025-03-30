using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class FieldsEvent_DescriptionProperty_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FieldEvents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "FieldEvents",
                columns: new[] { "Id", "Description", "Name", "SowGrainCostModifier", "SowWaterCostModifier", "YieldModifier" },
                values: new object[] { 1L, "None", "None", 1.0, 1.0, 1.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FieldEvents",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<double>(
                name: "Description",
                table: "FieldEvents",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
