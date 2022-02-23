using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Corrigiendo_CampoDeLaTablaReclamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificaion",
                table: "Reclamos",
                newName: "Identificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Reclamos",
                newName: "Identificaion");
        }
    }
}
