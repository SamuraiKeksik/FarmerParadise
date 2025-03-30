using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerParadiseTelegramMiniApp.Migrations
{
    /// <inheritdoc />
    public partial class AppUser_SownFieldsDateTimeProperty_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SownFieldsDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FieldEvents",
                keyColumn: "Id",
                keyValue: 2L,
                column: "YieldModifier",
                value: 0.80000000000000004);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SownFieldsDateTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "FieldEvents",
                keyColumn: "Id",
                keyValue: 2L,
                column: "YieldModifier",
                value: 0.90000000000000002);
        }
    }
}
