using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Agregando_Dos_Entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    SeguroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NCF = table.Column<string>(type: "TEXT", nullable: false),
                    Cliente = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Identificacion = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    Vehiculo = table.Column<string>(type: "TEXT", nullable: false),
                    SColor = table.Column<string>(type: "TEXT", nullable: false),
                    SMatricula = table.Column<string>(type: "TEXT", nullable: false),
                    SCantidadPasajeros = table.Column<int>(type: "INTEGER", nullable: false),
                    SPrecio = table.Column<double>(type: "REAL", nullable: false),
                    SChasis = table.Column<string>(type: "TEXT", nullable: false),
                    SCilindros = table.Column<int>(type: "INTEGER", nullable: false),
                    SUsoVehiculo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.SeguroId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    TipoVehiculo = table.Column<string>(type: "TEXT", nullable: false),
                    AnioVehiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    CantidadPasajeros = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Chasis = table.Column<string>(type: "TEXT", nullable: false),
                    Cilindros = table.Column<int>(type: "INTEGER", nullable: false),
                    UsoVehiculo = table.Column<string>(type: "TEXT", nullable: false),
                    Propietario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
