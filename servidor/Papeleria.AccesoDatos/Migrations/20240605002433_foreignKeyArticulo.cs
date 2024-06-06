using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_Articulo_articuloMovidoid",
                table: "MovimientosStock");

            migrationBuilder.RenameColumn(
                name: "articuloMovidoid",
                table: "MovimientosStock",
                newName: "articuloMovidoId");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosStock_articuloMovidoid",
                table: "MovimientosStock",
                newName: "IX_MovimientosStock_articuloMovidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_Articulo_articuloMovidoId",
                table: "MovimientosStock",
                column: "articuloMovidoId",
                principalTable: "Articulo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_Articulo_articuloMovidoId",
                table: "MovimientosStock");

            migrationBuilder.RenameColumn(
                name: "articuloMovidoId",
                table: "MovimientosStock",
                newName: "articuloMovidoid");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosStock_articuloMovidoId",
                table: "MovimientosStock",
                newName: "IX_MovimientosStock_articuloMovidoid");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_Articulo_articuloMovidoid",
                table: "MovimientosStock",
                column: "articuloMovidoid",
                principalTable: "Articulo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
