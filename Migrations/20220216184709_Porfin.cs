using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Porfin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "SChasis",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "SColor",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "SMatricula",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "SPrecio",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "SUsoVehiculo",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Seguros");

            migrationBuilder.DropColumn(
                name: "Vehiculo",
                table: "Seguros");

            migrationBuilder.RenameColumn(
                name: "SCilindros",
                table: "Seguros",
                newName: "VehiculoId");

            migrationBuilder.RenameColumn(
                name: "SCantidadPasajeros",
                table: "Seguros",
                newName: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_ClienteId",
                table: "Seguros",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_VehiculoId",
                table: "Seguros",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguros_Clientes_ClienteId",
                table: "Seguros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguros_Vehiculos_VehiculoId",
                table: "Seguros",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "VehiculoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguros_Clientes_ClienteId",
                table: "Seguros");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguros_Vehiculos_VehiculoId",
                table: "Seguros");

            migrationBuilder.DropIndex(
                name: "IX_Seguros_ClienteId",
                table: "Seguros");

            migrationBuilder.DropIndex(
                name: "IX_Seguros_VehiculoId",
                table: "Seguros");

            migrationBuilder.RenameColumn(
                name: "VehiculoId",
                table: "Seguros",
                newName: "SCilindros");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Seguros",
                newName: "SCantidadPasajeros");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
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

            migrationBuilder.AddColumn<string>(
                name: "SChasis",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SColor",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SMatricula",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SPrecio",
                table: "Seguros",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SUsoVehiculo",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vehiculo",
                table: "Seguros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
