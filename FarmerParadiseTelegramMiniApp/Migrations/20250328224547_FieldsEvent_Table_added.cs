using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class FieldsEvent_Table_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FieldsEventId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "FieldEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YieldModifier = table.Column<double>(type: "float", nullable: false),
                    SowGrainCostModifier = table.Column<double>(type: "float", nullable: false),
                    SowWaterCostModifier = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldEvents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FieldsEventId",
                table: "AspNetUsers",
                column: "FieldsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FieldEvents_FieldsEventId",
                table: "AspNetUsers",
                column: "FieldsEventId",
                principalTable: "FieldEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FieldEvents_FieldsEventId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FieldEvents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FieldsEventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FieldsEventId",
                table: "AspNetUsers");
        }
    }
}
