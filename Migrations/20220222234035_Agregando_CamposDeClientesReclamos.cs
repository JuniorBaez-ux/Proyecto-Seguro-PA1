using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Agregando_CamposDeClientesReclamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificaion",
                table: "Reclamos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Reclamos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Reclamos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificaion",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Reclamos");
        }
    }
}
