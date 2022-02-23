using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Seguro_PA1.Migrations
{
    public partial class Add_ForeignKey_Seguros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeguroId",
                table: "Pagos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_SeguroId",
                table: "Pagos",
                column: "SeguroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Seguros_SeguroId",
                table: "Pagos",
                column: "SeguroId",
                principalTable: "Seguros",
                principalColumn: "SeguroId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Seguros_SeguroId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_SeguroId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "SeguroId",
                table: "Pagos");
        }
    }
}
