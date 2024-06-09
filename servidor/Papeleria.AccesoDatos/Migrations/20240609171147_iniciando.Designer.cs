﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papeleria.AccesoDatos.EntityFramework;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    [DbContext(typeof(PapeleriaContext))]
    [Migration("20240609171147_iniciando")]
    partial class iniciando
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Articulo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("codProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("precioActual")
                        .HasColumnType("float");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("codProveedor")
                        .IsUnique();

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("distancia")
                        .HasColumnType("float");

                    b.Property<string>("razonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Linea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("articuloId")
                        .HasColumnType("int");

                    b.Property<int>("cantUnidades")
                        .HasColumnType("int");

                    b.Property<int>("pedidoId")
                        .HasColumnType("int");

                    b.Property<double>("precioLinea")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("articuloId");

                    b.HasIndex("pedidoId");

                    b.ToTable("Lineas");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<double>("descuento")
                        .HasColumnType("float");

                    b.Property<int>("estadoPedido")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaEntregaDeseada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<double>("precioTotal")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.ToTable("Pedidos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pedido");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("esEncargado")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordSinEncriptar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocios.Entidades.MovimientoStock", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("articuloMovidoId")
                        .HasColumnType("int");

                    b.Property<int>("cantUnidadesMovidas")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaYHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("tipoMovimientoId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("articuloMovidoId");

                    b.HasIndex("tipoMovimientoId");

                    b.HasIndex("usuarioId");

                    b.ToTable("MovimientosStock");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocios.Entidades.Setting", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocios.Entidades.TipoMovimiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nombreMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TiposDeMovimientos");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.PedidoComun", b =>
                {
                    b.HasBaseType("Papeleria.LogicaNegocio.Entidades.Pedido");

                    b.HasDiscriminator().HasValue("PedidoComun");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.PedidoExpress", b =>
                {
                    b.HasBaseType("Papeleria.LogicaNegocio.Entidades.Pedido");

                    b.HasDiscriminator().HasValue("PedidoExpress");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Cliente", b =>
                {
                    b.OwnsOne("Papeleria.BusinessLogic.ValueObjects.NombreCompletoClientes", "nombreCompleto", b1 =>
                        {
                            b1.Property<int>("Clienteid")
                                .HasColumnType("int");

                            b1.Property<string>("apellido")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Clienteid");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("Clienteid");
                        });

                    b.OwnsOne("Papeleria.LogicaNegocio.ValueObjects.Direccion", "adress", b1 =>
                        {
                            b1.Property<int>("Clienteid")
                                .HasColumnType("int");

                            b1.Property<string>("calle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ciudad")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("numeroPuerta")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Clienteid");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("Clienteid");
                        });

                    b.Navigation("adress")
                        .IsRequired();

                    b.Navigation("nombreCompleto")
                        .IsRequired();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Linea", b =>
                {
                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Articulo", "articulo")
                        .WithMany()
                        .HasForeignKey("articuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Pedido", "pedido")
                        .WithMany("_lineas")
                        .HasForeignKey("pedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("articulo");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Pedido", b =>
                {
                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.OwnsOne("Papeleria.BusinessLogic.ValueObjects.NombreCompleto", "nombreCompleto", b1 =>
                        {
                            b1.Property<int>("Usuarioid")
                                .HasColumnType("int");

                            b1.Property<string>("apellido")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Usuarioid");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("Usuarioid");
                        });

                    b.Navigation("nombreCompleto")
                        .IsRequired();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocios.Entidades.MovimientoStock", b =>
                {
                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Articulo", "articuloMovido")
                        .WithMany()
                        .HasForeignKey("articuloMovidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papeleria.LogicaNegocios.Entidades.TipoMovimiento", "tipoMovimiento")
                        .WithMany()
                        .HasForeignKey("tipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("articuloMovido");

                    b.Navigation("tipoMovimiento");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Pedido", b =>
                {
                    b.Navigation("_lineas");
                });
#pragma warning restore 612, 618
        }
    }
}
