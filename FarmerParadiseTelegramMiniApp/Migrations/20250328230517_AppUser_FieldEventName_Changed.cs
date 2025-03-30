using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class AppUser_FieldEventName_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FieldEvents_FieldsEventId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FieldsEventId",
                table: "AspNetUsers",
                newName: "FieldEventId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_FieldsEventId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_FieldEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FieldEvents_FieldEventId",
                table: "AspNetUsers",
                column: "FieldEventId",
                principalTable: "FieldEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FieldEvents_FieldEventId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FieldEventId",
                table: "AspNetUsers",
                newName: "FieldsEventId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_FieldEventId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_FieldsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FieldEvents_FieldsEventId",
                table: "AspNetUsers",
                column: "FieldsEventId",
                principalTable: "FieldEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
