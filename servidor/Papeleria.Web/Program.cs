using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.CasosDeUso.Cliente;
using Papeleria.LogicaAplicacion.CasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.CasosDeUso.Usuario;
using Papeleria.LogicaAplicacion.CasosDeUso.Lineas;
using Papeleria.LogicaAplicacion.CasosDeUso;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Lineas;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaAplicacion.InterfacesUC;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
// Repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
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

builder.Services.AddScoped<ICrearPedidoCU, CrearPedidoCU>();
builder.Services.AddScoped<IGetPedidosAscendentes, GetPedidosAscendentes>();
builder.Services.AddScoped<IGetPedidosPendientesPorFechaCU, GetPedidosPendientesPorFechaCU>();
builder.Services.AddScoped<IAnularPedidoCU, AnularPedidoCU>();


builder.Services.AddScoped<ICalcularPrecioLineaCU, CalcularPrecioLineaCU>();

builder.Services.AddScoped<IClientesCuyoPedidoSupereMontoCU, ClientesCuyoPedidoSupereMontoCU>();
builder.Services.AddScoped<IBuscarEnClientesCU, BuscarEnClientesCU>();
builder.Services.AddScoped<ICrearClienteCU, CrearClienteCU>();
builder.Services.AddScoped<IGetClientesCU, GetClientesCU>();
builder.Services.AddScoped<IFindByIDArticuloCU, FindByIdArticuloCU>();
builder.Services.AddScoped<IFindClienteByIDCU, EncontrarClientePorIdCU>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
