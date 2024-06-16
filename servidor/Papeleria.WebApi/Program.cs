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
using Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Papeleria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
            builder.Services.AddScoped<IRepositorioLinea, RepositorioLineaEF>();
            builder.Services.AddScoped<IRepositorioMovimientoStock, RepositorioMovimientoStockEF>();
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();
            builder.Services.AddScoped<IRepositorioSetting, RepositorioSettings>();



            // Caso de uso
            builder.Services.AddScoped<IGetUsuariosAscendenteCU, GetUsuariosAscendenteCU>();
            builder.Services.AddScoped<IRecibeIdDevuelveUsuarioCU, RecibeIdDevuelveUsuarioCU>();
            builder.Services.AddScoped<ICrearUsuarioCU, CrearUsuarioCU>();
            builder.Services.AddScoped<IDeleteUsuarioCU, DeleteUsuarioCU>();
            builder.Services.AddScoped<IUpdateUsuarioCU, UpdateUsuarioCU>();
            builder.Services.AddScoped<ILoginUsuarioCU, UsuarioLoginCU>();
            builder.Services.AddScoped<IDetailsUsuarioCU, DetailsUsuarioCU>();
            builder.Services.AddScoped<IListarUsuariosUC, ObtenerUsuariosUC>();
            builder.Services.AddScoped<IEncontrarUsuarioPorEmailCU, EncontrarUsuarioPorEmailCU>();


            builder.Services.AddScoped<ICrearArticuloCU, CrearArticuloCU>();
            builder.Services.AddScoped<IArticulosOrdenadosAlfabeticamenteCU, ArticulosOrdenadosAlfabeticamenteCU>();

            builder.Services.AddScoped<IGetPedidosAnuladosDescCU, GetPedidosAnuladosDescCU>();


            builder.Services.AddScoped<IClientesCuyoPedidoSupereMontoCU, ClientesCuyoPedidoSupereMontoCU>();
            builder.Services.AddScoped<IBuscarEnClientesCU, BuscarEnClientesCU>();
            builder.Services.AddScoped<ICrearClienteCU, CrearClienteCU>();
            builder.Services.AddScoped<IGetClientesCU, GetClientesCU>();

            builder.Services.AddScoped<IGetPorTipoMovimientoYArticuloCU, GetPorTipoMovimientoYArticuloCU>();
            builder.Services.AddScoped<IGetArticuloPorFechaMovimiento, GetArticuloPorFechaMovimientoCU>();
            builder.Services.AddScoped<IGetResumeByYearAndTypeUC, ObtenerResumenMovimientoPorAñoCU>();
            builder.Services.AddScoped<IExisteTipoCU, ExisteTipoCU>();
            builder.Services.AddScoped<IFindByIDArticuloCU, FindByIdArticuloCU>();

            builder.Services.AddScoped<ICrearMovimientoStockCU, CrearMovimientoStockCU>();

            builder.Services.AddScoped<ICrearTipoMovimientoCU, CrearTipoMovimientoCU>();
            builder.Services.AddScoped<IEliminarTipoMovimientoCU, EliminarTipoMovimientoCU>();
            builder.Services.AddScoped<IFindTipoMovimientoCU, FindTipoMovimientoCU>();
            builder.Services.AddScoped<IGetTiposMovimientoCU, GetTiposMovimientoCU>();
            builder.Services.AddScoped<IUpdateTipoMovientoCU, UpdateTipoMovimientoCU>();
            builder.Services.AddScoped<IFindTipoMovimientoByNameCU, FindTipoMovimientoByNameCU>();
            builder.Services.AddScoped<IGetAllMovimientosCU, GetAllMovimientosCU>();
            builder.Services.AddScoped<IEncontrarUsuarioPorIdCU,  EncontrarUsuarioPorIdCU>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var Clave = "+5/68cZ8hG3J1FJ0HgJQ0zZhxh9eNufp0uF2+R5Fnqw=\r\n";
            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Clave)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddSwaggerGen();
            
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

}

