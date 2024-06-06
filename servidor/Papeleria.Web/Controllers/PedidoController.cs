using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Lineas;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Linea;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.Exceptions.PedidoExpress;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;

namespace Papeleria.Web.Controllers
{
    public class PedidoController : Controller
    {
        private ICrearPedidoCU _crearPedidoCU;
        private IArticulosOrdenadosAlfabeticamenteCU _articulosCU;
        private IFindByIDArticuloCU _findByIDArticuloCU;
        private IGetClientesCU _getClientesCU;
        private IFindClienteByIDCU _findClienteByID;
        private ICalcularPrecioLineaCU _calcularPrecioLinea;
        private IGetPedidosAscendentes _getPedidosAscendentes;
        private IEncontrarUsuarioPorEmailCU _encontrarUsuarioPorEmailCU;
        private IGetPedidosPendientesPorFechaCU _getPedidosPendientesPorFechaCU;
        private IAnularPedidoCU anular;

        private static PedidoDTO tempPedido;
        private static List<LineaDTO> _tempListaLineas;
        private static LineaDTO tempLinea;


        public PedidoController(ICrearPedidoCU crearPedidoCU,
            IArticulosOrdenadosAlfabeticamenteCU articulosOrdenados, IFindByIDArticuloCU findByIDArticuloCU, 
            IGetClientesCU getClientesCU, IFindClienteByIDCU findClienteByIDCU, ICalcularPrecioLineaCU calcularPrecioLineaCU,
            IGetPedidosAscendentes getPedidosAscendentes, IEncontrarUsuarioPorEmailCU encontrarUsuarioPorEmailCU,
            IGetPedidosPendientesPorFechaCU pedidosPendientesCU, IAnularPedidoCU anular)
        {
           
            this._crearPedidoCU = crearPedidoCU;
            this._articulosCU = articulosOrdenados;
            this._findByIDArticuloCU = findByIDArticuloCU;
            this._getClientesCU= getClientesCU;
            this._findClienteByID = findClienteByIDCU;
            this._calcularPrecioLinea= calcularPrecioLineaCU;
            this._getPedidosAscendentes = getPedidosAscendentes;
            this._encontrarUsuarioPorEmailCU = encontrarUsuarioPorEmailCU;
            this._getPedidosPendientesPorFechaCU = pedidosPendientesCU;
            this.anular = anular;
        }
        // GET: PedidoController
        public ActionResult Index()
        {
            return View(this._getPedidosAscendentes.GetPedidosAsc());
        }

       
        // GET: PedidoController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            UsuarioDTO usuario = _encontrarUsuarioPorEmailCU.EncontrarUsuarioPorEmail(HttpContext.Session.GetString("LogueadoCorreo"));
            if (usuario.esAdmin)
            {
                ViewBag.Clientes = _getClientesCU.GetClienteDTOs();
                if (tempPedido != null)
                {
                    ViewBag._tempListaLinea = tempPedido._lineas;
                }
                return View();
            }
            return RedirectToAction("Index", "Home", new { mensaje = "solo los administradores pueden ingresar pedidos" });
            
        }


        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO pedidoDTO)
        {

            try
            {
                pedidoDTO.cliente = _findClienteByID.EncontrarPorIdCliente(pedidoDTO.clienteId);
                if (tempPedido != null && tempPedido._lineas.Count > 0)
                {
                    pedidoDTO._lineas = tempPedido._lineas;
                    foreach (LineaDTO l in tempPedido._lineas)
                    {
                        l.precioLinea = _calcularPrecioLinea.CalcularPrecioLinea( l);
                    }

                    double subTotal = tempPedido._lineas.Sum(linea => linea.precioLinea);
                    ViewBag.SubTotal = subTotal;
                    _crearPedidoCU.CrearPedido(pedidoDTO);
                    tempPedido = null;
                    return RedirectToAction(nameof(Index), new { mensaje = "Pedido agregado correctamente!" });
                }
                else
                {
                    return RedirectToAction(nameof(Index), 
                        new { mensaje = "Debe ingresar al menos 1 articulo para completar el pedido" });
                }
            }
            catch (PedidoComunNoValidoException ex)
            {
                tempPedido = null;
                ViewBag.Clientes = _getClientesCU.GetClienteDTOs();
                return RedirectToAction("Create", new {mensaje = ex.Message});
            }
            catch (PedidoExpressNoValidoException ex)
            {
                tempPedido = null;
                ViewBag.Clientes = _getClientesCU.GetClienteDTOs();
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                tempPedido = null;
                ViewBag.Clientes = _getClientesCU.GetClienteDTOs();
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
        }
        
        public ActionResult AgregarArticuloView() 
        {
            ViewBag.Articulos = _articulosCU.GetArticulosOrdenados();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarArticulo(LineaDTO l)
        {
            try
            {
                l.articulo = _findByIDArticuloCU.EncontrarPorIdArticulo(l.articuloId);
                if(tempPedido==null)
                {
                    tempPedido = new PedidoDTO { _lineas = new List<LineaDTO>()};
                }
                l.precioLinea = _calcularPrecioLinea.CalcularPrecioLinea(l);
                tempPedido._lineas.Add(l);

                return RedirectToAction(nameof(Create));

            }

            catch (LineaNoValidaException ex)
            {
                return RedirectToAction(nameof(Create), new {mensaje=ex.Message});
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
        }
        public ActionResult IngresarFecha()
        {
            return View();
        }
        public ActionResult GetPedidosPendientesPorFecha(DateTime fecha)
        {
            return View("GetPedidosPendientesPorFecha", this._getPedidosPendientesPorFechaCU.GetPedidosPendientesPorFecha(fecha));

        }
        public ActionResult AnularPedido(int id)
        {
            anular.AnularPedido(id);
            return RedirectToAction(nameof(GetPedidosPendientesPorFecha));
        }
    }
}
