using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class diasEntregaEnTablaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precioUnitario",
                table: "Lineas",
                newName: "precioLinea");

            migrationBuilder.AddColumn<int>(
                name: "diasParaLaEntrega",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "iva",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Articulo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "codProveedor",
                table: "Articulo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_codProveedor",
                table: "Articulo",
                column: "codProveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_nombre",
                table: "Articulo",
                column: "nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Articulo_codProveedor",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_nombre",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "diasParaLaEntrega",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "iva",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "precioLinea",
                table: "Lineas",
                newName: "precioUnitario");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "codProveedor",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
