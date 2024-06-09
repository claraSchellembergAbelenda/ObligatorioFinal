using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class tablaTipoMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipoMovimientoId",
                table: "MovimientosStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStock_tipoMovimientoId",
                table: "MovimientosStock",
                column: "tipoMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStock_usuarioId",
                table: "MovimientosStock",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_TiposDeMovimientos_tipoMovimientoId",
                table: "MovimientosStock",
                column: "tipoMovimientoId",
                principalTable: "TiposDeMovimientos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_Usuarios_usuarioId",
                table: "MovimientosStock",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_TiposDeMovimientos_tipoMovimientoId",
                table: "MovimientosStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_Usuarios_usuarioId",
                table: "MovimientosStock");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosStock_tipoMovimientoId",
                table: "MovimientosStock");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosStock_usuarioId",
                table: "MovimientosStock");

            migrationBuilder.DropColumn(
                name: "tipoMovimientoId",
                table: "MovimientosStock");
        }
    }
}
