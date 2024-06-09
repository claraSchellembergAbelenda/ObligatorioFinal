using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/TipoMovimiento")]
    public class TipoMovimientoController : Controller
    {
        private ICrearTipoMovimientoCU _crearTipoMovimientoCU;
        public TipoMovimientoController(ICrearTipoMovimientoCU crearTipoMovimientoCU)
        {
            _crearTipoMovimientoCU = crearTipoMovimientoCU;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Create(TipoMovimientoDTO TipoMovimientoDTO)
        {
            _crearTipoMovimientoCU.CrearTipoMovimiento(TipoMovimientoDTO);
            return Created("api/TipoMovimiento", TipoMovimientoDTO);
        }

    }   
}
