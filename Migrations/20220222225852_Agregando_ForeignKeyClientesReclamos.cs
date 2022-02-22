using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Agregando_ForeignKeyClientesReclamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Reclamos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_ClienteId",
                table: "Reclamos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Clientes_ClienteId",
                table: "Reclamos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Clientes_ClienteId",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_ClienteId",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Reclamos");
        }
    }
}
