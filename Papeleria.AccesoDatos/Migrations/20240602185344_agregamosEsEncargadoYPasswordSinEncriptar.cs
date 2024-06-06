using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class agregamosEsEncargadoYPasswordSinEncriptar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_Pedidos_Pedidoid",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "iva",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Pedidoid",
                table: "Lineas",
                newName: "pedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lineas_Pedidoid",
                table: "Lineas",
                newName: "IX_Lineas_pedidoId");

            migrationBuilder.AddColumn<bool>(
                name: "esEncargado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "pedidoId",
                table: "Lineas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_Pedidos_pedidoId",
                table: "Lineas",
                column: "pedidoId",
                principalTable: "Pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_Pedidos_pedidoId",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "esEncargado",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "pedidoId",
                table: "Lineas",
                newName: "Pedidoid");

            migrationBuilder.RenameIndex(
                name: "IX_Lineas_pedidoId",
                table: "Lineas",
                newName: "IX_Lineas_Pedidoid");

            migrationBuilder.AddColumn<double>(
                name: "iva",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Pedidoid",
                table: "Lineas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_Pedidos_Pedidoid",
                table: "Lineas",
                column: "Pedidoid",
                principalTable: "Pedidos",
                principalColumn: "id");
        }
    }
}
