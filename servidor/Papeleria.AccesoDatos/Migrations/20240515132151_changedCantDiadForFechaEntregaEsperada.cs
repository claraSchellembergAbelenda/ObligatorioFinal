using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class changedCantDiadForFechaEntregaEsperada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_clienteid",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "diasParaLaEntrega",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Pedidos",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_clienteid",
                table: "Pedidos",
                newName: "IX_Pedidos_clienteId");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEntregaDeseada",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_clienteId",
                table: "Pedidos",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_clienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "fechaEntregaDeseada",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Pedidos",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_clienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_clienteid");

            migrationBuilder.AddColumn<int>(
                name: "diasParaLaEntrega",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_clienteid",
                table: "Pedidos",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
