using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIA.Migrations
{
    /// <inheritdoc />
    public partial class body1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Body");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Body",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "IMC",
                table: "Body",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Body");

            migrationBuilder.DropColumn(
                name: "IMC",
                table: "Body");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Body",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
