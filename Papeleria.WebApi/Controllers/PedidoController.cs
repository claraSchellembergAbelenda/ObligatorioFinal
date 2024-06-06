using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;

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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
