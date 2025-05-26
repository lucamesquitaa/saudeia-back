using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIA.Migrations
{
    /// <inheritdoc />
    public partial class getall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cleaning",
                table: "Hotel",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Coffee",
                table: "Hotel",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gym",
                table: "Hotel",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Swimming",
                table: "Hotel",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Wifi",
                table: "Hotel",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cleaning",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Coffee",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Gym",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Swimming",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "Hotel");
        }
    }
}
