using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioActual = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress_calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress_numeroPuerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress_ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distancia = table.Column<double>(type: "float", nullable: false),
                    nombreCompleto_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreCompleto_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreCompleto_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreCompleto_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteID = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<double>(type: "float", nullable: false),
                    descuento = table.Column<double>(type: "float", nullable: false),
                    estadoPedido = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_clienteID",
                        column: x => x.clienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articuloId = table.Column<int>(type: "int", nullable: false),
                    cantUnidades = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<double>(type: "float", nullable: false),
                    Pedidoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineas_Articulo_articuloId",
                        column: x => x.articuloId,
                        principalTable: "Articulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineas_Pedidos_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "Pedidos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_articuloId",
                table: "Lineas",
                column: "articuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_Pedidoid",
                table: "Lineas",
                column: "Pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteID",
                table: "Pedidos",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_email",
                table: "Usuarios",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
