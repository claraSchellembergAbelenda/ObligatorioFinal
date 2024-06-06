using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class dos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_clienteID",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "clienteID",
                table: "Pedidos",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_clienteID",
                table: "Pedidos",
                newName: "IX_Pedidos_clienteid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clientes",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_clienteid",
                table: "Pedidos",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_clienteid",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Pedidos",
                newName: "clienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_clienteid",
                table: "Pedidos",
                newName: "IX_Pedidos_clienteID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clientes",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_clienteID",
                table: "Pedidos",
                column: "clienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
