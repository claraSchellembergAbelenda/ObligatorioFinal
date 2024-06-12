using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaNegocios.Exceptions.MovimientoStock;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/MovimientoStock")]
    public class MovimientoStockController : Controller
    {
        // GET: MovimientoStockController
        private IGetPorTipoMovimientoYArticuloCU _getMovimientosPorTipo;
        private IGetArticuloPorFechaMovimiento _getArticuloPorFechaMovimiento;
        private IGetResumeByYearAndTypeUC _getResumeByYearAndTypeUC;
        private IExisteTipoCU _existeTipoMovimientoCU;
        private IFindByIDArticuloCU _findArticuloByIdCU;
        public MovimientoStockController(IGetPorTipoMovimientoYArticuloCU getMovimientos, 
            IGetArticuloPorFechaMovimiento getArticuloPorFechaMovimiento, 
            IGetResumeByYearAndTypeUC getResumeByYearAndTypeUC, IExisteTipoCU existeTipoMovimientoCU, IFindByIDArticuloCU findByIDArticuloCU)
        {
            _getMovimientosPorTipo = getMovimientos;
            _getArticuloPorFechaMovimiento = getArticuloPorFechaMovimiento;
            _getResumeByYearAndTypeUC = getResumeByYearAndTypeUC;
            _existeTipoMovimientoCU = existeTipoMovimientoCU;
            _findArticuloByIdCU = findByIDArticuloCU;
        }


        [HttpGet("ObtenerMovimientosPorArticuloYTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public ActionResult ObtenerMovimientosPorArticuloYTipo(string message)
        //{
        //    ViewBag.message = message;
        //    return View();
        //}
        //esta bien q el idArticulo y el tipoMovimiento se reciban como las fechas?


        public ActionResult ObtenerMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento)
        {
            try
            {
                if (_existeTipoMovimientoCU.ExisteTipo(tipoMovimiento))
                {
                    ArticuloDTO art =_findArticuloByIdCU.EncontrarPorIdArticulo(idArticulo);
                    if (art != null)
                    {
                        return Ok(_getMovimientosPorTipo.GetPorTipoMovimientoYArticulo(idArticulo, tipoMovimiento));
                    }
                    else
                    {
                        return RedirectToAction(nameof(ObtenerMovimientosPorArticuloYTipo), new { Message = "Id de articulo invalido, por favor trate de vuelta"
                        });
                    }
                }
                else
                {
                    return RedirectToAction(nameof(ObtenerMovimientosPorArticuloYTipo), new
                    {
                        Message = "Tipo de movimiento no encontrado, por favor trate de vuelta"
                    });
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("Filtrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult GetArticulosPorFecha( string fechaInicio, string fechaFin)
        {
            try
            {
                DateTime inicio = DateTime.Parse(fechaInicio);
                DateTime fin = DateTime.Parse(fechaFin);
                return Ok(_getArticuloPorFechaMovimiento.GetArticuloPorFechas(inicio, fin));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMovementsByYearAndType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetMovementsByYearAndType()
        {
            try
            {
                return Ok(View(_getResumeByYearAndTypeUC.ObtenerResumenMovimiento()));
                
            }
            catch(MovimientoStockNoValidoException mv)
            {
                return BadRequest(mv.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
