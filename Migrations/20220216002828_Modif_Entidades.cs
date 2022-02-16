using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Modif_Entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Vehiculos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsoId",
                table: "Vehiculos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usos",
                columns: table => new
                {
                    UsoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usos", x => x.UsoId);
                });

            migrationBuilder.InsertData(
                table: "Usos",
                columns: new[] { "UsoId", "Descripcion" },
                values: new object[] { 1, "Privado" });

            migrationBuilder.InsertData(
                table: "Usos",
                columns: new[] { "UsoId", "Descripcion" },
                values: new object[] { 2, "Publico" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ClienteId",
                table: "Vehiculos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_UsoId",
                table: "Vehiculos",
                column: "UsoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Clientes_ClienteId",
                table: "Vehiculos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Usos_UsoId",
                table: "Vehiculos",
                column: "UsoId",
                principalTable: "Usos",
                principalColumn: "UsoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Clientes_ClienteId",
                table: "Vehiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Usos_UsoId",
                table: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Usos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_ClienteId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_UsoId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "UsoId",
                table: "Vehiculos");
        }
    }
}
