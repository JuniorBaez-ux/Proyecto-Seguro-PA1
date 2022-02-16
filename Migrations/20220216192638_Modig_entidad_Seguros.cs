using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Modig_entidad_Seguros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anio",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Seguros");
        }
    }
}
