using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocios.Entidades;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/PedidosAnulados")]
    public class PedidoController : ControllerBase
    {
        private IGetPedidosAnuladosDescCU _getPedidosAnuladosDescCU;
        public PedidoController(IGetPedidosAnuladosDescCU getPedidosAnuladosDescCU)
        {
            _getPedidosAnuladosDescCU = getPedidosAnuladosDescCU;
        }

        [HttpGet(Name = "GetPedidosAnuladosDescendentes")]
        public ActionResult<IEnumerable<PedidoDTO>> Get()
        {
            try
            {
                return Ok(this._getPedidosAnuladosDescCU.GetPedidosAnuladosDesc().ToList());
            }
            //catch(TipoMovimientoNotValidException texto) 
            //{
            //    return BadRequest(texto.mensaje);
            //}
            catch (Exception ex)
            {
                return BadRequest("Error inesperado con la base de datos");
            }
            
        }
    }
}
