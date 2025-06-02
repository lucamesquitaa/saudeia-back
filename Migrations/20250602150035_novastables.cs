using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIA.Migrations
{
    /// <inheritdoc />
    public partial class novastables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContatosModel_Hotel_DetalhesModelId",
                table: "ContatosModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FotosDetalhesModel_Hotel_DetalhesModelId",
                table: "FotosDetalhesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotosDetalhesModel",
                table: "FotosDetalhesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContatosModel",
                table: "ContatosModel");

            migrationBuilder.RenameTable(
                name: "FotosDetalhesModel",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "ContatosModel",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_FotosDetalhesModel_DetalhesModelId",
                table: "Photos",
                newName: "IX_Photos_DetalhesModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ContatosModel_DetalhesModelId",
                table: "Contacts",
                newName: "IX_Contacts_DetalhesModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Hotel_DetalhesModelId",
                table: "Contacts",
                column: "DetalhesModelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Hotel_DetalhesModelId",
                table: "Photos",
                column: "DetalhesModelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Hotel_DetalhesModelId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Hotel_DetalhesModelId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "FotosDetalhesModel");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "ContatosModel");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_DetalhesModelId",
                table: "FotosDetalhesModel",
                newName: "IX_FotosDetalhesModel_DetalhesModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_DetalhesModelId",
                table: "ContatosModel",
                newName: "IX_ContatosModel_DetalhesModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotosDetalhesModel",
                table: "FotosDetalhesModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContatosModel",
                table: "ContatosModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContatosModel_Hotel_DetalhesModelId",
                table: "ContatosModel",
                column: "DetalhesModelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FotosDetalhesModel_Hotel_DetalhesModelId",
                table: "FotosDetalhesModel",
                column: "DetalhesModelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
