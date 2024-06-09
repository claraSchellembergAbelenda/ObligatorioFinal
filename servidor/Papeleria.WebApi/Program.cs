using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.CasosDeUso.Cliente;
using Papeleria.LogicaAplicacion.CasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.CasosDeUso.Usuario;
using Papeleria.LogicaAplicacion.CasosDeUso;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesUC;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.CasosDeUso.TipoMovimiento;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;

namespace Papeleria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
            builder.Services.AddScoped<IRepositorioLinea, RepositorioLineaEF>();
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();


            // Caso de uso
            builder.Services.AddScoped<IGetUsuariosAscendenteCU, GetUsuariosAscendenteCU>();
            builder.Services.AddScoped<IRecibeIdDevuelveUsuarioCU, RecibeIdDevuelveUsuarioCU>();
            builder.Services.AddScoped<ICrearUsuarioCU, CrearUsuarioCU>();
            builder.Services.AddScoped<IDeleteUsuarioCU, DeleteUsuarioCU>();
            builder.Services.AddScoped<IUpdateUsuarioCU, UpdateUsuarioCU>();
            builder.Services.AddScoped<ILoginUsuarioCU, UsuarioLoginCU>();
            builder.Services.AddScoped<IDetailsUsuarioCU, DetailsUsuarioCU>();
            builder.Services.AddScoped<IListarUsuariosUC, ObtenerUsuariosUC>();


            builder.Services.AddScoped<ICrearArticuloCU, CrearArticuloCU>();
            builder.Services.AddScoped<IArticulosOrdenadosAlfabeticamenteCU, ArticulosOrdenadosAlfabeticamenteCU>();

            builder.Services.AddScoped<IGetPedidosAnuladosDescCU, GetPedidosAnuladosDescCU>();


            builder.Services.AddScoped<IClientesCuyoPedidoSupereMontoCU, ClientesCuyoPedidoSupereMontoCU>();
            builder.Services.AddScoped<IBuscarEnClientesCU, BuscarEnClientesCU>();
            builder.Services.AddScoped<ICrearClienteCU, CrearClienteCU>();
            builder.Services.AddScoped<IGetClientesCU, GetClientesCU>();

            builder.Services.AddScoped<ICrearTipoMovimientoCU, CrearTipoMovimientoCU>();
            builder.Services.AddScoped<IEliminarTipoMovimientoCU, EliminarTipoMovimientoCU>();
            builder.Services.AddScoped<IUpdateTipoMovientoCU, UpdateTipoMovimientoCU>();
            builder.Services.AddScoped<IFindTipoMovimientoCU, FindTipoMovimientoCU>();
            builder.Services.AddScoped<IGetTiposMovimientoCU, GetTiposMovimientoCU>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

}

